using System;
using System.Collections.Generic;
using System.Text;

namespace RastreoPaquetes.Clases.Exceptions
{
    public class PaqueteriaException: Exception
    {
        public PaqueteriaException(string message):base(message) { 
        
        }
    }
}
