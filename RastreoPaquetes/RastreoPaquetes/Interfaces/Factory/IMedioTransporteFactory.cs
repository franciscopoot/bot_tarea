using RastreoPaquetes.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace RastreoPaquetes.Interfaces.Factory
{
    public interface IMedioTransporteFactory
    {
        IMedioTransporte Create(string _medioTransporte);
    }
}
