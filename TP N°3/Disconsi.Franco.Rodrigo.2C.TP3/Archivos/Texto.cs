using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo <string>
    {
        public bool Guardar(string archivo, string datos)
        {
            //try
            //{
            //    using (StreamWriter open = new StreamWriter(archivo))
            //    {
            //        open.WriteLine(datos);
            //    }
            //    return true;
            //}
            //catch
            //{
            //    return false;
            //}

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
                throw new ArchivoException(e);
                //return false;
            }
        }
    }
}
