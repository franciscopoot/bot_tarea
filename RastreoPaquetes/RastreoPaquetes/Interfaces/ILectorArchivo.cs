using RastreoPaquetes.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace RastreoPaquetes.Interfaces
{
    public interface ILectorArchivo
    {
        string Tipo { get; }
        List<PedidoDTO> LeerArchivo(string name, string path);
    }
}
