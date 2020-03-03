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
    public class MaritimoUtest
    {
        [TestMethod]
        public void ObtieneCostoTransporte_22Febrero1200_442punto8()//Invierno
        {
            //Arrange
            ParametroCalculoMedioTransporteDTO param = new ParametroCalculoMedioTransporteDTO() { FechaCompra = new DateTime(2020, 2, 22), Distancia = 1200 };
            List<RangoCosto> lstCostos = new List<RangoCosto>() { new RangoCosto(1m, 100m, 1m), new RangoCosto(101m, 1000m, 0.5m), new RangoCosto(1001, null, 0.3m) };
            var DOCajusteCosto = new Mock<IAjusteExtra>();
            var DOCajusteTiempo = new Mock<IAjusteExtra>();
            DOCajusteCosto.Setup(doc => doc.ObtieneAjustePorEstacion(param.FechaCompra)).Returns(1.23m);
            DOCajusteTiempo.Setup(doc => doc.ObtieneAjustePorEstacion(It.IsAny<DateTime>())).Returns(0);
            var SUT = new Maritimo(lstCostos,DOCajusteCosto.Object,DOCajusteTiempo.Object);
            //ACT
            var costo = SUT.ObtieneCostoTransporte(param);
            //Assert
            Assert.AreEqual(442.8m,costo);
        }

        [TestMethod]
        public void ObtieneCostoTransporte_10Octubre1200_414()//Otoño
        {
            //Arrange
            ParametroCalculoMedioTransporteDTO param = new ParametroCalculoMedioTransporteDTO() { FechaCompra = new DateTime(2020, 10, 10), Distancia = 1200 };
            List<RangoCosto> lstCostos = new List<RangoCosto>() { new RangoCosto(1m, 100m, 1m), new RangoCosto(101m, 1000m, 0.5m), new RangoCosto(1001, null, 0.3m) };
            var DOCajusteCosto = new Mock<IAjusteExtra>();
            var DOCajusteTiempo = new Mock<IAjusteExtra>();
            DOCajusteCosto.Setup(doc => doc.ObtieneAjustePorEstacion(param.FechaCompra)).Returns(1.15m);
            DOCajusteTiempo.Setup(doc => doc.ObtieneAjustePorEstacion(It.IsAny<DateTime>())).Returns(0);
            var SUT = new Maritimo(lstCostos, DOCajusteCosto.Object, DOCajusteTiempo.Object);
            //ACT
            var costo = SUT.ObtieneCostoTransporte(param);
            //Assert
            Assert.AreEqual(414m, costo);
        }

        [TestMethod]
        public void ObtieneCostoTransporte_10Julio1000_550()//Verano
        {
            //Arrange
            ParametroCalculoMedioTransporteDTO param = new ParametroCalculoMedioTransporteDTO() { FechaCompra = new DateTime(2020, 7, 10), Distancia = 1000 };
            List<RangoCosto> lstCostos = new List<RangoCosto>() { new RangoCosto(1m, 100m, 1m), new RangoCosto(101m, 1000m, 0.5m), new RangoCosto(1001, null, 0.3m) };
            var DOCajusteCosto = new Mock<IAjusteExtra>();
            var DOCajusteTiempo = new Mock<IAjusteExtra>();
            DOCajusteCosto.Setup(doc => doc.ObtieneAjustePorEstacion(param.FechaCompra)).Returns(1.10m);
            DOCajusteTiempo.Setup(doc => doc.ObtieneAjustePorEstacion(It.IsAny<DateTime>())).Returns(0);
            var SUT = new Maritimo(lstCostos, DOCajusteCosto.Object, DOCajusteTiempo.Object);
            //ACT
            var costo = SUT.ObtieneCostoTransporte(param);
            //Assert
            Assert.AreEqual(550m, costo);
        }

        [TestMethod]
        public void ObtieneCostoTransporte_10Marzo1000_500()//Primavera
        {
            //Arrange
            ParametroCalculoMedioTransporteDTO param = new ParametroCalculoMedioTransporteDTO() { FechaCompra = new DateTime(2020, 3, 10), Distancia = 1000 };
            List<RangoCosto> lstCostos = new List<RangoCosto>() { new RangoCosto(1m, 100m, 1m), new RangoCosto(101m, 1000m, 0.5m), new RangoCosto(1001, null, 0.3m) };
            var DOCajusteCosto = new Mock<IAjusteExtra>();
            var DOCajusteTiempo = new Mock<IAjusteExtra>();
            DOCajusteCosto.Setup(doc => doc.ObtieneAjustePorEstacion(param.FechaCompra)).Returns(1m);
            DOCajusteTiempo.Setup(doc => doc.ObtieneAjustePorEstacion(It.IsAny<DateTime>())).Returns(0);
            var SUT = new Maritimo(lstCostos, DOCajusteCosto.Object, DOCajusteTiempo.Object);
            //ACT
            var costo = SUT.ObtieneCostoTransporte(param);
            //Assert
            Assert.AreEqual(500m, costo);
        }

        [TestMethod]
        public void ObtieneCostoTransporte_10Julio99_108punto9()//Verano
        {
            //Arrange
            ParametroCalculoMedioTransporteDTO param = new ParametroCalculoMedioTransporteDTO() { FechaCompra = new DateTime(2020, 7, 10), Distancia = 99 };
            List<RangoCosto> lstCostos = new List<RangoCosto>() { new RangoCosto(1m, 100m, 1m), new RangoCosto(101m, 1000m, 0.5m), new RangoCosto(1001, null, 0.3m) };
            var DOCajusteCosto = new Mock<IAjusteExtra>();
            var DOCajusteTiempo = new Mock<IAjusteExtra>();
            DOCajusteCosto.Setup(doc => doc.ObtieneAjustePorEstacion(param.FechaCompra)).Returns(1.10m);
            DOCajusteTiempo.Setup(doc => doc.ObtieneAjustePorEstacion(It.IsAny<DateTime>())).Returns(0);
            var SUT = new Maritimo(lstCostos, DOCajusteCosto.Object, DOCajusteTiempo.Object);
            //ACT
            var costo = SUT.ObtieneCostoTransporte(param);
            //Assert
            Assert.AreEqual(108.9m, costo);
        }

        [TestMethod]
        public void ObtieneTiempoTransporte_22Febrero1200_37punto2()//Verano
        {
            //Arrange
            ParametroCalculoMedioTransporteDTO param = new ParametroCalculoMedioTransporteDTO() { FechaCompra = new DateTime(2020, 2, 22), Distancia = 1200 };
            List<RangoCosto> lstCostos = new List<RangoCosto>() { new RangoCosto(1m, 100m, 1m), new RangoCosto(101m, 1000m, 0.5m), new RangoCosto(1001, null, 0.3m) };
            var DOCajusteCosto = new Mock<IAjusteExtra>();
            var DOCajusteTiempo = new Mock<IAjusteExtra>();
            DOCajusteCosto.Setup(doc => doc.ObtieneAjustePorEstacion(param.FechaCompra)).Returns(0);
            DOCajusteTiempo.Setup(doc => doc.ObtieneAjustePorEstacion(It.IsAny<DateTime>())).Returns(-0.3m);
            var SUT = new Maritimo(lstCostos, DOCajusteCosto.Object, DOCajusteTiempo.Object);
            //ACT
            var costo = SUT.ObtieneTiempoTransporte(param);
            //Assert
            Assert.AreEqual(37.27m, costo);
        }
    }
}
