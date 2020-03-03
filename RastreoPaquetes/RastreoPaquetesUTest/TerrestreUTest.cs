using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RastreoPaquetes.Clases;
using RastreoPaquetes.DTO;
using RastreoPaquetes.Interfaces;
using System;
using System.Collections.Generic;

namespace RastreoPaquetesUTest
{
    [TestClass]
    public class TerrestreUTest
    {
        [TestMethod]
        public void ObtieneCostoTransporte_22Febrero1200_8400()//Invierno
        {
            //Arrange
            ParametroCalculoMedioTransporteDTO param = new ParametroCalculoMedioTransporteDTO() { FechaCompra = new DateTime(2020, 2, 22), Distancia = 1200 };
            List<RangoCosto> lstCostos = new List<RangoCosto>() { new RangoCosto(1m, 50m, 15m), new RangoCosto(51m, 200m, 10m), new RangoCosto(201m, 300, 8m), new RangoCosto(301m, null, 7m) };
            var DOCajusteTiempo = new Mock<IAjusteExtra>();
            DOCajusteTiempo.Setup(doc => doc.ObtieneAjustePorEstacion(param.FechaCompra)).Returns(0);
            var SUT = new Terrestre(lstCostos,DOCajusteTiempo.Object);
            //ACT
            var costo = SUT.ObtieneCostoTransporte(param);
            //Assert
            Assert.AreEqual(8400m, costo);
        }

        [TestMethod]
        public void ObtieneCostoTransporte_10Octubre250_2000()//Otoño
        {
            //Arrange
            ParametroCalculoMedioTransporteDTO param = new ParametroCalculoMedioTransporteDTO() { FechaCompra = new DateTime(2020, 10, 10), Distancia = 250 };
            List<RangoCosto> lstCostos = new List<RangoCosto>() { new RangoCosto(1m, 50m, 15m), new RangoCosto(51m, 200m, 10m), new RangoCosto(201m, 300, 8m), new RangoCosto(301m, null, 7m) };
            var DOCajusteTiempo = new Mock<IAjusteExtra>();
            DOCajusteTiempo.Setup(doc => doc.ObtieneAjustePorEstacion(param.FechaCompra)).Returns(0);
            var SUT = new Terrestre(lstCostos, DOCajusteTiempo.Object);
            //ACT
            var costo = SUT.ObtieneCostoTransporte(param);
            //Assert
            Assert.AreEqual(2000m, costo);
        }

        [TestMethod]
        public void ObtieneCostoTransporte_10Julio25_375()//Verano
        {
            //Arrange
            ParametroCalculoMedioTransporteDTO param = new ParametroCalculoMedioTransporteDTO() { FechaCompra = new DateTime(2020, 7, 10), Distancia = 25 };
            List<RangoCosto> lstCostos = new List<RangoCosto>() { new RangoCosto(1m, 50m, 15m), new RangoCosto(51m, 200m, 10m), new RangoCosto(201m, 300, 8m), new RangoCosto(301m, null, 7m) };
            var DOCajusteTiempo = new Mock<IAjusteExtra>();
            DOCajusteTiempo.Setup(doc => doc.ObtieneAjustePorEstacion(param.FechaCompra)).Returns(0);
            var SUT = new Terrestre(lstCostos, DOCajusteTiempo.Object);
            //ACT
            var costo = SUT.ObtieneCostoTransporte(param);
            //Assert
            Assert.AreEqual(375m, costo);
        }

        [TestMethod]
        public void ObtieneTiempoTransporte_22Febrero11592_192()
        {
            //Arrange
            ParametroCalculoMedioTransporteDTO param = new ParametroCalculoMedioTransporteDTO() { FechaCompra = new DateTime(2020, 2, 22), Distancia = 11520 };
            List<RangoCosto> lstCostos = new List<RangoCosto>() { new RangoCosto(1m, 50m, 15m), new RangoCosto(51m, 200m, 10m), new RangoCosto(201m, 300, 8m), new RangoCosto(301m, null, 7m) };
            var DOCajusteTiempo = new Mock<IAjusteExtra>();
            DOCajusteTiempo.Setup(doc => doc.ObtieneAjustePorEstacion(param.FechaCompra)).Returns(8);
            var SUT = new Terrestre(lstCostos, DOCajusteTiempo.Object);
            //ACT
            var costo = SUT.ObtieneTiempoTransporte(param);
            //Assert
            Assert.AreEqual(192m, costo);
        }

    }
}
