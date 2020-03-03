using System;
using System.Collections.Generic;
using System.Text;

namespace RastreoPaquetes.Map
{
    public class RetrasoPorDistanciaDTO
    {
        public bool Aplicar { set; get; }
        public decimal DistanciaKM { set; get; }
        public decimal Tiempo { set; get; }
    }
}
