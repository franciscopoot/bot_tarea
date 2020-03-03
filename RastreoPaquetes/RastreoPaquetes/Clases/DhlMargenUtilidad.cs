using RastreoPaquetes.Interfaces;
using RastreoPaquetes.Map;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace RastreoPaquetes.Clases
{
    public class DhlMargenUtilidad : IMargenUtilidad
    {
        readonly List<MargenUtilidadDTO> MargenUtlidad;
        public DhlMargenUtilidad(List<MargenUtilidadDTO> _margenUtlidad) {
            MargenUtlidad = _margenUtlidad;
        }
        public decimal ObtenerMargenUtilidad(DateTime _fechaCompra)
        {
            int NumeroMes = _fechaCompra.Month;
            string busqueda = "SEMESTRE_2";
            if (NumeroMes <= 6)
                busqueda = "SEMESTRE_1";

            var margenUtilidad = MargenUtlidad.FirstOrDefault(f => f.Periodo.Equals(busqueda));
            return margenUtilidad != null ? 1+ margenUtilidad.Porcentaje : 1;
        }
    }
}
