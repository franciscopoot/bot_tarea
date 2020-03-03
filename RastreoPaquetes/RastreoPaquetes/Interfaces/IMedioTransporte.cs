using RastreoPaquetes.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace RastreoPaquetes.Interfaces
{
    public interface IMedioTransporte
    {
        decimal VelocidadEntrega { get; set; }
        string Nombre { get; set; }
        decimal ObtieneCostoTransporte(ParametroCalculoMedioTransporteDTO _param);
        decimal ObtieneTiempoTransporte(ParametroCalculoMedioTransporteDTO _param);
    }
}
