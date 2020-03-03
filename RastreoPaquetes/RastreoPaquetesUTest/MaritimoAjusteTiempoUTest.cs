using Microsoft.VisualStudio.TestTools.UnitTesting;
using RastreoPaquetes.Clases;
using System;
using System.Collections.Generic;
using System.Text;

namespace RastreoPaquetesUTest
{
    [TestClass]
    public class MaritimoAjusteTiempoUTest
    {
        [TestMethod]
        public void ObtieneAjustePorEstacion_22Febrero_Menos0punto3()//Invierno
        {
            //Arrange
            var SUT = new MaritimoAjusteTiempo();
            //ACT
            var margen = SUT.ObtieneAjustePorEstacion(new DateTime(2020, 2, 22));
            //Assert
            Assert.AreEqual(-0.3m, margen);
        }
        [TestMethod]
        public void ObtieneAjustePorEstacion_10Octubre_0punto15()//Invierno
        {
            //Arrange
            var SUT = new MaritimoAjusteTiempo();
            //ACT
            var margen = SUT.ObtieneAjustePorEstacion(new DateTime(2020, 10, 10));
            //Assert
            Assert.AreEqual(0.15m, margen);
        }

        [TestMethod]
        public void ObtieneAjustePorEstacion_10Julio_Menos0punto1()//Invierno
        {
            //Arrange
            var SUT = new MaritimoAjusteTiempo();
            //ACT
            var margen = SUT.ObtieneAjustePorEstacion(new DateTime(2020, 7, 10));
            //Assert
            Assert.AreEqual(-0.10m, margen);
        }
        [TestMethod]
        public void ObtieneAjustePorEstacion_10Marzo_Cero()//Invierno
        {
            //Arrange
            var SUT = new MaritimoAjusteTiempo();
            //ACT
            var margen = SUT.ObtieneAjustePorEstacion(new DateTime(2020, 3, 10));
            //Assert
            Assert.AreEqual(0m, margen);
        }
    }
}
