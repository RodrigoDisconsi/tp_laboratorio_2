using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;

namespace Clases_Instanciables
{
    [Serializable]
    public class Universidad
    {
        List<Alumno> alumnos;
        List<Jornada> jornada;
        List<Profesor> profesores;
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }

        #region Propiedades

        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }

        public List<Profesor> Instructores
        {
            get
            {
                return this.profesores;
            }
            set
            {
                this.profesores = value;
            }
        }

        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornada;
            }
            set
            {
                this.jornada = value;
            }
        }

        /// <summary>
        /// Retorna la jornada en el indice especificado y setea la jornada en el indice especificado.
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public Jornada this[int i]
        {
            get
            {
                return this.jornada[i];
            }
            set
            {
                this.jornada[i] = value;
            }
        }

        #endregion

        #region Constructores

        public Universidad()
        {
            alumnos = new List<Alumno>();
            jornada = new List<Jornada>();
            profesores = new List<Profesor>();
        }

        #endregion


        #region Métodos

        /// <summary>
        /// Guarda la universidad en el archivo "ArchivoXml.xml"
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        public static bool Guardar(Universidad uni)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\ArchivoXml.xml";
            Xml<Universidad> xml = new Xml<Universidad>();
            return xml.Guardar(path, uni);
        }

        /// <summary>
        /// Lee el archivo "ArchivoXml.xml"
        /// </summary>
        /// <returns></returns>
        public Universidad Leer()
        {
            Universidad rtn;
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\ArchivoXml.xml";
            Xml<Universidad> xml = new Xml<Universidad>();
            if(xml.Leer(path, out rtn))
            {
                return rtn;
            }
            return null;
        }

        /// <summary>
        /// Devuelve un string con los datos de las Jornada de la universidad.
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        private string MostrarDatos(Universidad uni)
        {
            StringBuilder rtn = new StringBuilder();
            rtn.AppendLine("JORNADA: ");
            foreach (Jornada j in uni.jornada)
            {
                rtn.Append(j.ToString());
            }
            return rtn.ToString();
        }

        /// <summary>
        /// Hace públicos los datos de la Universidad.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }

        #endregion

        #region Operadores

        /// <summary>
        /// Devuelve true si el Alumno se encuentra en la lista de Alumnos de la universidad.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad u, Alumno a)
        {
            return u.alumnos.Contains(a);
        }

        /// <summary>
        /// Devuelve true si el Alumno no se encuentra en la lista de Alumnos de la universidad.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Universidad u, Alumno a)
        {
            return !(u == a);
        }

        /// <summary>
        /// Devuelve true si el Profesor se encuentra en la lista de Profesores de la universidad.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad u, Profesor p)
        {
            return u.profesores.Contains(p);
        }

        /// <summary>
        /// Devuelve true si el Profesor no se encuentra en la lista de Profesor de la universidad.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool operator !=(Universidad u, Profesor p)
        {
            return !(u == p);
        }

        /// <summary>
        /// Devuelve el primer profesor que de la clase y sino lanza una excepción.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static Profesor operator ==(Universidad u, Universidad.EClases c)
        {
            foreach(Profesor aux in u.profesores)
            {
                if (aux == c)
                    return aux;
            }
            throw new SinProfesorException();
        }

        /// <summary>
        /// Devuelve el primer profesor que no de la clase y sino retorna null.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static Profesor operator !=(Universidad u, EClases c)
        {
            foreach(Profesor aux in u.profesores)
            {
                if (aux != c)
                    return aux;
            }
            return null;
        }

        /// <summary>
        /// Agrega una nueva jornada a la Universidad, con la clase pasada por parametro.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad u, EClases c)
        {
            Profesor p = u == c;
            Jornada j = new Jornada(c, p);
            foreach(Alumno aux in u.alumnos)
            {
                if (aux == c)
                    j.Alumnos.Add(aux);
            }
            u.jornada.Add(j);
            return u;
        }
        
        /// <summary>
        /// Agrega el Alumno a la universidad si no se encuentra ya en esta. 
        /// </summary>
        /// <param name="u"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if(u != a)
            {
                u.alumnos.Add(a);
                return u;
            }
            throw new AlumnoRepetidoException();
        }

        /// <summary>
        /// Agrega un Profesor a la universidad si no se encuentra ya en esta.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad u, Profesor p)
        {
            if(u != p)
            {
                u.profesores.Add(p);
            }
            return u;
        }


        #endregion
    }
}
