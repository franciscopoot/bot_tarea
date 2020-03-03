using RastreoPaquetes.Interfaces.Chain;
using System;

namespace RastreoPaquetes.Clases.Chain
{
    public class DiasValidador : IRangoTiempoValidador
    { 
        public IRangoTiempoValidador Siguiente { get; private set; }

        public void AsignaSiguiente(IRangoTiempoValidador _validador)
        {
            Siguiente = _validador;
        }
        public string ValidaFecha(TimeSpan _diferencia)
        {
            int diff = Math.Abs((int)_diferencia.TotalDays);
            if (diff <= 30) {
                if (diff <= 1)
                    return $"{diff} Día";
                return $"{diff} Días";
            }

            if (Siguiente != null)
                return Siguiente.ValidaFecha(_diferencia);

            return "";
        }
    }
}
