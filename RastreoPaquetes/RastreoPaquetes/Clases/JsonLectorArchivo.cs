using Newtonsoft.Json;
using RastreoPaquetes.DTO;
using RastreoPaquetes.Interfaces;
using RastreoPaquetes.Map;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace RastreoPaquetes.Clases
{
    public class JsonLectorArchivo : ILectorArchivo
    {
        public string Tipo => "Json";

        public List<PedidoDTO> LeerArchivo(string name, string path)
        {
            List<PedidoDTO> _salida = new List<PedidoDTO>();
            using (StreamReader sr = new StreamReader(name))
            {
                // Read the stream to a string, and write the string to the console.
                string line = sr.ReadToEnd();
                var JsonObject = JsonConvert.DeserializeObject<JsonPedidosDTO>(line);

                foreach (var pedido in JsonObject.Pedidos) {
                    _salida.Add(new PedidoDTO()
                    {
                        CiudadOrigen = pedido.Procedencia,
                        PaisOrigen = "",
                        CiudadDestino = pedido.Destino,
                        PaisDestino ="",
                        Paqueteria = pedido.Empresa,
                        MedioTransporte = pedido.MedioTrans,
                        Distancia = pedido.Dist_KM,
                        FechaPedido = DateTime.ParseExact(pedido.FechaPedido,new string[] { "dd-MM-yyyy HH:mm:ss", "dd-MM-yyyy" }, CultureInfo.InvariantCulture)
                    }) ;
                }
                return _salida;
            }
        }
    }
}
