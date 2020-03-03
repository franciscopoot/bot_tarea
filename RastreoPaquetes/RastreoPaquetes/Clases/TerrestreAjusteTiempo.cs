using RastreoPaquetes.DTO;
using RastreoPaquetes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RastreoPaquetes.Clases
{
    public class TerrestreAjusteTiempo : IAjusteExtra
    {
        readonly List<RangoExtras> LstAjusteTiempo;
        public TerrestreAjusteTiempo()
        {
            LstAjusteTiempo = new List<RangoExtras>()
        {
          new RangoExtras("Primavera",new DateTime(2020,3,1),new DateTime(2020,5,31),4m),
          new RangoExtras("Verano",new DateTime(2020,6,1),new DateTime(2020,8,31),6m),
          new RangoExtras("Otoño",new DateTime(2020,9,1),new DateTime(2020,11,30),5m),
          new RangoExtras("Invierno",new DateTime(2019,12,1),new DateTime(2020,2,29),8m),
          new RangoExtras("Invierno",new DateTime(2020,12,1),new DateTime(2021,2,28),8m)
        };
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
