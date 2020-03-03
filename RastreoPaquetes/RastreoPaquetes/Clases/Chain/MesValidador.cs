using RastreoPaquetes.DTO;
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
        public ValidadorDTO ValidaFecha(TimeSpan _diferencia)
        {
            ValidadorDTO _salida = new ValidadorDTO() { Clasificador = "Mes", Texto = "" };
            int diff = Math.Abs((int)_diferencia.TotalDays);
            int meses = diff / 30;
            if (meses == 1)
            {
                _salida.Texto = $"{meses} Mes";
                return _salida;
            }
          
            if (Siguiente != null)
                return Siguiente.ValidaFecha(_diferencia);

            return _salida;
        }
    }
}
