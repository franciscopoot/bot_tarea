using System;
using System.Collections.Generic;
using System.Text;

namespace RastreoPaquetes.DTO
{
    public class PedidoDTO
    {
        public decimal Distancia { set; get; }
        public string Paqueteria { set; get; }
        public string MedioTransporte { set; get; }
        public DateTime FechaPedido { set; get; }
        public string PaisOrigen { set; get; }
        public string CiudadOrigen { set; get; }
        public string PaisDestino { set; get; }
        public string CiudadDestino{ set; get; }
    }
}
