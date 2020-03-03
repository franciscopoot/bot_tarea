using RastreoPaquetes.Interfaces.Chain;
using System;

namespace RastreoPaquetes.Clases.Chain
{
    public class HorasValidador : IRangoTiempoValidador
    {
        public IRangoTiempoValidador Siguiente { get; private set; }

        public void AsignaSiguiente(IRangoTiempoValidador _validador)
        {
            Siguiente = _validador;
        }
        public string ValidaFecha(TimeSpan _diferencia)
        {
            int diff = Math.Abs((int)_diferencia.TotalHours);
            if (diff <= 23) { 
                if(diff ==1)
                    return $"{diff} Hora";
                
                return $"{diff} Horas";
            }

            if (Siguiente != null)
                return Siguiente.ValidaFecha(_diferencia);

            return "";
        }
    }
}
