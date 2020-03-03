using RastreoPaquetes.Clases.Exceptions;
using RastreoPaquetes.DTO;
using RastreoPaquetes.Enum;
using RastreoPaquetes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RastreoPaquetes.Clases
{
    public class Fedex : IPaqueteria
    {
        readonly IMargenUtilidad MargenUtilidad;
        public string Nombre => "Fedex";

        public Dictionary<string, decimal> TiempoReparto { get; private set; }
        public IMedioTransporte[] LstMediosTransporte { get; private set; }
        public Fedex(IMedioTransporte[] _lstMedioTransportes,IMargenUtilidad _margenUtilidad) {
            LstMediosTransporte = _lstMedioTransportes;
            MargenUtilidad = _margenUtilidad;
            TiempoReparto = new Dictionary<string, decimal>
            {
                { MedioTransporteEnum.Marítimo.ToString().ToUpper(), 21m },
                { MedioTransporteEnum.Terrestre.ToString().ToUpper(), 10m },
                { MedioTransporteEnum.Aéreo.ToString().ToUpper(), 0m }
            };
        }
        public decimal ObtenerCostoServicio(ParametrosPaqueteriaDTO _param)
        {
            var MedioTransporte = ObtenerMedioTransporte(_param.NombreMedioTransporte);
            var CostoTransporte = MedioTransporte.ObtieneCostoTransporte(new ParametroCalculoMedioTransporteDTO() { Distancia = _param.Distancia, FechaCompra = _param.FechaPedido });
            decimal PorcentajeUtilidad = MargenUtilidad.ObtenerMargenUtilidad(_param.FechaPedido);
            return Math.Round(CostoTransporte * PorcentajeUtilidad,2);
        }

        public DateTime ObtenerFechaEntrega(ParametrosPaqueteriaDTO _param)
        {
            var MedioTransporte = ObtenerMedioTransporte(_param.NombreMedioTransporte);
            var TiempoTransporte = MedioTransporte.ObtieneTiempoTransporte(new ParametroCalculoMedioTransporteDTO() { Distancia = _param.Distancia, FechaCompra = _param.FechaPedido });
            var TiempoEntrega = TiempoReparto[_param.NombreMedioTransporte.ToUpper()];
            var TiempoTotal = TiempoTransporte + TiempoEntrega;

            return _param.FechaPedido.AddHours(decimal.ToDouble(TiempoTotal));
        }

        private IMedioTransporte ObtenerMedioTransporte(string _nombreMedioTransporte) {
            var medioTransporte = LstMediosTransporte.FirstOrDefault(f => f.Nombre == _nombreMedioTransporte);
            if (medioTransporte == null) {
                throw new MedioTransporteException($"Fedex no ofrece el servicio de transporte {_nombreMedioTransporte}, te recomendamos cotizar en otra empresa.");
            }
            return medioTransporte;
        }
        public bool ValidaMedioTransporte(string _nombreMedioTransporte)
        {
            return LstMediosTransporte.Any(f=>f.Nombre == _nombreMedioTransporte);
        }
    }
}
