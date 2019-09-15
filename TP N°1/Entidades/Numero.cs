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

        private string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);
            }
        }

        #region Constructores

        public Numero()
        {
            this.numero = 0;
        }

        public Numero(double numero)
        {
            this.numero = numero;
        }

        //public Numero(string numero) :  this(double.TryParse(numero, this.numero));
        public Numero(string numero)
        {
            this.SetNumero = numero;
        }

        #endregion

        #region Conversiones
        public static string DecimalBinario(double entero)
        {
            string aux = "";
            int auxNumero = (int)entero;
            do
            {
                if (auxNumero % 2 == 0)
                {
                    aux = "0" + aux;
                }
                else
                {
                    aux = "1" + aux;
                }
                auxNumero = auxNumero / 2;
            } while (auxNumero >= 1);
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
                if (aux != '1' && aux != '0')
                {
                    retorno = "Valor inválido";
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

        public static string DecimalBinario(string numero)
        {
            string retorno = "";
            double aux;
            if (double.TryParse(numero, out aux))
            {
                retorno = Numero.DecimalBinario(aux);
            }
            else
            {
                retorno = "Valor inválido";
            }
            return retorno;
        }
        #endregion

        #region Operadores

        public static double operator +(Numero num1, Numero num2)
        {
            return num1.numero + num2.numero;
        }

        public static double operator -(Numero num1, Numero num2)
        {
            return num1.numero - num2.numero;
        }

        public static double operator *(Numero num1, Numero num2)
        {
            return num1.numero * num2.numero;
        }

        public static double operator /(Numero num1, Numero num2)
        {
            double aux = double.MinValue;
            if(num2.numero != 0)
            {
                aux = num1.numero / num2.numero;
            }
            return aux;
        }

        #endregion

        private static double ValidarNumero(string Numero)
        {
            double retorno = 0;
            double.TryParse(Numero, out retorno);
            return retorno;
        }

    }
}
