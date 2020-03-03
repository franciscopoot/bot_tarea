using RastreoPaquetes.DTO;
using RastreoPaquetes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RastreoPaquetes.Clases
{
    public class MaritimoAjusteTiempo : IAjusteExtra
    {
        readonly List<RangoExtras> LstAjusteTiempo;
        public MaritimoAjusteTiempo()
        {
            LstAjusteTiempo = new List<RangoExtras>()
            { 
              new RangoExtras("Verano",new DateTime(2020,6,1),new DateTime(2020,8,31),-0.10m),
              new RangoExtras("Otoño",new DateTime(2020,9,1),new DateTime(2020,11,30),0.15m),
              new RangoExtras("Invierno",new DateTime(2019,12,1),new DateTime(2020,02,29),-0.30m),
              new RangoExtras("Invierno",new DateTime(2020,12,1),new DateTime(2021,02,28),-0.30m),
             };
        }
        public decimal ObtieneAjustePorEstacion(DateTime _fechaCompra)
        {
            decimal PorcentajeAjuste = 0;
            var porcentajeAdicional = LstAjusteTiempo.FirstOrDefault(f => f.Inicial.Date <= _fechaCompra.Date && f.Final.Date >= _fechaCompra.Date);
            if (porcentajeAdicional != null)
            {
                PorcentajeAjuste = porcentajeAdicional.Variacion;
            }
            return PorcentajeAjuste;
        }
    }
}
