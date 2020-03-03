using System;
using System.Collections.Generic;
using System.Text;

namespace RastreoPaquetes.Interfaces.Factory
{
    public interface ILectorArchivoFactory
    {
        ILectorArchivo Create(string _nombreExtension);
    }
}
