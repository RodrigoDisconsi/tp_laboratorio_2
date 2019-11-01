using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NacionalidadInvalidException : Exception
    {
        public NacionalidadInvalidException() : base()
        {

        }

        public NacionalidadInvalidException(string mensaje) : base(mensaje)
        {

        }
    }
}
