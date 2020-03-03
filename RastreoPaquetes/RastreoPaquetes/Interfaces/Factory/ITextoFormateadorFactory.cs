using RastreoPaquetes.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace RastreoPaquetes.Interfaces.Factory
{
    public interface ITextoFormateadorFactory
    {
        ITextoFormateador Create(TextoFormateadorEnum _tipo);
    }
}
