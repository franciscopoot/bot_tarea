using RastreoPaquetes.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace RastreoPaquetes.Interfaces
{
    public interface ITextoFormateador
    {
        List<string> LstExpresiones { get; }
        List<EstadoPedidoDTO> Formatear(DatoSalidaDTO _salida);
    }
}
