using RastreoPaquetes.Interfaces;
using RastreoPaquetes.Map;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace RastreoPaquetes.Clases
{
    public class FedexMargenUtilidad : IMargenUtilidad
    {     
        readonly List<MargenUtilidadDTO> MargenUtlidad;
        public FedexMargenUtilidad(List<MargenUtilidadDTO> _margenUtlidad) {
            MargenUtlidad = _margenUtlidad;
        }
        public decimal ObtenerMargenUtilidad(DateTime _fechaCompra)
        {
            int NumeroMes = _fechaCompra.Month;
            string busqueda = "MESES_IMPARES";
            if (NumeroMes % 2 == 0)
                busqueda = "MESES_PARES";

            var margenUtilidad = MargenUtlidad.FirstOrDefault(f => f.Periodo.Equals(busqueda));
            return margenUtilidad != null? 1+ margenUtilidad.Porcentaje: 1;
        }
    }
}
