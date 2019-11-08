using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace Clases_Instanciables
{
    public sealed class Profesor : Universitario
    {
        Queue<Universidad.EClases> clasesDelDia;
        static Random random;

        #region Constructores
        static Profesor()
        {
            random = new Random();
        }

        public Profesor() 
        {
            
        }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClase();
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Devuelve un string con las clases en la que participa el Profesor.
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder rtn = new StringBuilder();
            rtn.AppendLine("CLASES DEL DÍA: ");
            foreach(Universidad.EClases clase in this.clasesDelDia)
            {
                rtn.AppendLine($"{clase}");
            }
            return rtn.ToString();
        }

        /// <summary>
        /// Hace públicos los datos del Profesor.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        /// <summary>
        /// Devuelve un string con los dtaos del Profesor.
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder rtn = new StringBuilder();
            rtn.AppendLine(base.MostrarDatos());
            rtn.AppendLine(this.ParticiparEnClase());
            return rtn.ToString();
        }

        /// <summary>
        /// Genera 2 clases aleatorias y las agregas a las clases del Profesor.
        /// </summary>
        private void _randomClase()
        {
            Universidad.EClases clase1 = (Universidad.EClases)random.Next(0, 3);
            System.Threading.Thread.Sleep(500);
            Universidad.EClases clase2 = (Universidad.EClases)random.Next(0, 3);
            clasesDelDia.Enqueue(clase1);
            clasesDelDia.Enqueue(clase2);
        }
        #endregion

        #region Operadores


        /// <summary>
        /// Devuelve true si el profesor da esa clase.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            foreach(Universidad.EClases aux in i.clasesDelDia)
            {
                if (aux == clase)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Devuelve true si el profesor no da esa clase.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }

        #endregion
    }
}
