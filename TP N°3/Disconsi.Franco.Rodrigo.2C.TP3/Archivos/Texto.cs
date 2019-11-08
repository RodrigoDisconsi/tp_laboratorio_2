using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        /// <summary>
        /// Guarda los datos en la ruta pasada por parametro.
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Guardar(string archivo, string datos)
        {
            try
            {
                using (StreamWriter open = new StreamWriter(archivo))
                {
                    open.WriteLine(datos);
                }
                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }

        /// <summary>
        /// Lee el archivo pasado por parametro y los guarda en datos.
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>

        public bool Leer(string archivo, out string datos)
        {
            try
            {
                using(StreamReader leer = new StreamReader(archivo))
                {
                   datos = leer.ReadToEnd();
                }
                return true;
            }
            catch(Exception e)
            {
                throw new ArchivosException(e);
            }
        }
    }
}
