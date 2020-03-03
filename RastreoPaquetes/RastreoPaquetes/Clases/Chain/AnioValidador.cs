using RastreoPaquetes.DTO;
using RastreoPaquetes.Interfaces.Chain;
using System;
using System.Collections.Generic;
using System.Text;

namespace RastreoPaquetes.Clases.Chain
{
    public class AnioValidador : IRangoTiempoValidador
    {
        public IRangoTiempoValidador Siguiente { get; private set; }

        public void AsignaSiguiente(IRangoTiempoValidador _validador)
        {
            Siguiente = _validador;
        }
        public ValidadorDTO ValidaFecha(TimeSpan _diferencia)
        {
            ValidadorDTO _salida = new ValidadorDTO() { Clasificador="Anios",Texto=""};
            int diff = Math.Abs((int)_diferencia.TotalDays);
            int meses = diff / 30;
            int bimestres = meses / 2;
          
            if (bimestres > 7)
            {
                int anio = bimestres / 6;

                if (anio == 1)
                {
                    _salida.Texto = $"{anio} Año";
                    return _salida;
                }
                _salida.Texto = $"{anio} Años";
                return _salida;
            }
            if (Siguiente != null)
                return Siguiente.ValidaFecha(_diferencia);

            return _salida;
        }
    }
}
