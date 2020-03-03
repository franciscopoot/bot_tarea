using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using RastreoPaquetes.Clases;
using RastreoPaquetes.Clases.Factory;
using RastreoPaquetes.Enum;
using RastreoPaquetes.Interfaces;
using RastreoPaquetes.Interfaces.Factory;
using RastreoPaquetes.Map;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace RastreoPaquetes
{
    class Program
    {
        private static IServiceProvider _serviceProvider;
        static void Main(string[] args)
        {
           
            try
            {
                TemporadasMediosDTO temporadasDTO = new TemporadasMediosDTO();
                PeriodosDTO periodosDTO = new PeriodosDTO();
                PaqueteriasDTO paqueteriasDTO = new PaqueteriasDTO();

                RegisterServices();
                try
                {   // Open the text file using a stream reader.
                    using (StreamReader sr = new StreamReader("Config.json"))
                    {
                        // Read the stream to a string, and write the string to the console.
                        string line = sr.ReadToEnd();
                        var Json = JsonConvert.DeserializeObject(line);
                        IEnumerable<object> collection = (IEnumerable<object>)Json;
                        var lst = collection.ToList();
                        temporadasDTO = JsonConvert.DeserializeObject<TemporadasMediosDTO>(lst[0].ToString());
                        periodosDTO = JsonConvert.DeserializeObject<PeriodosDTO>(lst[1].ToString());
                        paqueteriasDTO = JsonConvert.DeserializeObject<PaqueteriasDTO>(lst[2].ToString());
                    }
                    var medioTransporteFactory = new MedioTransporteFactory(temporadasDTO.MediosTransporte, temporadasDTO.Temporadas);
                    var paqueteriaFactory = new PaqueteriaFactory(medioTransporteFactory, paqueteriasDTO);
                    var lstPaqueterias = new List<IPaqueteria>();
                    foreach (var paqueteriaDTO in paqueteriasDTO.Paqueterias)
                    {
                        lstPaqueterias.Add(paqueteriaFactory.Create(paqueteriaDTO.Paqueteria));
                    }
                    var tipoArchivo = args[1];
                    var extensionArchivo = tipoArchivo.ToLower();
                    var factoryLectorArchivo = new LectorArchivoFactory();



                    var lectorArchivo = factoryLectorArchivo.Create(tipoArchivo);
                    var lstPedidos = lectorArchivo.LeerArchivo("pedidos."+extensionArchivo, "");

                    AdministradorPedidos administrador = new AdministradorPedidos(lstPedidos, lstPaqueterias.ToArray(), new TextoFormateadorFactory());

                    var lstObtenerEstadosPedido = administrador.ObtenerEstatusPedidos(DateTime.Now);

                    ////Pinta el resultado
                    foreach (var item in lstObtenerEstadosPedido)
                    {

                        Console.ForegroundColor = (ConsoleColor)System.Enum.Parse(typeof(ConsoleColor), item.Color);
                        Console.WriteLine(item.Mensaje + "\n");
                    }

                    //Crea archivos
                    var paqueteriasConPedido = lstObtenerEstadosPedido.Select(d => d.Paqueteria).Distinct();
                    foreach (var item in paqueteriasConPedido) {
                        var pathEntregados = item + @"\Entregados";
                        var pathPendientes = item + @"\Pendientes";
                        if (!Directory.Exists(item))
                        {
                            Directory.CreateDirectory(item);
                            Directory.CreateDirectory(pathEntregados);
                            Directory.CreateDirectory(pathPendientes);
                        }
                       
                        var entregados = (from salida in lstObtenerEstadosPedido
                                         where salida.Paqueteria.Equals(item) && salida.Estado.Equals("Entregado")
                                         group salida by salida.Clasificador into newGroup
                                         select new
                                         {
                                             Key = newGroup.Key,
                                             Values = string.Join('\n', newGroup.Select(f => f.Mensaje))
                                         }).ToList();

                        var pendientes = (from salida in lstObtenerEstadosPedido
                                          where salida.Paqueteria.Equals(item) && salida.Estado.Equals("Pendiente")
                                          group salida by salida.Clasificador into newGroup
                                          select new
                                          {
                                              Key = newGroup.Key,
                                              Values = string.Join('\n', newGroup.Select(f => f.Mensaje))
                                          }).ToList();



                        foreach (var grupo in entregados)
                        {
                            File.WriteAllText(pathEntregados + @$"\{grupo.Key}.txt",grupo.Values);
                        }
                        foreach (var grupo in pendientes)
                        {
                            File.WriteAllText(pathPendientes + @$"\{grupo.Key}.txt", grupo.Values);
                        }

                    }

                }
                catch (IOException e)
                {
                    Console.WriteLine("The file could not be read:");
                    Console.WriteLine(e.Message);
                }


                DisposeServices();
            }
            catch (Exception ex) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error principal: {ex.Message}");
            }
          
        }

        private static void RegisterServices()
        {
            var collection = new ServiceCollection();
            collection.AddSingleton<PaqueteriaFactory>();
            collection.AddScoped<TextoFormateadorFactory>();
            collection.AddScoped<IMedioTransporteFactory, MedioTransporteFactory>();
            collection.AddScoped<IPaqueteriaFactory, PaqueteriaFactory>();
            collection.AddScoped<ITextoFormateadorFactory, TextoFormateadorFactory>();

            _serviceProvider = collection.BuildServiceProvider();
        }

        private static void DisposeServices()
        {
            if (_serviceProvider == null)
            {
                return;
            }
            if (_serviceProvider is IDisposable)
            {
                ((IDisposable)_serviceProvider).Dispose();
            }
        }
    }
}
