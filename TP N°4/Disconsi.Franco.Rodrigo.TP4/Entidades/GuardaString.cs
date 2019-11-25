using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public static class GuardaString
    {

        /// <summary>
        /// Método de extensión String que guarda el mismo, en el archivo pasado por parametro.
        /// </summary>
        /// <param name="texto"></param>
        /// <param name="archivo"></param>
        /// <returns></returns>
        public static bool GuardarString(this string texto, string archivo)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + archivo;
            try
            {
                using (StreamWriter open = new StreamWriter(path, true))
                {
                    open.WriteLine(texto);
                }
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
