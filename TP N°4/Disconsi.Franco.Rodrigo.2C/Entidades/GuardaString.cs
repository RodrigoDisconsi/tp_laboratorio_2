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
        public static bool GuardarString(this string texto, string archivo)
        {
            try
            {
                using (StreamWriter open = new StreamWriter(archivo, true))
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
