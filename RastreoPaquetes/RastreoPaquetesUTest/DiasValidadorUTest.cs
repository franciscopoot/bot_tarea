using Microsoft.VisualStudio.TestTools.UnitTesting;
using RastreoPaquetes.Clases.Chain;
using System;
using System.Collections.Generic;
using System.Text;

namespace RastreoPaquetesUTest
{
    [TestClass]
    public class DiasValidadorUTest
    {
        [TestMethod]
        public void ValidaFecha_10Dias_Sin_ValidacionSiguiente()
        {
            //Arrange
            DateTime fechaHoy = new DateTime(2020, 3, 1,20,12,0);
            DateTime nuevaFecha = new DateTime(2020, 2, 20,15,30,0);
            string textoSalida = "10 Días";
            var SUT = new DiasValidador();

            //ACT
            var salida = SUT.ValidaFecha(fechaHoy - nuevaFecha);

            //Assert
            Assert.AreEqual(textoSalida, salida);
        }

        [TestMethod]
        public void ValidaFecha_1Dia_Sin_ValidacionSiguiente()
        {
            //Arrange
            DateTime fechaHoy = new DateTime(2020, 3, 1, 15, 12, 0);
            DateTime nuevaFecha = new DateTime(2020, 3, 2, 20, 30, 0);
            string textoSalida = "1 Día";
            var SUT = new DiasValidador();

            //ACT
            var salida = SUT.ValidaFecha(fechaHoy - nuevaFecha);

            //Assert
            Assert.AreEqual(textoSalida, salida);
        }

        [TestMethod]
        public void ValidaFecha_40Dias_Sin_ValidacionSiguiente()
        {
            //Arrange
            DateTime fechaHoy = new DateTime(2020, 3, 1, 15, 12, 0);
            DateTime nuevaFecha = fechaHoy.AddDays(40);
            string textoSalida = "";
            var SUT = new DiasValidador();

            //ACT
            var salida = SUT.ValidaFecha(fechaHoy - nuevaFecha);

            //Assert
            Assert.AreEqual(textoSalida, salida);
        }

        [TestMethod]
        public void ValidaFecha_1punto5Dias_Sin_ValidacionSiguiente()
        {
            //Arrange
            DateTime fechaHoy = new DateTime(2020, 3, 1, 15, 12, 0);
            DateTime nuevaFecha = new DateTime(2020, 3, 2, 23, 12, 0);
            string textoSalida = "1 Día";
            var SUT = new DiasValidador();

            //ACT
            var salida = SUT.ValidaFecha(fechaHoy - nuevaFecha);

            //Assert
            Assert.AreEqual(textoSalida, salida);
        }
    }
}
