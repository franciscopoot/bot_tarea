using RastreoPaquetes.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace RastreoPaquetes.Interfaces
{
    public interface IMedioTransporte
    {
        decimal VelocidadEntrega { get; }
        string Nombre { get; }
        decimal ObtieneCostoTransporte(ParametroCalculoMedioTransporteDTO _param);
        decimal ObtieneTiempoTransporte(ParametroCalculoMedioTransporteDTO _param);
    }
}
