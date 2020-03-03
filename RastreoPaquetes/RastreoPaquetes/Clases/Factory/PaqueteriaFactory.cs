using RastreoPaquetes.Enum;
using RastreoPaquetes.Interfaces;
using RastreoPaquetes.Interfaces.Factory;
using System;

namespace RastreoPaquetes.Clases.Factory
{
    public class PaqueteriaFactory : IPaqueteriaFactory
    {
        readonly IMedioTransporteFactory MedioTransporteFactory;
        public PaqueteriaFactory(IMedioTransporteFactory _medioTransporteFactory) {
            MedioTransporteFactory = _medioTransporteFactory;
        }
        public IPaqueteria Create(PaqueteriaEnum _nombrePaqueteria)
        {

            IPaqueteria factory;
            switch (_nombrePaqueteria)
            {
                case PaqueteriaEnum.Fedex:
                    IMedioTransporte[] mediosTransporteFedex = { MedioTransporteFactory.Create(MedioTransporteEnum.Maritimo), MedioTransporteFactory.Create(MedioTransporteEnum.Terrestre), MedioTransporteFactory.Create(MedioTransporteEnum.Aereo) };
                    factory = new Fedex(mediosTransporteFedex, new FedexMargenUtilidad());
                    break;
                case PaqueteriaEnum.Dhl:
                    IMedioTransporte[] mediosTransporteDhl = { MedioTransporteFactory.Create(MedioTransporteEnum.Maritimo), MedioTransporteFactory.Create(MedioTransporteEnum.Terrestre), MedioTransporteFactory.Create(MedioTransporteEnum.Aereo) };
                    factory = new Dhl(mediosTransporteDhl, new DhlMargenUtilidad());
                    break;
                case PaqueteriaEnum.Estafeta:
                    IMedioTransporte[] mediosTransporteEstafeta = { MedioTransporteFactory.Create(MedioTransporteEnum.Maritimo), MedioTransporteFactory.Create(MedioTransporteEnum.Terrestre) };
                    factory = new Estafeta(mediosTransporteEstafeta, new EstafetaMargenUtilidad());
                    break;
                default:
                    throw new NotImplementedException($"No existe una implementación para la paqueteria {_nombrePaqueteria.ToString()}.");
            }
            return factory;
        }
    }
}
