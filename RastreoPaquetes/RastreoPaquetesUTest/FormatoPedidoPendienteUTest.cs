using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using RastreoPaquetes.Clases;
using RastreoPaquetes.DTO;
using RastreoPaquetes.Interfaces.Chain;
using System;
using System.Collections.Generic;

namespace RastreoPaquetesUTest
{
    [TestClass]
    public class FormatoPedidoPendienteUTest
    {
        [TestMethod]
        public void Formatear_PendienteConOpcionMasEconomica1Dia()//Invierno
        {
            //Arrange
            DatoSalidaDTO param = new DatoSalidaDTO()
            {
                CiudadOrigen = "Ticul",
                CiudadDestino = "Motul",
                PaisOrigen = "Mexico",
                PaisDestino = "Mexico",
                CostoServicio = 1160m,
                FechaEntrega = new DateTime(2020, 3, 2),
                FechaHoy = new DateTime(2020, 3, 1),
                Linea = 1,
                NombrePaqueteria = "Fedex",
                OpcionMasEconomica = new OpcionMasEconomicaDTO() { NombrePaqueteria = "Dhl", CostoEnvio = 1100 }
            };
            List<EstadoPedidoDTO> lstEstados = new List<EstadoPedidoDTO>() {
                new EstadoPedidoDTO(){ Color="Yellow",Linea =1,Mensaje="Tu paquete ha salido de Ticul, Mexico y llegará a Motul, Mexico dentro de 1 Día y tendrá un costo de $1,160.00 (Cualquier reclamación con FEDEX)."},
                new EstadoPedidoDTO(){ Color="Gray",Linea=1,Mensaje="Si hubieras pedido en Dhl te hubiera costado $60.00 menos."}
            };
            var DOCrangoValidador = new Mock<IRangoTiempoValidador>();
            DOCrangoValidador.Setup(doc => doc.ValidaFecha(It.IsAny<TimeSpan>())).Returns("1 Día");

            var SUT = new FormatoPedidoPendiente(DOCrangoValidador.Object);
            //ACT
            var textoFormateado = SUT.Formatear(param);
            //Assert
            Assert.IsTrue(
               lstEstados[0].Mensaje.Equals(textoFormateado[0].Mensaje) &&
               lstEstados[0].Color.Equals(textoFormateado[0].Color) &&
                lstEstados[1].Mensaje.Equals(textoFormateado[1].Mensaje) &&
               lstEstados[1].Color.Equals(textoFormateado[1].Color)
               );
        }

        [TestMethod]
        public void Formatear_EntregadoConOpcionMasEconomica10Dias()//Invierno
        {
            //Arrange
            DatoSalidaDTO param = new DatoSalidaDTO()
            {
                CiudadOrigen = "Ticul",
                CiudadDestino = "Motul",
                PaisOrigen = "Mexico",
                PaisDestino = "Mexico",
                CostoServicio = 1160m,
                FechaEntrega = new DateTime(2020, 3, 2).AddDays(10),
                FechaHoy = new DateTime(2020, 3, 2),
                Linea = 1,
                NombrePaqueteria = "Fedex",
                OpcionMasEconomica = new OpcionMasEconomicaDTO() { NombrePaqueteria = "Dhl", CostoEnvio = 1100 }
            };
            List<EstadoPedidoDTO> lstEstados = new List<EstadoPedidoDTO>() {
               new EstadoPedidoDTO(){ Color="Yellow",Linea =1,Mensaje="Tu paquete ha salido de Ticul, Mexico y llegará a Motul, Mexico dentro de 10 Días y tendrá un costo de $1,160.00 (Cualquier reclamación con FEDEX)."},
                new EstadoPedidoDTO(){ Color="Gray",Linea=1,Mensaje="Si hubieras pedido en Dhl te hubiera costado $60.00 menos."}
            };
            var DOCrangoValidador = new Mock<IRangoTiempoValidador>();
            DOCrangoValidador.Setup(doc => doc.ValidaFecha(It.IsAny<TimeSpan>())).Returns("10 Días");

            var SUT = new FormatoPedidoPendiente(DOCrangoValidador.Object);
            //ACT
            var textoFormateado = SUT.Formatear(param);
            //Assert
            Assert.IsTrue(
               lstEstados[0].Mensaje.Equals(textoFormateado[0].Mensaje) &&
               lstEstados[0].Color.Equals(textoFormateado[0].Color) &&
                lstEstados[1].Mensaje.Equals(textoFormateado[1].Mensaje) &&
               lstEstados[1].Color.Equals(textoFormateado[1].Color)
               );
        }
        [TestMethod]
        public void Formatear_EntregadoSinOpcionMasEconomica10Dias()//Invierno
        {
            //Arrange
            DatoSalidaDTO param = new DatoSalidaDTO()
            {
                CiudadOrigen = "Ticul",
                CiudadDestino = "Motul",
                PaisOrigen = "Mexico",
                PaisDestino = "Mexico",
                CostoServicio = 1160m,
                FechaEntrega = new DateTime(2020, 3, 2).AddDays(10),
                FechaHoy = new DateTime(2020, 3, 2),
                Linea = 1,
                NombrePaqueteria = "Fedex"
            };
            List<EstadoPedidoDTO> lstEstados = new List<EstadoPedidoDTO>() {
                new EstadoPedidoDTO(){ Color="Yellow",Linea =1,Mensaje="Tu paquete ha salido de Ticul, Mexico y llegará a Motul, Mexico dentro de 10 Días y tendrá un costo de $1,160.00 (Cualquier reclamación con FEDEX)."},
            };
            var DOCrangoValidador = new Mock<IRangoTiempoValidador>();
            DOCrangoValidador.Setup(doc => doc.ValidaFecha(It.IsAny<TimeSpan>())).Returns("10 Días");

            var SUT = new FormatoPedidoPendiente(DOCrangoValidador.Object);
            //ACT
            var textoFormateado = SUT.Formatear(param);
            //Assert
            Assert.IsTrue(
               lstEstados[0].Mensaje.Equals(textoFormateado[0].Mensaje) &&
               lstEstados[0].Color.Equals(textoFormateado[0].Color) 
               
               );
        }
    }
}
