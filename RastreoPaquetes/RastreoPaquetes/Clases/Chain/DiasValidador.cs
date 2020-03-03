using RastreoPaquetes.DTO;
using RastreoPaquetes.Interfaces.Chain;
using System;
using System.Collections.Generic;

namespace RastreoPaquetes.Clases.Chain
{
    public class DiasValidador : IRangoTiempoValidador
    {
        public IRangoTiempoValidador Siguiente { get; private set; }

        public void AsignaSiguiente(IRangoTiempoValidador _validador)
        {
            Siguiente = _validador;
        }
        public ValidadorDTO ValidaFecha(TimeSpan _diferencia)
        {
            ValidadorDTO _salida = new ValidadorDTO() { Clasificador = "Dias", Texto = "" };
            int diff = Math.Abs((int)_diferencia.TotalDays);

            if (diff <= 6) {
                if (diff <= 1)
                {
                    _salida.Texto = $"{diff} Día";
                    return _salida;
                }
                _salida.Texto = $"{diff} Días";

                return _salida;
            }

            if (Siguiente != null)
                return Siguiente.ValidaFecha(_diferencia);

            return _salida;
        }
    }
}
