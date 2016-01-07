using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sumaCien
{
    class Program
    {
        static void Main(string[] args)
        {
            List<char[]> correctos = new List<char[]>();
            char[] actual = new char[8];

            for (int i = 0; i < 8; i++) 
            {
                actual[i] = ' ';
            }

            while (!soloSignosNegativos(actual))
            {
                imprimir(actual);
                Console.Write(" = " + calcular(actual));
                Console.WriteLine();
                if (calcular(actual) == 100)
                {
                    correctos.Add(actual);
                }//*/

                actual = siguiente(actual);
            }
            imprimir(actual);
            Console.Write(" = " + calcular(actual));
            Console.ReadKey();

            Console.Clear();

            foreach (char[] correcto in correctos) 
            {
                imprimir(correcto);
                Console.Write(" = " + calcular(correcto));
                Console.WriteLine();
            }
            Console.ReadKey();

        }

        private static int calcular(char[] actual)
        {
            int resultado = 0;
            string expresion = "";
            char simbolo='+';

            for (int i = 0; i < 8; i++) 
            {
                string numero = (i + 1).ToString();
                expresion += numero;
                if (actual[i] != ' ')
                {
                    if (simbolo == '+')
                    {
                        resultado += int.Parse(expresion);
                    }
                    else if (simbolo == '-')
                    {
                        resultado -= int.Parse(expresion);
                    }
                    expresion = "";
                    simbolo = actual[i];
                }
            }
            expresion += "9";
            if (simbolo == '+') 
            {
                resultado += int.Parse(expresion);
            }
            else if (simbolo == '-') 
            {
                resultado -= int.Parse(expresion);
            }
            
            return resultado;
        }

        private static void imprimir(char[] actual)
        {
            for (int i = 0; i < 8; i++)
            {
                if (actual[i] != ' ') Console.Write((i + 1) + " " + actual[i] + " ");
                else Console.Write((i + 1).ToString());
            }
            Console.Write(9);
        }

        private static bool soloSignosNegativos(char[] actual)
        {
            for (int i = 0; i < 8; i++) 
            {
                if (actual[i] != '-') return false;
            }
            return true;
        }

        public static char[] siguiente(char[] actual)
        {
            char[] siguiente = new char[8];
            for (int i = 0; i < 8; i++) 
            {
                siguiente[i] = actual[i];
            }

            bool aumentar = true;            

            for (int i = 7; i >= 0; i--)
            {
                if (aumentar)
                {
                    if (actual[i] == ' ')
                    {
                        siguiente[i] = '+';
                        aumentar = false;
                    }
                    else if (actual[i] == '+')
                    {
                        siguiente[i] = '-';
                        aumentar = false;
                    }
                    else if (actual[i] == '-')
                    {
                        siguiente[i] = ' ';
                    }
                }
            }
            return siguiente;
        }
    }
}
