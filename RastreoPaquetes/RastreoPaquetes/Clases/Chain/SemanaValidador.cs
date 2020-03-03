using RastreoPaquetes.DTO;
using RastreoPaquetes.Interfaces.Chain;
using System;
using System.Collections.Generic;
using System.Text;

namespace RastreoPaquetes.Clases.Chain
{
    public class SemanaValidador : IRangoTiempoValidador
    {
        public IRangoTiempoValidador Siguiente { get; private set; }
   
        public void AsignaSiguiente(IRangoTiempoValidador _validador)
        {
            Siguiente = _validador;
        }
        public ValidadorDTO ValidaFecha(TimeSpan _diferencia)
        {
            ValidadorDTO _salida = new ValidadorDTO() { Clasificador = "Semanas", Texto = "" };
            int diff = Math.Abs((int)_diferencia.TotalDays);

            if (diff <= 30)
            {
                int semanas = diff / 7;
                if (semanas <= 1) {
                    _salida.Texto = $"{semanas} Semana";
                    return _salida;
                }
                _salida.Texto = $"{semanas} Semanas";
                return _salida;
            }

            if (Siguiente != null)
                return Siguiente.ValidaFecha(_diferencia);

            return _salida;
        }
    }
}
