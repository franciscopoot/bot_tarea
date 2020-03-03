using RastreoPaquetes.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RastreoPaquetes.Clases
{
    public class EstafetaMargenUtilidad : IMargenUtilidad
    {
        public decimal ObtenerMargenUtilidad(DateTime _fechaCompra)
        {
            int NumeroMes = _fechaCompra.Month;
            int DiaMes = _fechaCompra.Day;
            if (NumeroMes == 12) // Es diciembre
                return 1.50m;
            if (NumeroMes == 2 && DiaMes ==14)
                return 1.10m;
            
            return 1.45m;
        }
    }
}
