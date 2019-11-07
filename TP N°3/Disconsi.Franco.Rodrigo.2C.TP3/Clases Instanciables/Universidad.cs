using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;

namespace Clases_Instanciables
{
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

        #region Constructores

        public Universidad()
        {
            alumnos = new List<Alumno>();
            jornada = new List<Jornada>();
            profesores = new List<Profesor>();
        }

        #endregion


        #region Métodos

        public static bool Guardar(Universidad uni)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\ArchivoXml.xml";
            Xml<Universidad> xml = new Xml<Universidad>();
            return xml.Guardar(path, uni);
        }

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

        private string MostrarDatos(Universidad uni)
        {
            StringBuilder datos = new StringBuilder();
            datos.AppendLine("UNIVERSIDAD: ");
            datos.AppendLine("Jornada:");
            foreach (Jornada j in uni.Jornadas)
            {
                datos.Append(j.ToString());
            }
            foreach(Alumno aux in uni.alumnos)

            

            return datos.ToString();
        }

        #endregion

        #region Operadores

        public static bool operator ==(Universidad u, Alumno a)
        {
            foreach(Alumno aux in u.alumnos)
            {
                if (aux.Equals(a))
                    return true;
            }
            return false;
        }

        public static bool operator !=(Universidad u, Alumno a)
        {
            return !(u == a);
        }

        public static bool operator ==(Universidad u, Profesor p)
        {
            foreach(Profesor aux in u.profesores)
            {
                if (aux.Equals(p))
                    return true;
            }
            return false;
        }

        public static bool operator !=(Universidad u, Profesor p)
        {
            return !(u == p);
        }

        public static Profesor operator ==(Universidad u, Universidad.EClases c)
        {
            foreach(Profesor aux in u.profesores)
            {
                if (aux == c)
                    return aux;
            }
            throw new SinProfesorException();
        }

        public static Profesor operator !=(Universidad u, EClases c)
        {
            foreach(Profesor aux in u.profesores)
            {
                if (aux != c)
                    return aux;
            }
            return null;
        }

        public static Universidad operator +(Universidad u, EClases c)
        {
            Jornada j = null;
            foreach(Profesor aux in u.profesores)
            {
                if(aux == c)
                {
                    j = new Jornada(c, aux);
                }
            }
            if(j != null)
            {
                foreach(Alumno aux in u.alumnos)
                {
                    if(aux == c)
                    {
                        j += aux;
                    }
                }
                u.jornada.Add(j);
            }
            return u;
        }
        
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if(u != a)
            {
                u.alumnos.Add(a);
                return u;
            }
            throw new AlumnoRepetidoException();
        }

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
