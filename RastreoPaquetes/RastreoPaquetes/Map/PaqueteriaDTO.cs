using System;
using System.Collections.Generic;
using System.Text;

namespace RastreoPaquetes.Map
{
    public class PaqueteriaDTO
    {
        public string Paqueteria { set; get; }
        public List<MargenUtilidadDTO> MargenUtilidad { set; get; }
        public List< PaqueteriaMedioDTO> Medios{ set; get; }
    }
}
