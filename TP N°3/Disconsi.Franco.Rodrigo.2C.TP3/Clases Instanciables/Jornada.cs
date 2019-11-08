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

        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Guarda una jornada en un archivo de texto.
        /// </summary>
        /// <param name="j"></param>
        /// <returns></returns>
        public static bool Guardar(Jornada j)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)+ "\\Jornada.txt";
            Texto texto = new Texto();
            return texto.Guardar(path, j.ToString());
                
        }

        /// <summary>
        /// Lee el archivo de texto de Jornada.
        /// </summary>
        /// <returns></returns>
        public string Leer()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Jornada.txt";
            Texto texto = new Texto();
            string rtn = "";
            texto.Leer(path, out rtn);
            return rtn;
            
        }

        /// <summary>
        /// Hace públicos los datos de la Jornada.
        /// </summary>
        /// <returns></returns>

        public override string ToString()
        {
            StringBuilder rtn = new StringBuilder();
            rtn.Append($"CLASE DE {this.clase} POR ");
            rtn.Append(this.instructor.ToString());
            rtn.AppendLine("ALUMNOS: ");
            foreach(Alumno aux in this.alumnos)
            {
                rtn.AppendLine(aux.ToString());
            }
            rtn.AppendLine("<--------------------------------------------------------->");
            rtn.AppendLine();
            return rtn.ToString();
        }

        #endregion

        #region Operadores

        /// <summary>
        /// Compara si el alumno toma la clase de la Jornada.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Jornada j , Alumno a)
        {
            return (a == j.clase);
        }

        /// <summary>
        /// Devuelve true si el alumno no da la clase de la Jornada.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Agrega un Alumno a la Jornada si este no esta ya en la Jornada.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            foreach(Alumno aux in j.alumnos)
            {
                if(aux.Equals(a))
                {
                    return j;
                }
            }
            j.alumnos.Add(a);
            return j;
        }

        #endregion
    }
}
