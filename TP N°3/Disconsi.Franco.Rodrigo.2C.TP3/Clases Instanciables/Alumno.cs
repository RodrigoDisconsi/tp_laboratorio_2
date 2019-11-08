using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace Clases_Instanciables
{
    public sealed class Alumno : Universitario
    {
        Universidad.EClases clasesQueToma;
        EEstadoCuenta estadoCuenta;

        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }

        #region Constructores

        public Alumno()
        {

        }

        public Alumno(int id, string nombre, string apellido, string dni, Persona.ENacionalidad nacionalidad, Universidad.EClases clasesQueToma) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesQueToma = clasesQueToma;
        }

        public Alumno(int id, string nombre, string apellido, string dni, Persona.ENacionalidad nacionalidad, Universidad.EClases clasesQueToma, EEstadoCuenta estadoCuenta) : this(id, nombre, apellido, dni, nacionalidad, clasesQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }

        #endregion



        #region Métodos

        /// <summary>
        /// Devuelve un string con la clase en la que participa.
        /// </summary>
        /// <returns></returns>

        protected override string ParticiparEnClase()
        {
            return $"TOMA CLASE DE {this.clasesQueToma}";
        }

        /// <summary>
        /// Devuelve un string con los datos del Alumno.
        /// </summary>
        /// <returns></returns>

        protected override string MostrarDatos()
        {
            StringBuilder rtn = new StringBuilder();
            rtn.AppendLine(base.MostrarDatos());
            rtn.AppendLine();
            rtn.AppendLine($"ESTADO DE CUENTA: {this.estadoCuenta}");
            rtn.Append(this.ParticiparEnClase());
            return rtn.ToString();
        }

        /// <summary>
        /// Hace publicos los datos del Alumno.
        /// </summary>
        /// <returns></returns>

        public override string ToString()
        {
            return this.MostrarDatos();  
        }

        #endregion
        #region Operadores

        /// <summary>
        /// Devuelve true si el Alumno da esa clase y el estado de la cuenta no es deudor.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="c"></param>
        /// <returns></returns>

        public static bool operator ==(Alumno a, Universidad.EClases c)
        {
            return (a.clasesQueToma == c && a.estadoCuenta != EEstadoCuenta.Deudor);
        }


        /// <summary>
        /// Devuelve true si el alumno no da la clase.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="c"></param>
        /// <returns></returns>

        public static bool operator !=(Alumno a, Universidad.EClases c)
        {
            return !(a == c);
        }
        #endregion
    }
}
