using Microsoft.Extensions.DependencyInjection;
using RastreoPaquetes.Clases;
using RastreoPaquetes.Clases.Factory;
using RastreoPaquetes.Enum;
using RastreoPaquetes.Interfaces;
using RastreoPaquetes.Interfaces.Factory;
using System;

namespace RastreoPaquetes
{
    class Program
    {
        private static IServiceProvider _serviceProvider;
        static void Main(string[] args)
        {
            try
            {
                RegisterServices();
                var paqueteriaFactory = _serviceProvider.GetService<PaqueteriaFactory>();
                var textoFormateadorFactory = _serviceProvider.GetService<TextoFormateadorFactory>();
                CsvLectorArchivo lectorArchivo = new CsvLectorArchivo();
                var lstPedidos = lectorArchivo.LeerArchivo("pedidos.csv", "");
                var lstPaqueterias = new IPaqueteria[]{
                paqueteriaFactory.Create(PaqueteriaEnum.Fedex),
                paqueteriaFactory.Create(PaqueteriaEnum.Estafeta),
                paqueteriaFactory.Create(PaqueteriaEnum.Dhl)
            };

                AdministradorPedidos administrador = new AdministradorPedidos(lstPedidos, lstPaqueterias, textoFormateadorFactory);

                var lstObtenerEstadosPedido = administrador.ObtenerEstatusPedidos(DateTime.Now);


                foreach (var item in lstObtenerEstadosPedido)
                {

                    Console.ForegroundColor = (ConsoleColor)System.Enum.Parse(typeof(ConsoleColor), item.Color);
                    Console.WriteLine(item.Mensaje + "\n");
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
