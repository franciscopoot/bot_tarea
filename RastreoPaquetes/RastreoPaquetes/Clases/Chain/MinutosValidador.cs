using RastreoPaquetes.DTO;
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
        public ValidadorDTO ValidaFecha(TimeSpan _diferencia)
        {
            ValidadorDTO _salida = new ValidadorDTO() { Clasificador = "Minutos", Texto = "" };
            int diff = Math.Abs((int)_diferencia.TotalMinutes);
            if (diff <= 59) {
                if (diff == 1) {
                    _salida.Texto = $"{diff} Minuto";
                    return _salida;
                }

                _salida.Texto = $"{diff} Minutos";
                return _salida;
            }

            if (Siguiente != null)
                return Siguiente.ValidaFecha(_diferencia);
           
            return _salida;
        }
    }
}
