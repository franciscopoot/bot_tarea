using Microsoft.VisualStudio.TestTools.UnitTesting;
using RastreoPaquetes.Clases;
using RastreoPaquetes.Clases.Factory;
using RastreoPaquetes.Enum;

namespace RastreoPaquetesUTest
{
    [TestClass]
    public class TextoFormateadorFactoryUTest
    {
        [TestMethod]
        public void Create_Entregado_TextoFormateadorEntregado()
        {
            //Arrange
            var SUT = new TextoFormateadorFactory();
            //ACT
            var textoFormateador = SUT.Create(TextoFormateadorEnum.Entregado);
            //Assert
            Assert.IsTrue(textoFormateador is FormatoPedidoEntregado);
        }

        [TestMethod]
        public void Create_Pendiente_TextoFormateadorPendiente()
        {
            //Arrange
            var SUT = new TextoFormateadorFactory();
            //ACT
            var textoFormateador = SUT.Create(TextoFormateadorEnum.Pendiente);
            //Assert
            Assert.IsTrue(textoFormateador is FormatoPedidoPendiente);
        }
    }
}
