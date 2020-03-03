using RastreoPaquetes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using RastreoPaquetes.DTO;

namespace RastreoPaquetes.Clases
{
    public class Terrestre : IMedioTransporte
    {
        readonly List<RangoCosto> LstCosto;
        readonly IAjusteExtra AjusteTiempo;
        public string Nombre => "Terrestre";
        public decimal VelocidadEntrega => 80m;

        public Terrestre( List<RangoCosto> _lstCosto,IAjusteExtra _ajusteTiempo)
        {
            LstCosto = _lstCosto;
            AjusteTiempo = _ajusteTiempo;
        }
      
        public decimal ObtieneCostoTransporte(ParametroCalculoMedioTransporteDTO _param)
        {
            decimal costoInicial = ObtieneCalculo(_param.Distancia);
            return _param.Distancia * costoInicial;
        }

        public decimal ObtieneTiempoTransporte(ParametroCalculoMedioTransporteDTO _param)
        {
            decimal HorasAdicional = AjusteTiempo.ObtieneAjustePorEstacion(_param.FechaCompra);
            decimal TiempoTraslado = Math.Round(_param.Distancia / VelocidadEntrega, 2);

            decimal TiempoExtra = Math.Round((TiempoTraslado/24) * HorasAdicional,2); // Dias

            return TiempoTraslado + TiempoExtra;
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
