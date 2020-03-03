using System;
using System.Collections.Generic;
using System.Text;

namespace RastreoPaquetes.DTO
{
    public class DatoSalidaDTO
    {
        public int Linea { set; get; }
        public string CiudadOrigen { set; get; }
        public string PaisOrigen { set; get; }
        public string CiudadDestino { set; get; }
        public string PaisDestino { set; get; }
        public DateTime FechaEntrega { set; get; }
        public decimal CostoServicio { set; get; }
        public DateTime FechaHoy { set; get; }
        public string NombrePaqueteria { set; get; }
        public OpcionMasEconomicaDTO OpcionMasEconomica {set;get;}
    }
}
