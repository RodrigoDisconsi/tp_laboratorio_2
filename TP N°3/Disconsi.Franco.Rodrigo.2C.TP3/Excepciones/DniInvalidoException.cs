using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        const string mensajeBase = "mensaje base";

        public DniInvalidoException() : base()
        {

        }

        public DniInvalidoException(Exception e) : this(mensajeBase, e)
        {

        }


        public DniInvalidoException(string mensaje) : this(mensaje, null)
        {

        }

        public DniInvalidoException(string mensaje, Exception innerException) : base(mensaje, innerException)
        {

        }
    }
}
