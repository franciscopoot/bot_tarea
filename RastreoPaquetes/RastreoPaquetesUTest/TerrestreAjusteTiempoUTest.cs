using Microsoft.VisualStudio.TestTools.UnitTesting;
using RastreoPaquetes.Clases;
using System;

namespace RastreoPaquetesUTest
{
    [TestClass]
    public class TerrestreAjusteTiempoUTest
    {
        [TestMethod]
        public void ObtieneAjustePorEstacion_22Febrero_8()
        {
            //Arrange
            var SUT = new TerrestreAjusteTiempo();
            //ACT
            var ajuste = SUT.ObtieneAjustePorEstacion(new DateTime(2020, 2, 22));
            //Assert
            Assert.AreEqual(8m, ajuste);
        }

        [TestMethod]
        public void ObtieneAjustePorEstacion_10Octubre_5()
        {
            //Arrange
            var SUT = new TerrestreAjusteTiempo();
            //ACT
            var margen = SUT.ObtieneAjustePorEstacion(new DateTime(2020, 10, 10));
            //Assert
            Assert.AreEqual(5m, margen);
        }

        [TestMethod]
        public void ObtieneAjustePorEstacion_10Julio_6()
        {
            //Arrange
            var SUT = new TerrestreAjusteTiempo();
            //ACT
            var margen = SUT.ObtieneAjustePorEstacion(new DateTime(2020, 7, 10));
            //Assert
            Assert.AreEqual(6m, margen);
        }

        [TestMethod]
        public void ObtenerMargenUtilidad_10Marzo_4()
        {
            //Arrange
            var SUT = new TerrestreAjusteTiempo();
            //ACT
            var margen = SUT.ObtieneAjustePorEstacion(new DateTime(2020, 3, 10));
            //Assert
            Assert.AreEqual(4m, margen);
        }

        [TestMethod]
        public void ObtenerMargenUtilidad_12Diciembre2020_8()
        {
            //Arrange
            var SUT = new TerrestreAjusteTiempo();
            //ACT
            var margen = SUT.ObtieneAjustePorEstacion(new DateTime(2020, 12, 12));
            //Assert
            Assert.AreEqual(8m, margen);
        }
    }
}
