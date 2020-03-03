using RastreoPaquetes.Enum;


namespace RastreoPaquetes.Interfaces.Factory
{
    public interface IPaqueteriaFactory
    {
        IPaqueteria Create(PaqueteriaEnum _nombrePaqueteria);
    }
}
