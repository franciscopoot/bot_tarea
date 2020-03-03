using RastreoPaquetes.DTO;
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
        public ValidadorDTO ValidaFecha(TimeSpan _diferencia)
        {
            ValidadorDTO _salida = new ValidadorDTO() { Clasificador = "Horas", Texto = "" };
            int diff = Math.Abs((int)_diferencia.TotalHours);
            if (diff <= 23) {
                if (diff == 1) {
                    _salida.Texto = $"{diff} Hora";
                    return _salida;
                }
                    _salida.Texto = $"{diff} Horas";
                return _salida;
            }

            if (Siguiente != null)
                return Siguiente.ValidaFecha(_diferencia);

            return _salida;
        }
    }
}
