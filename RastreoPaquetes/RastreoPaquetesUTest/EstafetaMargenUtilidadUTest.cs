using Microsoft.VisualStudio.TestTools.UnitTesting;
using RastreoPaquetes.Clases;
using System;
using System.Collections.Generic;
using System.Text;

namespace RastreoPaquetesUTest
{
    [TestClass]
    public class EstafetaMargenUtilidadUTest
    {
        [TestMethod]
        public void ObtenerMargenUtilidad_22Febrero_1punto45()//Invierno
        {
            //Arrange
            var SUT = new EstafetaMargenUtilidad();
            //ACT
            var margen = SUT.ObtenerMargenUtilidad(new DateTime(2020, 2, 22));
            //Assert
            Assert.AreEqual(1.45m, margen);
        }
        [TestMethod]
        public void ObtenerMargenUtilidad_14Febrero_1punto30()//Invierno
        {
            //Arrange
            var SUT = new EstafetaMargenUtilidad();
            //ACT
            var margen = SUT.ObtenerMargenUtilidad(new DateTime(2020, 2, 14));
            //Assert
            Assert.AreEqual(1.10m, margen);
        }
        [TestMethod]
        public void ObtenerMargenUtilidad_15Diciembre_1punto50()//Invierno
        {
            //Arrange
            var SUT = new EstafetaMargenUtilidad();
            //ACT
            var margen = SUT.ObtenerMargenUtilidad(new DateTime(2020, 12, 15));
            //Assert
            Assert.AreEqual(1.50m, margen);
        }

    }
}
