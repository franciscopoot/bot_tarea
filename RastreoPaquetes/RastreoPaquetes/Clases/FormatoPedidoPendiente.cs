﻿using RastreoPaquetes.DTO;
using RastreoPaquetes.Interfaces;
using RastreoPaquetes.Interfaces.Chain;
using System;
using System.Collections.Generic;
using System.Text;

namespace RastreoPaquetes.Clases
{
    public class FormatoPedidoPendiente : ITextoFormateador
    {
        readonly IRangoTiempoValidador Validador;
        public FormatoPedidoPendiente(IRangoTiempoValidador _validador)
        {
            Validador = _validador;
        }
        public List<string> LstExpresiones => new List<string> { "ha salido", "llegará", "dentro de", "tendrá" };

        public List<EstadoPedidoDTO> Formatear(DatoSalidaDTO _salida)
        {
            List<EstadoPedidoDTO> estadosPedidos = new List<EstadoPedidoDTO>();
            var rangoTiempo = Validador.ValidaFecha(_salida.FechaHoy - _salida.FechaEntrega);
            var salida = $"Tu paquete {LstExpresiones[0]} de {_salida.CiudadOrigen}, {_salida.PaisOrigen} y {LstExpresiones[1]} " +
                $"a {_salida.CiudadDestino}, {_salida.PaisDestino} {LstExpresiones[2]} {rangoTiempo.Texto} y {LstExpresiones[3]} un costo de " +
                $"{_salida.CostoServicio.ToString("C")} (Cualquier reclamación con {_salida.NombrePaqueteria.ToUpper()}).";

            estadosPedidos.Add(new EstadoPedidoDTO()
            {
                Estado = "Pendiente",
                Paqueteria = _salida.NombrePaqueteria.ToUpper(),
                Clasificador = rangoTiempo.Clasificador,
                Linea = _salida.Linea,
                Mensaje = salida,
                Color = "Yellow"
            });
            if (_salida.OpcionMasEconomica != null)
            {
                estadosPedidos.Add(new EstadoPedidoDTO()
                {
                    Estado = "Pendiente",
                    Paqueteria = _salida.NombrePaqueteria.ToUpper(),
                    Clasificador = rangoTiempo.Clasificador,
                    Linea = _salida.Linea,
                    Mensaje = $"Si hubieras pedido en {_salida.OpcionMasEconomica.NombrePaqueteria} te hubiera costado {(_salida.CostoServicio - _salida.OpcionMasEconomica.CostoEnvio).ToString("C")} menos.",
                    Color = "Gray"
                });
            }
            return estadosPedidos;
        }
    }
}
