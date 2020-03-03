using Microsoft.VisualStudio.TestTools.UnitTesting;
using RastreoPaquetes.Clases;
using System;
using System.Collections.Generic;
using System.Text;

namespace RastreoPaquetesUTest
{
    [TestClass]
    public class DhlMargenUtilidadUTest
    {

        [TestMethod]
        public void ObtenerMargenUtilidad_1Enero_1punto50()
        {
            //Arrange
            var SUT = new DhlMargenUtilidad();
            //ACT
            var margen = SUT.ObtenerMargenUtilidad(new DateTime(2020, 1, 1));
            //Assert
            Assert.AreEqual(1.50m, margen);
        }
        [TestMethod]
        public void ObtenerMargenUtilidad_05Junio_1punto50()
        {
            //Arrange
            var SUT = new DhlMargenUtilidad();
            //ACT
            var margen = SUT.ObtenerMargenUtilidad(new DateTime(2020, 6, 5));
            //Assert
            Assert.AreEqual(1.5m, margen);
        }

        [TestMethod]
        public void ObtenerMargenUtilidad_15Septiembe_1punto30()
        {
            //Arrange
            var SUT = new DhlMargenUtilidad();
            //ACT
            var margen = SUT.ObtenerMargenUtilidad(new DateTime(2020, 9, 15));
            //Assert
            Assert.AreEqual(1.3m, margen);
        }

        [TestMethod]
        public void ObtenerMargenUtilidad_31Diciembre_1punto30()
        {
            //Arrange
            var SUT = new DhlMargenUtilidad();
            //ACT
            var margen = SUT.ObtenerMargenUtilidad(new DateTime(2020, 12, 31));
            //Assert
            Assert.AreEqual(1.3m, margen);
        }
    }
}
