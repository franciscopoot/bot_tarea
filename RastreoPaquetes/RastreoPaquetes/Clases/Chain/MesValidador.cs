using RastreoPaquetes.Interfaces.Chain;
using System;

namespace RastreoPaquetes.Clases.Chain
{
    public class MesValidador : IRangoTiempoValidador
    {
        public IRangoTiempoValidador Siguiente { get; private set; }

        public void AsignaSiguiente(IRangoTiempoValidador _validador)
        {
            Siguiente = _validador;
        }
        public string ValidaFecha(TimeSpan _diferencia)
        {
            int diff = Math.Abs((int)_diferencia.TotalDays);
            int meses = diff / 30;
            if (diff > 30)
            {
                if (meses == 1) {
                    return $"{meses} Mes";
                }
                return $"{meses} Meses";
            }
            if (Siguiente != null)
                return Siguiente.ValidaFecha(_diferencia);

            return "";
        }
    }
}
