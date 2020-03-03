using RastreoPaquetes.DTO;
using RastreoPaquetes.Interfaces.Chain;
using System;
using System.Collections.Generic;
using System.Text;

namespace RastreoPaquetes.Clases.Chain
{
    public class BimestreValidador : IRangoTiempoValidador
    {
        public IRangoTiempoValidador Siguiente { get; private set; }

        public void AsignaSiguiente(IRangoTiempoValidador _validador)
        {
            Siguiente = _validador;
        }
        public ValidadorDTO ValidaFecha(TimeSpan _diferencia)
        {
            ValidadorDTO _salida = new ValidadorDTO() { Clasificador = "Bimestre", Texto = "" };
            int diff = Math.Abs((int)_diferencia.TotalDays);
            int meses = diff / 30;
            int bimestres = meses / 2;
            if (bimestres <= 6)
            {
                if (bimestres == 1)
                {
                    _salida.Texto = $"{bimestres} Bimestre";
                    return _salida;
                }
                _salida.Texto = $"{bimestres} Bimestres";
                return _salida;
            }
            if (Siguiente != null)
                return Siguiente.ValidaFecha(_diferencia);

            return _salida;
        }
    }
}
