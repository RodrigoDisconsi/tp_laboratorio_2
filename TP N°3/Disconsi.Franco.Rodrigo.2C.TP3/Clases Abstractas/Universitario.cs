using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        int legajo;
        
        public Universitario()
        {

        }

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }

        #region Métodos

        /// <summary>
        /// Devuelve un string con los datos del universitario.
        /// </summary>
        /// <returns></returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder rtn = new StringBuilder();
            rtn.AppendLine(base.ToString());
            rtn.Append($"LEGAJO NÚMERO: {this.legajo}");
            return rtn.ToString();
        }
        protected abstract string ParticiparEnClase();

        /// <summary>
        /// Compara 2 objetos viendo si son el mismo y si son la misma persona.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return (this.GetType() == obj.GetType() && (((Universitario)obj) == this));
        }

        #endregion

        #region Operadores

        /// <summary>
        /// Compara dos universitarios.
        /// </summary>
        /// <param name="u1"></param>
        /// <param name="u2"></param>
        /// <returns></returns>
        public static bool operator ==(Universitario u1, Universitario u2)
        {
            if (u1.DNI == u2.DNI || u1.legajo == u2.legajo)
                return true;
            return false;
        }

        public static bool operator !=(Universitario u1, Universitario u2)
        {
            return !(u1 == u2);
        }



        #endregion
    }
}
