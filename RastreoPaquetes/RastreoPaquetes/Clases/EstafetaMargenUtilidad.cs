using RastreoPaquetes.Interfaces;
using RastreoPaquetes.Map;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace RastreoPaquetes.Clases
{
    public class EstafetaMargenUtilidad : IMargenUtilidad
    {
        readonly List<MargenUtilidadDTO> MargenUtlidad;
        public EstafetaMargenUtilidad(List<MargenUtilidadDTO> _margenUtlidad) {
            MargenUtlidad = _margenUtlidad;
        }
        public decimal ObtenerMargenUtilidad(DateTime _fechaCompra)
        {
            int NumeroMes = _fechaCompra.Month;
            string busqueda = "GENERAL";
            int DiaMes = _fechaCompra.Day;
            if (NumeroMes == 12) // Es diciembre
                busqueda = "TEMPORADA_ALTA";
            if (NumeroMes == 2 && DiaMes == 14)
                busqueda = "TEMPORADA_BAJA";

            var margenUtilidad = MargenUtlidad.FirstOrDefault(f => f.Periodo.Equals(busqueda));
            return margenUtilidad != null ? 1 + margenUtilidad.Porcentaje : 1;
        }
    }
}
