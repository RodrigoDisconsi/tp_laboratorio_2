using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Abstractas
{
    public abstract class Universitario : Persona
    {
        int legajo;
        
        public Universitario()
        {

        }

        public Universitario(int legajo, string nombre, string apellido, string dni, Enacionalidad nacionalidad)
        {

        }

        #region Métodos

        protected virtual string MostrarDatos()
        {
            return "";
        }
        protected abstract string ParticiparEnClase();
        public override bool Equals(object obj)
        {
            return obj is Universitario;
        }

        #endregion

        #region Operadores


        public static bool operator ==(Universitario u1, Universitario u2)
        {
            bool rtn = false;
            if (u1.Equals(u2) && (u1.DNI == u2.DNI || u1.legajo == u2.legajo))
                rtn = true;
            return rtn;
        }

        public static bool operator !=(Universitario u1, Universitario u2)
        {
            return !(u1 == u2);
        }

        #endregion
    }
}
