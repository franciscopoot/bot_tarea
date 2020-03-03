using System;
using System.Collections.Generic;
using System.Text;

namespace RastreoPaquetes.Map
{
    public class RetrasoPorDiaPorTemporadaDTO
    {
        public bool Aplicar { set; get; }
        public List<VariacionesDTO> TiemposRetraso { set; get; }
    }
}
