using CsvHelper;
using RastreoPaquetes.DTO;
using RastreoPaquetes.Interfaces;
using RastreoPaquetes.Map;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace RastreoPaquetes.Clases
{
    public class CsvLectorArchivo : ILectorArchivo
    {
        public string Tipo => "csv";

        public List<PedidoDTO> LeerArchivo(string name, string path)
        {
            List<PedidoDTO> LstDatosArchivo = new List<PedidoDTO>();
            using (var reader = new StreamReader(name))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Configuration.HasHeaderRecord = false;
                csv.Configuration.RegisterClassMap<PedidoDTOMap>();
                LstDatosArchivo = csv.GetRecords<PedidoDTO>().ToList();
            }
            return LstDatosArchivo;
        }
    }
}
