using System;

namespace RastreoPaquetes.DTO
{
    public class ParametrosPaqueteriaDTO
    {
        public string NombreMedioTransporte { set; get; }
        public DateTime FechaPedido { set; get; }
        public decimal Distancia { set; get; }
    }
}
