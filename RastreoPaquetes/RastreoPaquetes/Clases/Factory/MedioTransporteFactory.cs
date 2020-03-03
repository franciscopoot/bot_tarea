using RastreoPaquetes.DTO;
using RastreoPaquetes.Enum;
using RastreoPaquetes.Interfaces;
using RastreoPaquetes.Interfaces.Factory;
using System;
using System.Collections.Generic;

namespace RastreoPaquetes.Clases.Factory
{
    public class MedioTransporteFactory : IMedioTransporteFactory
    {
        readonly Dictionary<string, List<RangoCosto>> dicConfiguraciones = new Dictionary<string, List<RangoCosto>>();

        public MedioTransporteFactory() {
            dicConfiguraciones.Add(MedioTransporteEnum.Terrestre.ToString().ToUpper(), new List<RangoCosto>() { new RangoCosto(1m, 50m, 15m), new RangoCosto(51m, 200m, 10m), new RangoCosto(201m, 300, 8m), new RangoCosto(301m, null, 7m) });
            dicConfiguraciones.Add(MedioTransporteEnum.Maritimo.ToString().ToUpper(), new List<RangoCosto>() { new RangoCosto(1m, 100m, 1m), new RangoCosto(101m, 1000m, 0.5m), new RangoCosto(1001, null, 0.3m) });
            dicConfiguraciones.Add(MedioTransporteEnum.Aereo.ToString().ToUpper(), new List<RangoCosto>() { new RangoCosto(1m, null, 10m) });
        }
        public IMedioTransporte Create(MedioTransporteEnum _medioTransporte)
        {
            IMedioTransporte factory;
            switch (_medioTransporte)
            {
                case MedioTransporteEnum.Terrestre:
                    factory = new Terrestre(dicConfiguraciones[_medioTransporte.ToString().ToUpper()],new TerrestreAjusteTiempo());
                    break;
                case MedioTransporteEnum.Maritimo:
                    factory = new Maritimo(dicConfiguraciones[_medioTransporte.ToString().ToUpper()],new MaritimoAjusteCosto(),new MaritimoAjusteTiempo());
                    break;
                case MedioTransporteEnum.Aereo:
                    factory = new Aereo(dicConfiguraciones[_medioTransporte.ToString().ToUpper()]);
                    break;
                default:
                    throw new NotImplementedException($"No existe una implementación para el medio de transporte {_medioTransporte.ToString()}.");
                    
            }
            return factory;
        }
    }
}
