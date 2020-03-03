using RastreoPaquetes.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace RastreoPaquetes.Interfaces.Chain
{
    public interface IRangoTiempoValidador
    {
        ValidadorDTO ValidaFecha(TimeSpan _diferencia);
    }
}
