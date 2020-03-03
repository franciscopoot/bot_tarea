using Microsoft.VisualStudio.TestTools.UnitTesting;
using RastreoPaquetes.Clases;
using System;
using System.Collections.Generic;
using System.Text;

namespace RastreoPaquetesUTest
{
    [TestClass]
    public class FedexMargenUtilidadUTest
    {
        [TestMethod]
        public void ObtenerMargenUtilidad_22Febrero_1punto40()//Invierno
        {
            //Arrange
            var SUT = new FedexMargenUtilidad();
            //ACT
            var margen = SUT.ObtenerMargenUtilidad(new DateTime(2020,2,22));
            //Assert
            Assert.AreEqual(1.40m, margen);
        }
        [TestMethod]
        public void ObtenerMargenUtilidad_05Julio_1punto30()//Invierno
        {
            //Arrange
            var SUT = new FedexMargenUtilidad();
            //ACT
            var margen = SUT.ObtenerMargenUtilidad(new DateTime(2020, 7, 5));
            //Assert
            Assert.AreEqual(1.3m, margen);
        }

    }
}
