using RastreoPaquetes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using RastreoPaquetes.DTO;

namespace RastreoPaquetes.Clases
{
    public class Aereo : IMedioTransporte
    {
        readonly List<RangoCosto> LstCosto;
        public string Nombre => "Aereo";

        public decimal VelocidadEntrega => 600m;

        public Aereo( List<RangoCosto> _lstCosto) {
            LstCosto = _lstCosto;
        }

        public decimal ObtieneCostoTransporte(ParametroCalculoMedioTransporteDTO _param)
        {
            var costoInicial = ObtieneCalculo(_param.Distancia);

            int EscalasPorKm = decimal.ToInt32(_param.Distancia / 1000);
            decimal CargoExtra = 200 * EscalasPorKm;

            return (_param.Distancia * costoInicial)+CargoExtra;
        }

        public decimal ObtieneTiempoTransporte(ParametroCalculoMedioTransporteDTO _param)
        {
            int EscalasPorKm = Decimal.ToInt32(_param.Distancia / 1000);
            decimal TiempoAdicional = EscalasPorKm * 6;
            decimal TiempoTranslado = _param.Distancia / VelocidadEntrega; // horas
            return Math.Round(TiempoTranslado + TiempoAdicional, 2);
        }
        private decimal ObtieneCalculo(decimal _distancia)
        {
            var costoInicial = LstCosto.FirstOrDefault(f => f.Inicial <= _distancia && (f.Final == null || f.Final >= _distancia));
            if (costoInicial == null)
            {
                throw new Exception($"No se encontro el rango de costo para la distancia: {_distancia.ToString()}");
            }
            return costoInicial.Costo;
        }
    }
}
