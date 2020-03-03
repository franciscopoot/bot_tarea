using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RastreoPaquetes;
using RastreoPaquetes.Clases;
using RastreoPaquetes.Clases.Factory;
using RastreoPaquetes.Enum;

namespace RastreoPaquetesUTest
{
    [TestClass]
    public class PaqueteriaFactoryUTest
    {
        [TestMethod]
        public void Create_EnumFedex_Fedex()
        {
            //Arrange
            var medioTransporteFactory = new MedioTransporteFactory();
            var SUT = new PaqueteriaFactory(medioTransporteFactory);
            //ACT
            var paqueteria = SUT.Create(PaqueteriaEnum.Fedex);
            //Assert
            Assert.IsTrue(paqueteria is Fedex);
        }
        [TestMethod]
        public void Create_EnumDhl_Dhl()
        {
            //Arrange
            var medioTransporteFactory = new MedioTransporteFactory();
            var SUT = new PaqueteriaFactory(medioTransporteFactory);
            //ACT
            var paqueteria = SUT.Create(PaqueteriaEnum.Dhl);
            //Assert
            Assert.IsTrue(paqueteria is Dhl);
        }

        [TestMethod]
        public void Create_EnumEstafeta_Estafeta()
        {
            //Arrange
            var medioTransporteFactory = new MedioTransporteFactory();
            var SUT = new PaqueteriaFactory(medioTransporteFactory);
            //ACT
            var paqueteria = SUT.Create(PaqueteriaEnum.Estafeta);
            //Assert
            Assert.IsTrue(paqueteria is Estafeta);
        }
    }
}
