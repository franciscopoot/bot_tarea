using RastreoPaquetes.Interfaces.Chain;
using System;


namespace RastreoPaquetes.Clases.Chain
{
    public class MinutosValidador : IRangoTiempoValidador
    {
        public IRangoTiempoValidador Siguiente { get; private set; }

        public void AsignaSiguiente(IRangoTiempoValidador _validador)
        {
            Siguiente = _validador;
        }
        public string ValidaFecha(TimeSpan _diferencia)
        {
            int diff = Math.Abs((int)_diferencia.TotalMinutes);
            if (diff <= 59) {
                if(diff == 1)
                    return $"{diff} Minuto";

                return $"{diff} Minutos";
            }

            if (Siguiente != null)
                return Siguiente.ValidaFecha(_diferencia);
           
            return "";
        }
    }
}
