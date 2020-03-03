using RastreoPaquetes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using RastreoPaquetes.DTO;

namespace RastreoPaquetes.Clases
{
    public class Maritimo : IMedioTransporte
    {
        readonly List<RangoCosto> LstCosto;
        readonly IAjusteExtra AjusteCosto;
        readonly IAjusteExtra AjusteTiempo;
        public string Nombre => "Maritimo";
        public decimal VelocidadEntrega =>46m;

        public Maritimo(List<RangoCosto> _lstCosto, IAjusteExtra _ajusteCosto,IAjusteExtra _ajusteTiempo) {
            LstCosto = _lstCosto;
            AjusteCosto = _ajusteCosto;
            AjusteTiempo = _ajusteTiempo;
        }
   
        public decimal ObtieneCostoTransporte(ParametroCalculoMedioTransporteDTO _param)
        {
            var costoInicial = ObtieneCalculo(_param.Distancia);
            var porcentajeExtra = AjusteCosto.ObtieneAjustePorEstacion(_param.FechaCompra);

            return Math.Round(_param.Distancia * costoInicial * porcentajeExtra,2);
        }

        public decimal ObtieneTiempoTransporte(ParametroCalculoMedioTransporteDTO _param)
        {
            decimal PorcentaVariacion = AjusteTiempo.ObtieneAjustePorEstacion(_param.FechaCompra);
            decimal VelocidadFinal = VelocidadEntrega + (VelocidadEntrega * PorcentaVariacion);
            decimal TiempoTraslado = Math.Round(_param.Distancia / VelocidadFinal,2);

            return Math.Round(TiempoTraslado,2);
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
