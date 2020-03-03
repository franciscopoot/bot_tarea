using RastreoPaquetes.Enum;
using RastreoPaquetes.Interfaces;
using RastreoPaquetes.Interfaces.Factory;
using RastreoPaquetes.Map;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RastreoPaquetes.Clases.Factory
{
    public class PaqueteriaFactory : IPaqueteriaFactory
    {
        readonly IMedioTransporteFactory MedioTransporteFactory;
        readonly PaqueteriasDTO paqueteriasDTO;
        public PaqueteriaFactory(IMedioTransporteFactory _medioTransporteFactory,PaqueteriasDTO _paqueteriasDTO) {
            MedioTransporteFactory = _medioTransporteFactory;
            paqueteriasDTO = _paqueteriasDTO;
        }
        public IPaqueteria Create(string _nombrePaqueteria )
        {
            var dto =   paqueteriasDTO.Paqueterias.FirstOrDefault(f => f.Paqueteria == _nombrePaqueteria);
            var _nombrePaqueteriaEnum = (PaqueteriaEnum)System.Enum.Parse(typeof(PaqueteriaEnum), dto.Paqueteria.ToUpper());
            List<IMedioTransporte> mediosTransporte = new List<IMedioTransporte>();
            foreach (var medio in dto.Medios) {
                mediosTransporte.Add(MedioTransporteFactory.Create(medio.Medio));
            }
            IPaqueteria factory;
            switch (_nombrePaqueteriaEnum)
            {
                case PaqueteriaEnum.FEDEX:
                    factory = new Fedex(mediosTransporte.ToArray(),  new FedexMargenUtilidad(dto.MargenUtilidad));
                    break;
                case PaqueteriaEnum.DHL:                 
                    factory = new Dhl(mediosTransporte.ToArray(), new DhlMargenUtilidad(dto.MargenUtilidad));
                    break;
                case PaqueteriaEnum.ESTAFETA:
                    factory = new Estafeta(mediosTransporte.ToArray(), new EstafetaMargenUtilidad(dto.MargenUtilidad));
                    break;
                default:
                    throw new NotImplementedException($"No existe una implementación para la paqueteria {_nombrePaqueteriaEnum.ToString()}.");
            }
            return factory;
        }
    }
}
