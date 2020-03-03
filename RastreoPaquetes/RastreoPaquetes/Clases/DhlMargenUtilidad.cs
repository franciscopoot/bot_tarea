using RastreoPaquetes.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RastreoPaquetes.Clases
{
    public class DhlMargenUtilidad : IMargenUtilidad
    {
        public decimal ObtenerMargenUtilidad(DateTime _fechaCompra)
        {
            int NumeroMes = _fechaCompra.Month;
            if (NumeroMes <= 6)
                return 1.50m;
            return 1.30m;
        }
    }
}
