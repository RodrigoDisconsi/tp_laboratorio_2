        using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using System.Text.RegularExpressions;

namespace Clases_Abstractas
{
    public abstract class Persona
    {
        string apellido;
        int dni;
        Enacionalidad nacionalidad;
        string nombre;

        public enum Enacionalidad
        {
            Argentino,
            Extranjero
        }

        #region Propiedades

        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = this.ValidarDni(this.nacionalidad, value);
            }
        }

        public string StringToDNI
        {
            set
            {
                this.dni = this.ValidarDni(this.nacionalidad, value);
            }
        }

        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = this.ValidarNombreApellido(value);
            }
        }

        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = this.ValidarNombreApellido(value);
            }
        }

        public Enacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }

        #endregion

        #region Constructores

        public Persona()
        {

        }
        public Persona(string nombre, string apellido, Enacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, Enacionalidad nacionalidad) : this(nombre, apellido, dni.ToString(), nacionalidad)
        {

        }

        public Persona(string nombre, string apellido, string dni, Enacionalidad nacionalidad)
        {
            this.StringToDNI = dni;
        }

        #endregion


        #region Validaciones
        private int ValidarDni(Enacionalidad nacionalidad, string dni)
        {
            int retorno;
            if (int.TryParse(dni, out retorno) && dni.Length < 9 && retorno >= 1 && retorno <= 99999999)
            {
                if (nacionalidad == Enacionalidad.Argentino && retorno <= 89999999 || nacionalidad == Enacionalidad.Extranjero && retorno <= 99999999)
                {
                    return retorno;
                }
                else
                {
                    throw new NacionalidadInvalidException("Dni y nacionalidad no coincide");
                }
            }
            else
            {
                throw new DniInvalidoException("Formato de dni invalido");
            }
        }

        private int ValidarDni(Enacionalidad nacionalidad, int dni)
        {
            return this.ValidarDni(nacionalidad, dni.ToString());
        }

        private string ValidarNombreApellido(string dato)
        {
            if (Regex.IsMatch(dato, "^[a - zA - Z] + $"))
            {

                return dato;
            }
            else
            {
                return null;
            }        
        }

        #endregion


        public override string ToString()
        {
            StringBuilder rtn = new StringBuilder();
            return "";
        }
    }
}
