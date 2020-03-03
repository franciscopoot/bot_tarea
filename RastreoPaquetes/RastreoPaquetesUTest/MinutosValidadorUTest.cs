using Microsoft.VisualStudio.TestTools.UnitTesting;
using RastreoPaquetes.Clases.Chain;
using System;
using System.Collections.Generic;
using System.Text;

namespace RastreoPaquetesUTest
{
    [TestClass]
    public class MinutosValidadorUTest
    {
        [TestMethod]
        public void ValidaFecha_10Minutos_Sin_ValidacionSiguiente()
        {
            //Arrange
            DateTime fechaHoy = new DateTime(2020, 3, 1, 5, 12, 0);
            DateTime nuevaFecha = new DateTime(2020, 3, 1, 5, 22, 0);
            string textoSalida = "10 Minutos";
            var SUT = new MinutosValidador();

            //ACT
            var salida = SUT.ValidaFecha(fechaHoy - nuevaFecha);

            //Assert
            Assert.AreEqual(textoSalida, salida);
        }

        [TestMethod]
        public void ValidaFecha_1Minuto_Sin_ValidacionSiguiente()
        {
            //Arrange
            DateTime fechaHoy = new DateTime(2020, 3, 1, 15, 12, 0);
            DateTime nuevaFecha = new DateTime(2020, 3, 1, 15, 11, 0);
            string textoSalida = "1 Minuto";
            var SUT = new MinutosValidador();

            //ACT
            var salida = SUT.ValidaFecha(fechaHoy - nuevaFecha);

            //Assert
            Assert.AreEqual(textoSalida, salida);
        }

        [TestMethod]
        public void ValidaFecha_60Minutos_Sin_ValidacionSiguiente()
        {
            //Arrange
            DateTime fechaHoy = new DateTime(2020, 3, 1, 15, 12, 0);
            DateTime nuevaFecha = fechaHoy.AddMinutes(60);
            string textoSalida = "";
            var SUT = new MinutosValidador();

            //ACT
            var salida = SUT.ValidaFecha(fechaHoy - nuevaFecha);

            //Assert
            Assert.AreEqual(textoSalida, salida);
        }

        [TestMethod]
        public void ValidaFecha_2punto5Minutos_Sin_ValidacionSiguiente()
        {
            //Arrange
            DateTime fechaHoy = new DateTime(2020, 3, 1, 15, 12, 0);
            DateTime nuevaFecha = new DateTime(2020, 3, 1, 15, 14, 30);
            string textoSalida = "2 Minutos";
            var SUT = new MinutosValidador();

            //ACT
            var salida = SUT.ValidaFecha(fechaHoy - nuevaFecha);

            //Assert
            Assert.AreEqual(textoSalida, salida);
        }
    }
}
