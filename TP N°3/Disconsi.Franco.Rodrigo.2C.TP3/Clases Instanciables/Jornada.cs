using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;
using Archivos;

namespace Clases_Instanciables
{
    public class Jornada
    {
        List<Alumno> alumnos;
        Universidad.EClases clase;
        Profesor instructor;

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

        public Universidad.EClases Clase
        {
            get
            {
                return this.clase;
            }
            set
            {
                this.clase = value;
            }
        }

        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }
            set
            {
                this.instructor = value;
            }
        }

        #endregion

        #region Constructores

        public Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor)
        {
            this.clase = clase;
            this.instructor = instructor;
        }

        #endregion

        #region Métodos

        public static bool Guardar(Jornada j)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            path += "\\Jornada.txt";
            Texto texto = new Texto();
            return texto.Guardar(path, j.ToString());
                
        }

        //public string Leer()
        //{
        //    string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        //    path += "\\Jornada.txt";
        //    try
        //    {
        //        using(StreamReader archivo = new StreamReader(path))
        //        {
        //            return archivo.ReadToEnd();
        //        }
        //    }
        //    catch(Exception e)
        //    {
        //        throw new ArchivoException(e);
        //    }
        //}

        public override string ToString()
        {
            StringBuilder rtn = new StringBuilder();
            rtn.AppendLine("JORNADA: ");
            rtn.Append($"CLASE DE {this.clase} POR");
            rtn.AppendLine(this.instructor.ToString());
            rtn.AppendLine("ALUMNOS: ");
            foreach(Alumno aux in this.alumnos)
            {
                rtn.AppendLine(aux.ToString());
            }
            return rtn.ToString();
        }

        #endregion

        #region Operadores

        public static bool operator ==(Jornada j , Alumno a)
        {
            foreach(Alumno aux in j.alumnos)
            {
                if (aux == a)
                    return true;
            }
            return false;
        }

        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        public static Jornada operator +(Jornada j, Alumno a)
        {
            if(j != a)
            {
                j.alumnos.Add(a);
            }
            return j;
        }

        #endregion
    }
}
