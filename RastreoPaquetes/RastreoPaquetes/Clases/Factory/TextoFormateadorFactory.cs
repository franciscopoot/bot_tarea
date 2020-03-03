using RastreoPaquetes.Clases.Chain;
using RastreoPaquetes.Enum;
using RastreoPaquetes.Interfaces;
using RastreoPaquetes.Interfaces.Chain;
using RastreoPaquetes.Interfaces.Factory;
using System;
using System.Collections.Generic;
using System.Text;

namespace RastreoPaquetes.Clases.Factory
{
    public class TextoFormateadorFactory : ITextoFormateadorFactory
    {
        readonly IRangoTiempoValidador Validador;
        public TextoFormateadorFactory() {
            var validadorMinutos = new MinutosValidador();
            var validadorHoras = new HorasValidador();
            var validadorDias = new DiasValidador();
            var validadorMes = new MesValidador();
            validadorMinutos.AsignaSiguiente(validadorHoras);
            validadorHoras.AsignaSiguiente(validadorDias);
            validadorDias.AsignaSiguiente(validadorMes);
            Validador = validadorMinutos;
        }
        public ITextoFormateador Create(TextoFormateadorEnum _tipo)
        {
            ITextoFormateador factory = null;
            switch (_tipo) {
                case TextoFormateadorEnum.Entregado: //PedidoEntregado
                    factory = new FormatoPedidoEntregado(Validador);
                    break;
                case TextoFormateadorEnum.Pendiente:
                    factory = new FormatoPedidoPendiente(Validador);
                    break;
            }
            return factory;
        }
    }
}
