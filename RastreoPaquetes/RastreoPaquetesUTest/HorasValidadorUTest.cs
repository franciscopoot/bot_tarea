using Microsoft.VisualStudio.TestTools.UnitTesting;
using RastreoPaquetes.Clases.Chain;
using System;
using System.Collections.Generic;
using System.Text;

namespace RastreoPaquetesUTest
{
    [TestClass]
    public class HorasValidadorUTest
    {
        [TestMethod]
        public void ValidaFecha_10Horas_Sin_ValidacionSiguiente()
        {
            //Arrange
            DateTime fechaHoy = new DateTime(2020, 3, 1, 5, 12, 0);
            DateTime nuevaFecha = new DateTime(2020, 3, 1, 15, 30, 0);
            string textoSalida = "10 Horas";
            var SUT = new HorasValidador();

            //ACT
            var salida = SUT.ValidaFecha(fechaHoy - nuevaFecha);

            //Assert
            Assert.AreEqual(textoSalida, salida);
        }

        [TestMethod]
        public void ValidaFecha_1Hora_Sin_ValidacionSiguiente()
        {
            //Arrange
            DateTime fechaHoy = new DateTime(2020, 3, 1, 15, 12, 0);
            DateTime nuevaFecha = new DateTime(2020, 3, 1, 14, 10, 0);
            string textoSalida = "1 Hora";
            var SUT = new HorasValidador();

            //ACT
            var salida = SUT.ValidaFecha(fechaHoy - nuevaFecha);

            //Assert
            Assert.AreEqual(textoSalida, salida);
        }

        [TestMethod]
        public void ValidaFecha_24Horas_Sin_ValidacionSiguiente()
        {
            //Arrange
            DateTime fechaHoy = new DateTime(2020, 3, 1, 15, 12, 0);
            DateTime nuevaFecha = fechaHoy.AddHours(24);
            string textoSalida = "";
            var SUT = new HorasValidador();

            //ACT
            var salida = SUT.ValidaFecha(fechaHoy - nuevaFecha);

            //Assert
            Assert.AreEqual(textoSalida, salida);
        }

        [TestMethod]
        public void ValidaFecha_2punto5Horas_Sin_ValidacionSiguiente()
        {
            //Arrange
            DateTime fechaHoy = new DateTime(2020, 3, 1, 15, 12, 0);
            DateTime nuevaFecha = new DateTime(2020, 3, 1, 17, 47, 0);
            string textoSalida = "2 Horas";
            var SUT = new HorasValidador();

            //ACT
            var salida = SUT.ValidaFecha(fechaHoy - nuevaFecha);

            //Assert
            Assert.AreEqual(textoSalida, salida);
        }
    }
}
