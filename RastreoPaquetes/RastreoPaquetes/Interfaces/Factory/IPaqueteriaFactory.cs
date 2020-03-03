using RastreoPaquetes.Enum;


namespace RastreoPaquetes.Interfaces.Factory
{
    public interface IPaqueteriaFactory
    {
        IPaqueteria Create(string _nombrePaqueteria);
    }
}
