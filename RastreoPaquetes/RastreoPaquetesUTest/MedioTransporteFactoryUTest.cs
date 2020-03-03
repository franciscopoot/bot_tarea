using Microsoft.VisualStudio.TestTools.UnitTesting;
using RastreoPaquetes.Clases;
using RastreoPaquetes.Clases.Factory;
using RastreoPaquetes.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace RastreoPaquetesUTest
{
    [TestClass]
    public class MedioTransporteFactoryUTest
    {
        [TestMethod]
        public void Create_EnumMaritimo_Maritimo()
        {
            //Arrange
            var SUT = new MedioTransporteFactory();
            //ACT
            var medioTransporte = SUT.Create(MedioTransporteEnum.Maritimo);
            //Assert
            Assert.IsTrue(medioTransporte is Maritimo);
        }
        [TestMethod]
        public void Create_EnumTerrestre_Terrestre()
        {
            //Arrange
            var SUT = new MedioTransporteFactory();
            //ACT
            var medioTransporte = SUT.Create(MedioTransporteEnum.Terrestre);
            //Assert
            Assert.IsTrue(medioTransporte is Terrestre);
        }

        [TestMethod]
        public void Create_EnumAereo_Aereo()
        {
            //Arrange
            var SUT = new MedioTransporteFactory();
            //ACT
            var medioTransporte = SUT.Create(MedioTransporteEnum.Aereo);
            //Assert
            Assert.IsTrue(medioTransporte is Aereo);
        }
    }
}
