using CsvHelper.Configuration;
using RastreoPaquetes.DTO;

namespace RastreoPaquetes.Map
{
    public sealed class PedidoDTOMap : ClassMap<PedidoDTO>
    {
        public PedidoDTOMap()
        {
            Map(m => m.Distancia).Index(0);
            Map(m => m.Paqueteria).Index(1);
            Map(m => m.MedioTransporte).Index(2);
            Map(m => m.FechaPedido).Index(3).TypeConverterOption.Format("dd-MM-yyyy HH:mm:ss");
            Map(m => m.PaisOrigen).Index(4);
            Map(m => m.CiudadOrigen).Index(5);
            Map(m => m.PaisDestino).Index(6);
            Map(m => m.CiudadDestino).Index(7);
        }
    }
}
