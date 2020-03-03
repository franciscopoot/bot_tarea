using System;
using System.Collections.Generic;
using System.Text;

namespace RastreoPaquetes.DTO
{
    public class RangoExtras
    {
        public RangoExtras() { }
    
        public string Nombre { get; set; }
        public DateTime Inicial { get; set; }
        public DateTime Final { get; set; }
        public decimal Variacion { get; set; }
    }
}
