using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_Abstractas;

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

        public Alumno(int id, string nombre, string apellido, string dni, Persona.Enacionalidad nacionalidad, Universidad.EClases clasesQueToma) : base(id, nombre, apellido, dni, nacionalidad)
        {

        }

        public Alumno(int id, string nombre, string apellido, string dni, Persona.Enacionalidad nacionalidad, Universidad.EClases clasesQueToma, EEstadoCuenta estadoCuenta) : this(id, nombre, apellido, dni, nacionalidad, clasesQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }

        #endregion



        #region Métodos

        protected override string ParticiparEnClase()
        {
            return $"TOMA CLASE DE: {this.clasesQueToma}";
        }

        protected override string MostrarDatos()
        {
            return "";
        }

        public override string ToString()
        {
            return "";  
        }

        #endregion
        #region Operadores

        public static bool operator ==(Alumno a, Universidad.EClases c)
        {
            return (a.clasesQueToma == c && a.estadoCuenta != EEstadoCuenta.Deudor);
        }

        public static bool operator !=(Alumno a, Universidad.EClases c)
        {
            return !(a == c);
        }
        #endregion
    }
}
