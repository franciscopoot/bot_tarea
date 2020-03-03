using RastreoPaquetes.DTO;
using RastreoPaquetes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RastreoPaquetes.Clases
{
    public class MaritimoAjusteCosto : IAjusteExtra
    {
        readonly List<RangoExtras> LstAjusteCosto;
        public MaritimoAjusteCosto()
        {
            LstAjusteCosto = new List<RangoExtras>()
            {
              new RangoExtras("Verano",new DateTime(2020,6,1),new DateTime(2020,8,31),1.10m),
              new RangoExtras("Otoño",new DateTime(2020,9,1),new DateTime(2020,11,30),1.15m),
              new RangoExtras("Invierno",new DateTime(2019,12,1),new DateTime(2020,02,29),1.23m),
              new RangoExtras("Invierno",new DateTime(2020,12,1),new DateTime(2021,02,28),1.23m),
            };
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
