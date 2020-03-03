using RastreoPaquetes.Clases.Exceptions;
using RastreoPaquetes.DTO;
using RastreoPaquetes.Interfaces;
using RastreoPaquetes.Interfaces.Strategy;
using System;
using System.Linq;

namespace RastreoPaquetes.Clases.Strategy
{
    public class PaqueteriaStrategy : IPaqueteriaStrategy
    {
        private readonly IPaqueteria[] LstPaqueterias;
        public PaqueteriaStrategy(IPaqueteria[] _lstPaqueterias) {
            LstPaqueterias = _lstPaqueterias;
        }

        public decimal ObtenerCostoServicio(string _nombrePaqueteria, ParametrosPaqueteriaDTO _param) {

            var paqueteria = ObtenerPaqueteria(_nombrePaqueteria);
            return paqueteria.ObtenerCostoServicio(_param);
        }
        public DateTime ObtenerFechaEntrega(string _nombrePaqueteria, ParametrosPaqueteriaDTO _param)
        {
            var paqueteria = ObtenerPaqueteria(_nombrePaqueteria);
            return paqueteria.ObtenerFechaEntrega(_param);
        }

        public bool ValidaMedioTransporte(string _nombrePaqueteria, string _nombreMedioTransporte)
        {
            var paqueteria = ObtenerPaqueteria(_nombrePaqueteria);
            return paqueteria.ValidaMedioTransporte(_nombreMedioTransporte);
        }

        public IPaqueteria ObtenerPaqueteria(string _nombrePaqueteria)
        {
            var paqueteria = LstPaqueterias.FirstOrDefault(f => f.Nombre.ToUpper() == _nombrePaqueteria.ToUpper());
            if (paqueteria == null)
                throw new PaqueteriaException($"La paqueteria: {_nombrePaqueteria} no se encuentra registrada en nuestra red de distribución.");
            return paqueteria;
        }
    }
}
