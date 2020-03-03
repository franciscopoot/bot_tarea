using System;
using System.Collections.Generic;
using System.Text;

namespace RastreoPaquetes.DTO
{
    public class EstadoPedidoDTO
    {
        public string Clasificador { set; get; }
        public string Paqueteria { set; get; }
        public string Estado { set; get; }
        public int Linea { set; get; }
        public string Mensaje { set; get; }
        public string Color { set; get; }
    }
}
