using RastreoPaquetes.Clases.Exceptions;
using RastreoPaquetes.Clases.Strategy;
using RastreoPaquetes.DTO;
using RastreoPaquetes.Enum;
using RastreoPaquetes.Interfaces;
using RastreoPaquetes.Interfaces.Factory;
using RastreoPaquetes.Interfaces.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RastreoPaquetes.Clases
{
    public class AdministradorPedidos
    {
        readonly List<PedidoDTO> LstPedidos;
        readonly IPaqueteria[] LstPaqueterias;
        readonly IPaqueteriaStrategy EstrategiaPaqueteria;
        readonly ITextoFormateadorFactory TextoFormateadorFactory;
        public AdministradorPedidos(List<PedidoDTO> _lstPedidos,IPaqueteria[] _lstPaqueterias, ITextoFormateadorFactory _textoFormateadorFactory) {
            LstPaqueterias = _lstPaqueterias;
            LstPedidos = _lstPedidos;
            EstrategiaPaqueteria = new PaqueteriaStrategy(_lstPaqueterias);
            TextoFormateadorFactory = _textoFormateadorFactory;
        }

        public List<EstadoPedidoDTO> ObtenerEstatusPedidos(DateTime fechaHoy) {

            decimal costoServicio = 0;
            DateTime fechaEntrega;
            TextoFormateadorEnum tipoDiferenciaFecha;
            ITextoFormateador textoFormateador;
            List<OpcionMasEconomicaDTO> lstCostosOtrasPaqueterias = new List<OpcionMasEconomicaDTO>();
            List<EstadoPedidoDTO> lstEstadosPedidos = new List<EstadoPedidoDTO>();
            int numeroLinea =1;
            foreach (var pedido in LstPedidos) {
                var param = new ParametrosPaqueteriaDTO() {
                    NombreMedioTransporte = pedido.MedioTransporte,
                    FechaPedido = pedido.FechaPedido,
                    Distancia = pedido.Distancia
                };
                try
                {
                    costoServicio = EstrategiaPaqueteria.ObtenerCostoServicio(pedido.Paqueteria, param);
                    fechaEntrega = EstrategiaPaqueteria.ObtenerFechaEntrega(pedido.Paqueteria, param);
                    tipoDiferenciaFecha = ObtenerTipoDiferenciaFecha(fechaHoy, fechaEntrega);
                    lstCostosOtrasPaqueterias = CalcularOtrasOpcionesEnvio(pedido.Paqueteria, param);
                    textoFormateador = TextoFormateadorFactory.Create(tipoDiferenciaFecha);
                    lstEstadosPedidos.AddRange(textoFormateador.Formatear(new DatoSalidaDTO()
                    {
                        Linea = numeroLinea,
                        CiudadOrigen = pedido.CiudadOrigen,
                        CiudadDestino = pedido.CiudadDestino,
                        CostoServicio = costoServicio,
                        FechaEntrega = fechaEntrega,
                        FechaHoy = fechaHoy,
                        NombrePaqueteria = pedido.Paqueteria,
                        PaisDestino = pedido.PaisDestino,
                        PaisOrigen = pedido.PaisOrigen,
                        OpcionMasEconomica = ObtenerOpcionDeEnvioMasEconomica(costoServicio, lstCostosOtrasPaqueterias)
                    }));
                }
                catch (PaqueteriaException ex) {
                    lstEstadosPedidos.Add(new EstadoPedidoDTO()
                    {
                        Linea = numeroLinea,
                        Mensaje = ex.Message,
                        Color = "Red"
                    });
                }
                catch (MedioTransporteException mex)
                {
                    lstEstadosPedidos.Add(new EstadoPedidoDTO()
                    {
                        Linea = numeroLinea,
                        Mensaje = mex.Message,
                        Color = "Red"
                    });
                }
                numeroLinea++;
            }
            return lstEstadosPedidos;
        }

        private TextoFormateadorEnum ObtenerTipoDiferenciaFecha(DateTime _fechaHoy, DateTime _fechaEntrega) {

            if (DateTime.Compare(_fechaHoy, _fechaEntrega) < 0)
                return TextoFormateadorEnum.Pendiente;

            return TextoFormateadorEnum.Entregado;
        }

        private List<OpcionMasEconomicaDTO> CalcularOtrasOpcionesEnvio(string _nombrePaqueteriaOmitir, ParametrosPaqueteriaDTO _param) {
            List<OpcionMasEconomicaDTO> opciones = new List<OpcionMasEconomicaDTO>();
            var lstOtrasPaqueterias = LstPaqueterias.Where(n => n.Nombre != _nombrePaqueteriaOmitir);
            foreach (var paqueteria in lstOtrasPaqueterias) {
                if (paqueteria.ValidaMedioTransporte(_param.NombreMedioTransporte)) {
                    var calculoCosto = paqueteria.ObtenerCostoServicio(_param);
                    opciones.Add(new OpcionMasEconomicaDTO()
                    {
                        NombrePaqueteria = paqueteria.Nombre,
                        CostoEnvio = calculoCosto
                    });
                }
            }
            return opciones;
        }

        private OpcionMasEconomicaDTO ObtenerOpcionDeEnvioMasEconomica(decimal _costoActual, List<OpcionMasEconomicaDTO> _otrasOpciones) {
            
            return _otrasOpciones.Where(f => f.CostoEnvio < _costoActual).OrderBy(f => f.CostoEnvio).FirstOrDefault();
        }

    }
}
