using RastreoPaquetes.DTO;
using RastreoPaquetes.Interfaces;
using RastreoPaquetes.Map;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace RastreoPaquetes.Clases
{
    public class MaritimoAjusteCosto : IAjusteExtra
    {
        readonly List<RangoExtras> LstAjusteCosto = new List<RangoExtras>();
        public MaritimoAjusteCosto(List<TemporadaDTO> _temporadas, List<VariacionesDTO> _variaciones)
        {
            foreach (var temporada in _temporadas) {
                var variacion = _variaciones.FirstOrDefault(f => f.Temporada.ToUpper() == temporada.Temporada.ToUpper());
                if (variacion != null) {
                    LstAjusteCosto.Add(new RangoExtras()
                    {
                        Nombre = temporada.Temporada,
                        Inicial = DateTime.ParseExact(temporada.Inicio, "dd-MM-yyyy", null),
                        Final = DateTime.ParseExact(temporada.Fin, "dd-MM-yyyy", null),
                        Variacion = variacion.PorcentajeExtra
                    }) ;
                }
            }
           
        }
        public decimal ObtieneAjustePorEstacion(DateTime _fechaCompra)
        {
            decimal PorcentajeVariacion = 1m;
            var porcentajeAdicional = LstAjusteCosto.FirstOrDefault(f => f.Inicial.Date <= _fechaCompra.Date && f.Final.Date >= _fechaCompra.Date);
            if (porcentajeAdicional != null)
            {
                PorcentajeVariacion = porcentajeAdicional.Variacion;
            }
            return PorcentajeVariacion;
        }
    
    }
}
