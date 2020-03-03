using RastreoPaquetes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using RastreoPaquetes.DTO;
using RastreoPaquetes.Map;

namespace RastreoPaquetes.Clases
{
    public class Aereo : IMedioTransporte
    {
        readonly List<RangoCosto> LstCosto = new List<RangoCosto>();
        public string Nombre { set; get; }

        public decimal VelocidadEntrega { set; get; }

        public Aereo(List<CostoPorKilometro> _lstCosto, string _nombre, decimal _velocidad) {
            foreach (var costo in _lstCosto)
            {
                LstCosto.Add(new RangoCosto()
                {
                    Inicial = costo.inicio,
                    Final = costo.fin,
                    Costo = costo.costo
                });
            }
            Nombre = _nombre;
            VelocidadEntrega = _velocidad;
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
