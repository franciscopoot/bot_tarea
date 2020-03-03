using Microsoft.VisualStudio.TestTools.UnitTesting;
using RastreoPaquetes.Clases;
using System;


namespace RastreoPaquetesUTest
{
    [TestClass]
    public class MaritimoAjusteCostoUTest
    {
        [TestMethod]
        public void ObtieneAjustePorEstacion_22Febrero_Menos0punto3()//Invierno
        {
            //Arrange
            var SUT = new MaritimoAjusteCosto();
            //ACT
            var margen = SUT.ObtieneAjustePorEstacion(new DateTime(2020, 2, 22));
            //Assert
            Assert.AreEqual(1.23m, margen);
        }
        [TestMethod]
        public void ObtieneAjustePorEstacion_10Octubre_0punto15()//Invierno
        {
            //Arrange
            var SUT = new MaritimoAjusteCosto();
            //ACT
            var margen = SUT.ObtieneAjustePorEstacion(new DateTime(2020, 10, 10));
            //Assert
            Assert.AreEqual(1.15m, margen);
        }

        [TestMethod]
        public void ObtieneAjustePorEstacion_10Julio_Menos0punto1()//Invierno
        {
            //Arrange
            var SUT = new MaritimoAjusteCosto();
            //ACT
            var margen = SUT.ObtieneAjustePorEstacion(new DateTime(2020, 7, 10));
            //Assert
            Assert.AreEqual(1.10m, margen);
        }
        [TestMethod]
        public void ObtieneAjustePorEstacion_10Marzo_Cero()//Invierno
        {
            //Arrange
            var SUT = new MaritimoAjusteCosto();
            //ACT
            var margen = SUT.ObtieneAjustePorEstacion(new DateTime(2020, 3, 10));
            //Assert
            Assert.AreEqual(1m, margen);
        }
    }
}
