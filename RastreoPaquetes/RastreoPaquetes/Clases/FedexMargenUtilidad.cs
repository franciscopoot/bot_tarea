using RastreoPaquetes.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RastreoPaquetes.Clases
{
    public class FedexMargenUtilidad : IMargenUtilidad
    {
        public decimal ObtenerMargenUtilidad(DateTime _fechaCompra)
        {
            int NumeroMes = _fechaCompra.Month;
            if (NumeroMes % 2 == 0)
                return 1.40m;
            else
                return 1.30m;
        }
    }
}
