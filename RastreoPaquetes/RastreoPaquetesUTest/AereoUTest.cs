using Microsoft.VisualStudio.TestTools.UnitTesting;
using RastreoPaquetes.Clases;
using RastreoPaquetes.DTO;
using System;
using System.Collections.Generic;

namespace RastreoPaquetesUTest
{
    [TestClass]
    public class AereoUTest
    {
        [TestMethod]
        public void ObtieneCostoTransporte_22Febrero1200_12200()//Invierno
        {
            //Arrange
            ParametroCalculoMedioTransporteDTO param = new ParametroCalculoMedioTransporteDTO() { FechaCompra = new DateTime(2020, 2, 22), Distancia = 1200 };
            List<RangoCosto> lstCostos = new List<RangoCosto>() { new RangoCosto(1m, null, 10m) };
            var SUT = new Aereo(lstCostos);
            //ACT
            var costo = SUT.ObtieneCostoTransporte(param);
            //Assert
            Assert.AreEqual(12200m, costo);
        }

        [TestMethod]
        public void ObtieneCostoTransporte_10Octubre800_8000()//Otoño
        {
            //Arrange
            ParametroCalculoMedioTransporteDTO param = new ParametroCalculoMedioTransporteDTO() { FechaCompra = new DateTime(2020, 10, 10), Distancia = 800 };
            List<RangoCosto> lstCostos = new List<RangoCosto>() { new RangoCosto(1m, null, 10m) };
            
            var SUT = new Aereo(lstCostos);
            //ACT
            var costo = SUT.ObtieneCostoTransporte(param);
            //Assert
            Assert.AreEqual(8000m, costo);
        }

        [TestMethod]
        public void ObtieneTiempoTransporte_22Febrero1200_8()
        {
            //Arrange
            ParametroCalculoMedioTransporteDTO param = new ParametroCalculoMedioTransporteDTO() { FechaCompra = new DateTime(2020, 2, 22), Distancia = 1200 };
            List<RangoCosto> lstCostos = new List<RangoCosto>() { new RangoCosto(1m, null, 10m) };

            var SUT = new Aereo(lstCostos);
            //ACT
            var costo = SUT.ObtieneTiempoTransporte(param);
            //Assert
            Assert.AreEqual(8m, costo);
        }
    }
}
