using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        double numero;


        public static string DecimalBinario(double entero)
        {
            string aux = string.Empty;
            do
            {
                if (entero % 2 == 0)
                {
                    aux = "0" + aux;
                }
                else
                {
                    aux = "1" + aux;
                }
                entero = entero / 2;
            } while (entero > 1);
            return aux;
        }

        public static string BinarioDecimal(string binario)
        {
            string retorno = "";
            double numero = 0;
            char aux;
            int len = binario.Length;
            int elevado = len - 1;
            for (int i = 0; i < len; i++)
            {
                aux = binario[i];
                if(aux != '1' && aux != '0')
                {
                    retorno = "";
                    break;
                }
                if (aux == '1')
                {
                    numero += Math.Pow(2, elevado);
                }
                elevado--;
            }

            retorno = numero.ToString();
            return retorno;
        }

        public static string DecimalBinario (string numero)
        {
            string retorno = "";
            double aux;
            if(double.TryParse(retorno, out aux))
            {
                retorno = Numero.DecimalBinario(aux);
            }
            return retorno;
        }



        
    }
}
