
using RastreoPaquetes.DTO;
using System;

namespace RastreoPaquetes.Interfaces.Strategy
{
    public interface IPaqueteriaStrategy
    {
        decimal ObtenerCostoServicio(string _nombrePaqueteria,ParametrosPaqueteriaDTO _param);
        DateTime ObtenerFechaEntrega(string _nombrePaqueteria, ParametrosPaqueteriaDTO _param);
        bool ValidaMedioTransporte(string _nombrePaqueteria,string _nombreMedioTransporte);

    }
}
