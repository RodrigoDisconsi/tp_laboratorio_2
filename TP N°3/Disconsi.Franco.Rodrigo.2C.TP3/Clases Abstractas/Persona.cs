using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

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

        public Persona()
        {

        }

        public Persona(string nombre, string apellido, Enacionalidad nacionalidad)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, Enacionalidad nacionalidad)
        {
            
        }

        public Persona(string nombre, string apellido, string dni, Enacionalidad nacionalidad)
        {

        }

        public int ValidarDni(Enacionalidad nacionalidad, int dni)
        {

        }
        public int ValidarDni(Enacionalidad nacionalidad, string dni)
        {
            int retorno;
            if(int.TryParse(dni, out retorno) && dni.Length > 8 && retorno >= 1 && retorno <= 99999999)
            {
                if(nacionalidad == Enacionalidad.Argentino && retorno <= 89999999 || nacionalidad == Enacionalidad.Extranjero && retorno <= 99999999)
                {
                    return retorno;
                }
                else
                {
                    throw new DniInvalidoException("Dni y nacionalidad no coincide");
                }
            }
            else
            {
                throw new DniInvalidoException("Formato de dni invalido");
            }
        }
    }
}
