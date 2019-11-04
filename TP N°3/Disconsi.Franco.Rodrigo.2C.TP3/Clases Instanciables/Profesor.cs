using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_Abstractas;

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

        public Profesor(int id, string nombre, string apellido, string dni, Enacionalidad nacionalidad) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClase();
        }

        #endregion

        #region Métodos

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

        public override string ToString()
        {
            return "";
        }

        protected override string MostrarDatos()
        {
            return "";
        }

        private void _randomClase()
        {
            Universidad.EClases clase1 = (Universidad.EClases)random.Next(0, 3);
            Universidad.EClases clase2 = (Universidad.EClases)random.Next(0, 3);
            clasesDelDia.Enqueue(clase1);
            clasesDelDia.Enqueue(clase2);
        }
        #endregion

        #region Operadores

        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            foreach(Universidad.EClases aux in i.clasesDelDia)
            {
                if (aux == clase)
                    return true;
            }
            return false;
        }

        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }

        #endregion
    }
}
