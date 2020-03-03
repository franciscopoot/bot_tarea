using System;
using System.Collections.Generic;
using System.Text;

namespace RastreoPaquetes.Interfaces.Chain
{
    public interface IRangoTiempoValidador
    {
        string ValidaFecha(TimeSpan _diferencia);
    }
}
