using System;
using System.Collections.Generic;
using System.Text;

namespace RastreoPaquetes.DTO
{
    public class RangoExtras
    {
        public RangoExtras(string _nombre, DateTime _inicial, DateTime _final, decimal _variacion) {
            Nombre = _nombre;
            Inicial = _inicial;
            Final = _final;
            Variacion = _variacion;
        }
        public string Nombre { get; set; }
        public DateTime Inicial { get; set; }
        public DateTime Final { get; set; }
        public decimal Variacion { get; set; }
    }
}
