using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RastreoPaquetes.Clases;
using RastreoPaquetes.DTO;
using RastreoPaquetes.Interfaces;
using System;

namespace RastreoPaquetesUTest
{
    [TestClass]
    public class DhlUTest
    {
        [TestMethod]
        public void ObtenerCostoServicio_22Febrero1200Maritimo_664punto2()//Invierno
        {
            //Arrange
            ParametrosPaqueteriaDTO param = new ParametrosPaqueteriaDTO() { FechaPedido = new DateTime(2020, 2, 22), Distancia = 1200, NombreMedioTransporte = "Maritimo" };

            var DOCcalculaCostoTransporte = new Mock<IMedioTransporte>();

            DOCcalculaCostoTransporte.Setup(doc => doc.Nombre).Returns("Maritimo");
            DOCcalculaCostoTransporte.Setup(doc => doc.ObtieneCostoTransporte(It.IsAny<ParametroCalculoMedioTransporteDTO>())).Returns(442.80m);
            IMedioTransporte[] mediosTransporteFedex = { DOCcalculaCostoTransporte.Object };

            var DOCmargenUtilidad = new Mock<IMargenUtilidad>();
            DOCmargenUtilidad.Setup(doc => doc.ObtenerMargenUtilidad(param.FechaPedido)).Returns(1.5m);

            var SUT = new Dhl(mediosTransporteFedex, DOCmargenUtilidad.Object);
            //ACT
            var costo = SUT.ObtenerCostoServicio(param);
            //Assert
            Assert.AreEqual(664.2m, costo);
        }

        [TestMethod]
        public void ObtenerFechaEntrega_22Febrero1200Maritimo_FechaPedidoMas57punto2hrs()
        {
            //Arrange
            ParametrosPaqueteriaDTO param = new ParametrosPaqueteriaDTO() { FechaPedido = new DateTime(2020, 2, 22), Distancia = 1200, NombreMedioTransporte = "Maritimo" };

            var DOCcalculaCostoTransporte = new Mock<IMedioTransporte>();

            DOCcalculaCostoTransporte.Setup(doc => doc.Nombre).Returns("Maritimo");
            DOCcalculaCostoTransporte.Setup(doc => doc.ObtieneTiempoTransporte(It.IsAny<ParametroCalculoMedioTransporteDTO>())).Returns(37.2m);
            IMedioTransporte[] mediosTransporteFedex = { DOCcalculaCostoTransporte.Object };

            var DOCmargenUtilidad = new Mock<IMargenUtilidad>();
            DOCmargenUtilidad.Setup(doc => doc.ObtenerMargenUtilidad(param.FechaPedido)).Returns(1.5m);

            var SUT = new Dhl(mediosTransporteFedex, DOCmargenUtilidad.Object);
            //ACT
            var fechaEntrega = SUT.ObtenerFechaEntrega(param);
            //Assert
            Assert.AreEqual(param.FechaPedido.AddHours(57.2), fechaEntrega);
        }

        [TestMethod]
        public void ValidaMedioTransporte_MedioNoExiste_false()
        {
            //Arrange
            ParametrosPaqueteriaDTO param = new ParametrosPaqueteriaDTO() { FechaPedido = new DateTime(2020, 2, 22), Distancia = 1200, NombreMedioTransporte = "Maritimo" };
            var DOCcalculaCostoTransporteTerrestre = new Mock<IMedioTransporte>();
            DOCcalculaCostoTransporteTerrestre.Setup(doc => doc.Nombre).Returns("Terrestre");
            var DOCcalculaCostoTransporteMaritimo = new Mock<IMedioTransporte>();
            DOCcalculaCostoTransporteMaritimo.Setup(doc => doc.Nombre).Returns("Maritimo");
            var DOCcalculaCostoTransporteAreo = new Mock<IMedioTransporte>();
            DOCcalculaCostoTransporteAreo.Setup(doc => doc.Nombre).Returns("Aereo");
            IMedioTransporte[] mediosTransporteFedex = { DOCcalculaCostoTransporteTerrestre.Object, DOCcalculaCostoTransporteMaritimo.Object, DOCcalculaCostoTransporteAreo.Object };

            var DOCmargenUtilidad = new Mock<IMargenUtilidad>();
            DOCmargenUtilidad.Setup(doc => doc.ObtenerMargenUtilidad(param.FechaPedido)).Returns(1.5m);

            var SUT = new Dhl(mediosTransporteFedex, DOCmargenUtilidad.Object);
            //ACT
            var valida = SUT.ValidaMedioTransporte("Bicicleta");
            //Assert
            Assert.AreEqual(false, valida);
        }
        [TestMethod]
        public void ValidaMedioTransporte_Terrestre_true()
        {
            //Arrange
            ParametrosPaqueteriaDTO param = new ParametrosPaqueteriaDTO() { FechaPedido = new DateTime(2020, 2, 22), Distancia = 1200, NombreMedioTransporte = "Maritimo" };
            var DOCcalculaCostoTransporteTerrestre = new Mock<IMedioTransporte>();
            DOCcalculaCostoTransporteTerrestre.Setup(doc => doc.Nombre).Returns("Terrestre");
            var DOCcalculaCostoTransporteMaritimo = new Mock<IMedioTransporte>();
            DOCcalculaCostoTransporteMaritimo.Setup(doc => doc.Nombre).Returns("Maritimo");
            var DOCcalculaCostoTransporteAreo = new Mock<IMedioTransporte>();
            DOCcalculaCostoTransporteAreo.Setup(doc => doc.Nombre).Returns("Aereo");
            IMedioTransporte[] mediosTransporteFedex = { DOCcalculaCostoTransporteTerrestre.Object, DOCcalculaCostoTransporteMaritimo.Object, DOCcalculaCostoTransporteAreo.Object };

            var DOCmargenUtilidad = new Mock<IMargenUtilidad>();
            DOCmargenUtilidad.Setup(doc => doc.ObtenerMargenUtilidad(param.FechaPedido)).Returns(1.5m);

            var SUT = new Dhl(mediosTransporteFedex, DOCmargenUtilidad.Object);
            //ACT
            var valida = SUT.ValidaMedioTransporte("Terrestre");
            //Assert
            Assert.AreEqual(true, valida);
        }

    }
}
