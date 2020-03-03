using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RastreoPaquetes.Clases;
using RastreoPaquetes.Clases.Exceptions;
using RastreoPaquetes.Clases.Strategy;
using RastreoPaquetes.DTO;
using RastreoPaquetes.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RastreoPaquetesUTest
{
    [TestClass]
    public class PaqueteriaStrategyUTest
    {
        [TestMethod]
        public void ObtenerPaqueteria_PaqueteriaNoExiste_PaqueteriaException()
        {
            //Arrange
            string textoSalida = "La paqueteria: Alf no se encuentra registrada en nuestra red de distribución.";
            var SUT = new PaqueteriaStrategy(new IPaqueteria[] { });

            //ACT

            //Assert
            Assert.ThrowsException<PaqueteriaException>(()=> SUT.ObtenerPaqueteria("Alf"));
        }

        [TestMethod]
        public void ObtenerCostoServicio_22Febrero1200Maritimo_442punto8()
        {
            //Arrange
            ParametrosPaqueteriaDTO param = new ParametrosPaqueteriaDTO() { FechaPedido = new DateTime(2020, 2, 22), Distancia = 1200, NombreMedioTransporte = "Maritimo" };
            var DOCpaqueteria = new Mock<IPaqueteria>();
            DOCpaqueteria.Setup(doc => doc.Nombre).Returns("Fedex");
            DOCpaqueteria.Setup(doc => doc.ObtenerCostoServicio(param)).Returns(442.80m);
            var SUT = new PaqueteriaStrategy(new IPaqueteria[] {DOCpaqueteria.Object });
            //ACT
            var costo = SUT.ObtenerCostoServicio("Fedex",param);
            //Assert
            Assert.AreEqual(442.8m, costo);
        }

        [TestMethod]
        public void ObtenerFechaEntrega_22Febrero1200Maritimo_442punto8()
        {
            //Arrange
            ParametrosPaqueteriaDTO param = new ParametrosPaqueteriaDTO() { FechaPedido = new DateTime(2020, 2, 22), Distancia = 1200, NombreMedioTransporte = "Maritimo" };
            var DOCpaqueteria = new Mock<IPaqueteria>();
            DOCpaqueteria.Setup(doc => doc.Nombre).Returns("Fedex");
            DOCpaqueteria.Setup(doc => doc.ObtenerFechaEntrega(param)).Returns(param.FechaPedido.AddHours(58.2));
            var SUT = new PaqueteriaStrategy(new IPaqueteria[] { DOCpaqueteria.Object });
            //ACT
            var fechaEntrega = SUT.ObtenerFechaEntrega("Fedex", param);
            //Assert
            Assert.AreEqual(param.FechaPedido.AddHours(58.2), fechaEntrega);
        }

        [TestMethod]
        public void ValidaMedioTransporte_22Febrero1200MaritimoBicicleta_false()
        {
            //Arrange
            ParametrosPaqueteriaDTO param = new ParametrosPaqueteriaDTO() { FechaPedido = new DateTime(2020, 2, 22), Distancia = 1200, NombreMedioTransporte = "Maritimo" };
            var DOCpaqueteria = new Mock<IPaqueteria>();
            DOCpaqueteria.Setup(doc => doc.Nombre).Returns("Fedex");
            DOCpaqueteria.Setup(doc => doc.ObtenerFechaEntrega(param)).Returns(param.FechaPedido.AddHours(58.2));
            var SUT = new PaqueteriaStrategy(new IPaqueteria[] { DOCpaqueteria.Object });
            //ACT
            var valida = SUT.ValidaMedioTransporte("Fedex", "Bicicleta");
            //Assert
            Assert.AreEqual(false, valida);
        }

    }
}
