using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double aux = 0;
            switch(Calculadora.ValidarOperador(operador))
            {
                case "+":
                   aux = num1 + num2;
                   break;
                case "-":
                    aux = num1 - num2;
                    break;
                case "/":
                    aux = num1 / num2;
                    break;
                case "*":
                    aux = num1 * num2;
                    break;

            }

            return aux;
        }

        private static string ValidarOperador(string operador)
        {
            string aux = "+";
            if(operador == "+" || operador == "-" || operador == "/" || operador == "*")
            {
                aux = operador;
            }
            return aux;
        }
    }
}
