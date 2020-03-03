using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using RastreoPaquetes.Clases;
using RastreoPaquetes.Clases.Factory;
using RastreoPaquetes.DTO;
using RastreoPaquetes.Enum;
using RastreoPaquetes.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RastreoPaquetesUTest
{
    [TestClass]
    public class AdministradorPedidosUTest
    {
        [TestMethod]
        public void ObtenerEstatusPedidos_EstafetaTerrestre80_Costo1160Fecha2301202013()
        {
            //Arrange         
            PaqueteriaFactory factory = new PaqueteriaFactory(new MedioTransporteFactory());
          
            IPaqueteria[] paqueterias = { factory.Create(PaqueteriaEnum.Fedex),factory.Create(PaqueteriaEnum.Dhl),factory.Create(PaqueteriaEnum.Estafeta) };

            List<PedidoDTO> lstPedidos = new List<PedidoDTO>() {
                new PedidoDTO(){
                    Distancia=80,
                    Paqueteria ="Estafeta",
                    MedioTransporte="Terrestre",
                    FechaPedido= new DateTime(2020,1,23,12,0,0),
                    CiudadOrigen ="Ticul",
                    PaisOrigen="México",
                    CiudadDestino="Motul",
                    PaisDestino ="México"
                }
            };
            List<EstadoPedidoDTO> lstEstados = new List<EstadoPedidoDTO>() {
                new EstadoPedidoDTO(){ Color="Green",Linea =1,Mensaje="Tu paquete salió de Ticul, México y llegó a Motul, México hace 35 Minutos y tuvo un costo de $1,160.00 (Cualquier reclamación con ESTAFETA)."},
                new EstadoPedidoDTO(){ Color="Gray",Linea=1,Mensaje="Si hubieras pedido en Fedex te hubiera costado $120.00 menos."}
            };
            var SUT = new AdministradorPedidos(lstPedidos,paqueterias,new TextoFormateadorFactory());
            //ACT
            var textoFormateado = SUT.ObtenerEstatusPedidos(new DateTime(2020, 1, 23, 14, 0, 0));
            //Assert

            Assert.IsTrue(
              lstEstados[0].Mensaje.Equals(textoFormateado[0].Mensaje) &&
              lstEstados[0].Color.Equals(textoFormateado[0].Color) &&
               lstEstados[1].Mensaje.Equals(textoFormateado[1].Mensaje) &&
              lstEstados[1].Color.Equals(textoFormateado[1].Color)
              );
        }
        [TestMethod]
        public void ObtenerEstatusPedidos_PaqueteriaNoExiste_ExcepcionTipoPaqueteriaException()
        {
            //Arrange         
            PaqueteriaFactory factory = new PaqueteriaFactory(new MedioTransporteFactory());

            IPaqueteria[] paqueterias = { factory.Create(PaqueteriaEnum.Fedex), factory.Create(PaqueteriaEnum.Dhl), factory.Create(PaqueteriaEnum.Estafeta) };

            List<PedidoDTO> lstPedidos = new List<PedidoDTO>() {
                new PedidoDTO(){
                    Distancia=80,
                    Paqueteria ="Alf",
                    MedioTransporte="Terrestre",
                    FechaPedido= new DateTime(2020,1,23,12,0,0),
                    CiudadOrigen ="Ticul",
                    PaisOrigen="México",
                    CiudadDestino="Motul",
                    PaisDestino ="México"
                }
            };
            List<EstadoPedidoDTO> lstEstados = new List<EstadoPedidoDTO>() {
                new EstadoPedidoDTO(){ Color="Red",Linea=1,Mensaje="La paqueteria: Alf no se encuentra registrada en nuestra red de distribución."}
            };
            var SUT = new AdministradorPedidos(lstPedidos, paqueterias, new TextoFormateadorFactory());
            //ACT
            var textoFormateado = SUT.ObtenerEstatusPedidos(new DateTime(2020, 1, 23, 14, 0, 0));
            //Assert
            Assert.IsTrue(
            lstEstados[0].Mensaje.Equals(textoFormateado[0].Mensaje) &&
            lstEstados[0].Color.Equals(textoFormateado[0].Color) 
            );
        }

        [TestMethod]
        public void ObtenerEstatusPedidos_MedioTransporteNoExiste_ExcepcionTipoMedioTransporteException()
        {
            //Arrange         
            PaqueteriaFactory factory = new PaqueteriaFactory(new MedioTransporteFactory());

            IPaqueteria[] paqueterias = { factory.Create(PaqueteriaEnum.Fedex), factory.Create(PaqueteriaEnum.Dhl), factory.Create(PaqueteriaEnum.Estafeta) };

            List<PedidoDTO> lstPedidos = new List<PedidoDTO>() {
                new PedidoDTO(){
                    Distancia=80,
                    Paqueteria ="Estafeta",
                    MedioTransporte="Avion",
                    FechaPedido= new DateTime(2020,1,23,12,0,0),
                    CiudadOrigen ="Ticul",
                    PaisOrigen="México",
                    CiudadDestino="Motul",
                    PaisDestino ="México"
                }
            };
            List<EstadoPedidoDTO> lstEstados = new List<EstadoPedidoDTO>() {
                new EstadoPedidoDTO(){ Color="Red",Linea=1,Mensaje="Estafeta no ofrece el servicio de transporte Avion, te recomendamos cotizar en otra empresa."}
            };
            var SUT = new AdministradorPedidos(lstPedidos, paqueterias, new TextoFormateadorFactory());
            //ACT
            var textoFormateado = SUT.ObtenerEstatusPedidos(new DateTime(2020, 1, 23, 14, 0, 0));
            //Assert
            Assert.IsTrue(
            lstEstados[0].Mensaje.Equals(textoFormateado[0].Mensaje) &&
            lstEstados[0].Color.Equals(textoFormateado[0].Color)
            );
        }

        [TestMethod]
        public void ObtenerEstatusPedidos_DhlAereo446400_Costo1160Fecha2301202013()
        {
            //Arrange         
            PaqueteriaFactory factory = new PaqueteriaFactory(new MedioTransporteFactory());

            IPaqueteria[] paqueterias = { factory.Create(PaqueteriaEnum.Fedex), factory.Create(PaqueteriaEnum.Dhl), factory.Create(PaqueteriaEnum.Estafeta) };

            List<PedidoDTO> lstPedidos = new List<PedidoDTO>() {
                new PedidoDTO(){
                    Distancia=446400,
                    Paqueteria ="Dhl",
                    MedioTransporte="Aereo",
                    FechaPedido= new DateTime(2020,1,23,8,0,0),
                    CiudadOrigen ="Pekin",
                    PaisOrigen="China",
                    CiudadDestino="Cancún",
                    PaisDestino ="México"
                }
            };
            List<EstadoPedidoDTO> lstEstados = new List<EstadoPedidoDTO>() {
                new EstadoPedidoDTO(){ Color="Yellow",Linea =1,Mensaje="Tu paquete ha salido de Pekin, China y llegará a Cancún, México dentro de 4 Meses y tendrá un costo de $6,829,800.00‬ (Cualquier reclamación con DHL)."},
                new EstadoPedidoDTO(){ Color="Gray",Linea=1,Mensaje="Si hubieras pedido en Fedex te hubiera costado $910,640.00 menos."}
            };
            var SUT = new AdministradorPedidos(lstPedidos, paqueterias, new TextoFormateadorFactory());
            //ACT
            var textoFormateado = SUT.ObtenerEstatusPedidos(new DateTime(2020, 1, 23, 14, 0, 0));
            //Assert

            Assert.IsTrue(
              lstEstados[1].Mensaje.Equals(textoFormateado[1].Mensaje) &&
             lstEstados[1].Color.Equals(textoFormateado[1].Color)
             );
        }

        [TestMethod]
        public void ObtenerEstatusPedidos_DhlAereo446400_Costo6000Fecha2301202013()
        {
            //Arrange         
            PaqueteriaFactory factory = new PaqueteriaFactory(new MedioTransporteFactory());

            IPaqueteria[] paqueterias = { factory.Create(PaqueteriaEnum.Fedex), factory.Create(PaqueteriaEnum.Dhl), factory.Create(PaqueteriaEnum.Estafeta) };

            List<PedidoDTO> lstPedidos = new List<PedidoDTO>() {
                new PedidoDTO(){
                    Distancia=400,
                    Paqueteria ="Dhl",
                    MedioTransporte="Aereo",
                    FechaPedido= new DateTime(2020,1,23,13,50,0),
                    CiudadOrigen ="Mérida",
                    PaisOrigen="México",
                    CiudadDestino="Cozumel",
                    PaisDestino ="México"
                }
            };
            List<EstadoPedidoDTO> lstEstados = new List<EstadoPedidoDTO>() {
                new EstadoPedidoDTO(){ Color="Yellow",Linea =1,Mensaje="Tu paquete ha salido de Mérida, México y llegará a Cozumel, México dentro de 3 Horas y tendrá un costo de $6,000.00‬ (Cualquier reclamación con DHL)."},
                new EstadoPedidoDTO(){ Color="Gray",Linea=1,Mensaje="Si hubieras pedido en Fedex te hubiera costado $800.00 menos."}
            };
            var SUT = new AdministradorPedidos(lstPedidos, paqueterias, new TextoFormateadorFactory());
            //ACT
            var textoFormateado = SUT.ObtenerEstatusPedidos(new DateTime(2020, 1, 23, 14, 0, 0));
            //Assert
            Assert.IsTrue(
              
               lstEstados[1].Mensaje.Equals(textoFormateado[1].Mensaje) &&
              lstEstados[1].Color.Equals(textoFormateado[1].Color)
          );
        }
    }
}
