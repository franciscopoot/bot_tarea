using System;
using System.Collections.Generic;
using System.Text;

namespace RastreoPaquetes.Map
{
    public class MedioTransporteDTO
    {
        public string Medio { set; get; }
        public decimal Velocidad { set; get; }

        public List<CostoPorKilometro> CostoPorKilometro { set; get; }
        public VelocidadPorTemporadaDTO VelocidadPorTemporada { set; get; }
        public VelocidadPorTemporadaDTO CostoAdicionalPorTemporada { set; get; }
        public RetrasoPorDiaPorTemporadaDTO RetrasoPorDiaPorTemporada { set; get; }
        public RetrasoPorDistanciaDTO RetrasoPorDistancia { set; get; }
        public CostoExtraPorDistanciaDTO CostoExtraPorDistancia { set; get; }
    }
}
