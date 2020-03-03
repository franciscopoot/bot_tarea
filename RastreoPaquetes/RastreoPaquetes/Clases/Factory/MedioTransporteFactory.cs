using RastreoPaquetes.DTO;
using RastreoPaquetes.Enum;
using RastreoPaquetes.Interfaces;
using RastreoPaquetes.Interfaces.Factory;
using RastreoPaquetes.Map;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RastreoPaquetes.Clases.Factory
{
    public class MedioTransporteFactory : IMedioTransporteFactory
    {
        readonly List<MedioTransporteDTO> lstMediosTransporteDTO;
        readonly List<TemporadaDTO> lstTemporadas;

        public MedioTransporteFactory(List<MedioTransporteDTO> _lstMediosTransporteDTO, List<TemporadaDTO> _lstTemporadas) {
            lstMediosTransporteDTO = _lstMediosTransporteDTO;
            lstTemporadas = _lstTemporadas;
        }
        public IMedioTransporte Create(string _medioTransporte)
        {
            var dto = lstMediosTransporteDTO.FirstOrDefault(f => f.Medio == _medioTransporte);
            var _nombreMedioTransporteEnum = (MedioTransporteEnum)System.Enum.Parse(typeof(MedioTransporteEnum), dto.Medio);

            IMedioTransporte factory;
            switch (_nombreMedioTransporteEnum)
            {
                case MedioTransporteEnum.Terrestre:
                    factory = new Terrestre(dto.CostoPorKilometro,new TerrestreAjusteTiempo(lstTemporadas,dto.RetrasoPorDiaPorTemporada.TiemposRetraso), dto.Medio, dto.Velocidad);
                    break;
                case MedioTransporteEnum.Marítimo:
                    factory = new Maritimo(dto.CostoPorKilometro, new MaritimoAjusteCosto(lstTemporadas,dto.CostoAdicionalPorTemporada.Variaciones),new MaritimoAjusteTiempo(lstTemporadas, dto.VelocidadPorTemporada.Variaciones),dto.Medio,dto.Velocidad);
                    break;
                case MedioTransporteEnum.Aéreo:
                    factory = new Aereo(dto.CostoPorKilometro, dto.Medio, dto.Velocidad);
                    break;
                default:
                    throw new NotImplementedException($"No existe una implementación para el medio de transporte {_nombreMedioTransporteEnum.ToString()}.");
                    
            }
            return factory;
        }
    }
}
