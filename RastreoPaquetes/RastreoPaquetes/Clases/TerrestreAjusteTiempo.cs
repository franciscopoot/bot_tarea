using RastreoPaquetes.DTO;
using RastreoPaquetes.Interfaces;
using RastreoPaquetes.Map;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace RastreoPaquetes.Clases
{
    public class TerrestreAjusteTiempo : IAjusteExtra
    {
        readonly List<RangoExtras> LstAjusteTiempo = new List<RangoExtras>();
        public TerrestreAjusteTiempo(List<TemporadaDTO> _temporadas, List<VariacionesDTO> _variaciones)
        {
            foreach (var temporada in _temporadas)
            {
                var variacion = _variaciones.FirstOrDefault(f => f.Temporada.ToUpper() == temporada.Temporada.ToUpper());
                if (variacion != null)
                {
                    LstAjusteTiempo.Add(new RangoExtras()
                    {
                        Nombre = temporada.Temporada,
                        Inicial = DateTime.ParseExact(temporada.Inicio, "dd-MM-yyyy", CultureInfo.InvariantCulture),
                        Final = DateTime.ParseExact(temporada.Fin, "dd-MM-yyyy", CultureInfo.InvariantCulture),
                        Variacion = variacion.PorcentajeExtra
                    });
                }
            }
        }
        public decimal ObtieneAjustePorEstacion(DateTime _fechaCompra)
        {
            decimal horasDescandoSalida = 1m;
            var horasDescando = LstAjusteTiempo.FirstOrDefault(f => f.Inicial.Date <= _fechaCompra.Date && f.Final.Date >= _fechaCompra.Date);
            if (horasDescando != null)
            {
                horasDescandoSalida = horasDescando.Variacion;
            }
            return horasDescandoSalida;
        }
    }
}
