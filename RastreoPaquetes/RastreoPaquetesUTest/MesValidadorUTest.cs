using Microsoft.VisualStudio.TestTools.UnitTesting;
using RastreoPaquetes.Clases.Chain;
using System;


namespace RastreoPaquetesUTest
{
    [TestClass]
    public class MesValidadorUTest
    {
        [TestMethod]
        public void ValidaFecha_10Meses_Sin_ValidacionSiguiente()
        {
            //Arrange
            DateTime fechaHoy = new DateTime(2020, 3, 1, 5, 12, 0);
            DateTime nuevaFecha = fechaHoy.AddMonths(10);
            string textoSalida = "10 Meses";
            var SUT = new MesValidador();

            //ACT
            var salida = SUT.ValidaFecha(fechaHoy - nuevaFecha);

            //Assert
            Assert.AreEqual(textoSalida, salida);
        }

        [TestMethod]
        public void ValidaFecha_1Mes_Sin_ValidacionSiguiente()
        {
            //Arrange
            DateTime fechaHoy = new DateTime(2020, 3, 1, 15, 12, 0);
            DateTime nuevaFecha = new DateTime(2020, 4, 1, 15, 13, 0);
            string textoSalida = "1 Mes";
            var SUT = new MesValidador();

            //ACT
            var salida = SUT.ValidaFecha(fechaHoy - nuevaFecha);

            //Assert
            Assert.AreEqual(textoSalida, salida);
        }

        [TestMethod]
        public void ValidaFecha_60Meses_Sin_ValidacionSiguiente()
        {
            //Arrange
            DateTime fechaHoy = new DateTime(2020, 3, 1, 15, 12, 0);
            DateTime nuevaFecha = fechaHoy.AddMonths(60);
            string textoSalida = "60 Meses";
            var SUT = new MesValidador();

            //ACT
            var salida = SUT.ValidaFecha(fechaHoy - nuevaFecha);

            //Assert
            Assert.AreEqual(textoSalida, salida);
        }

        [TestMethod]
        public void ValidaFecha_2punto5Meses_Sin_ValidacionSiguiente()
        {
            //Arrange
            DateTime fechaHoy = new DateTime(2020, 3, 5, 15, 12, 0);
            DateTime nuevaFecha = new DateTime(2020, 1, 1, 15, 14, 30);
            string textoSalida = "2 Meses";
            var SUT = new MesValidador();

            //ACT
            var salida = SUT.ValidaFecha(fechaHoy - nuevaFecha);

            //Assert
            Assert.AreEqual(textoSalida, salida);
        }
    }
}
