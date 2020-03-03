using RastreoPaquetes.DTO;
using System;
using System.Collections.Generic;

namespace RastreoPaquetes.Interfaces
{
    public interface IPaqueteria
    {
        string Nombre { get; }
        IMedioTransporte[] LstMediosTransporte { get; }
        Dictionary<string, decimal> TiempoReparto { get; }
        decimal ObtenerCostoServicio(ParametrosPaqueteriaDTO _param);
        DateTime ObtenerFechaEntrega(ParametrosPaqueteriaDTO _param);
        bool ValidaMedioTransporte (string _nombreMedioTransporte);
    }
}
