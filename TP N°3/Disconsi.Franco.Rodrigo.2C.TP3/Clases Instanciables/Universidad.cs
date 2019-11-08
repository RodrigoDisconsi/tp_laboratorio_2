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
            StringBuilder rtn = new StringBuilder();
            rtn.AppendLine("JORNADA: ");
            foreach (Jornada j in uni.jornada)
            {
                rtn.Append(j.ToString());
            }
            return rtn.ToString();
        }

        public override string ToString()
        {
            return MostrarDatos(this);
        }

        #endregion

        #region Operadores

        public static bool operator ==(Universidad u, Alumno a)
        {
            return u.alumnos.Contains(a);
        }

        public static bool operator !=(Universidad u, Alumno a)
        {
            return !(u == a);
        }

        public static bool operator ==(Universidad u, Profesor p)
        {
            return u.profesores.Contains(p);
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
