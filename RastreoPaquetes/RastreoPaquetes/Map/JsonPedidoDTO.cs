using System;
using System.Collections.Generic;
using System.Text;

namespace RastreoPaquetes.Map
{
    public class JsonPedidoDTO
    {
        public string Procedencia { set; get; }
        public string Destino { set; get; }
        public decimal Dist_KM { set; get; }
        public string Empresa { set; get; }
        public string MedioTrans { set; get; }
        public string FechaPedido { set; get; }
    }
}
