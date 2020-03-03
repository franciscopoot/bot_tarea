using RastreoPaquetes.Interfaces;
using RastreoPaquetes.Interfaces.Factory;
using System;
using System.Collections.Generic;
using System.Text;

namespace RastreoPaquetes.Clases.Factory
{
    public class LectorArchivoFactory : ILectorArchivoFactory
    {
        public ILectorArchivo Create(string _nombreExtension)
        {
            ILectorArchivo factory = null;
            switch (_nombreExtension.ToUpper())
            {
                case "CSV": //PedidoEntregado
                    factory = new CsvLectorArchivo();
                    break;
                case "JSON":
                    factory = new JsonLectorArchivo();
                    break;
            }
            return factory;
        }
    }
}
