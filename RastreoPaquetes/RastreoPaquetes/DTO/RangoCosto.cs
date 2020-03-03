
namespace RastreoPaquetes.DTO
{
    public class RangoCosto
    {
        public RangoCosto(decimal _inicial, decimal? _final, decimal _costo) {
            Inicial = _inicial;
            Final = _final;
            Costo = _costo;
        }
        public decimal Inicial { get; set; }
        public decimal? Final { set; get; }
        public decimal Costo { set; get; }
    }
}
