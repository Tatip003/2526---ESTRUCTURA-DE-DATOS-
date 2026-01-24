using System;
using System.Collections.Generic;

namespace ParentesisBalanceados
{
    class Program
    {
        // Función principal: lee la expresión y muestra el resultado
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese una expresión matemática:");
            string? expresion = Console.ReadLine();

            // Validación básica
            if (string.IsNullOrEmpty(expresion))
            {
                Console.WriteLine("No se ingresó ninguna expresión.");
                return;
            }

            // Llamada al verificador
            if (EstaBalanceada(expresion))
            {
                Console.WriteLine("Fórmula balanceada.");
            }
            else
            {
                Console.WriteLine("Fórmula NO balanceada.");
            }

            Console.ReadKey();
        }

        // Verifica si los símbolos están balanceados usando una pila
        static bool EstaBalanceada(string expresion)
        {
            Stack<char> pila = new Stack<char>(); // Pila de símbolos de apertura

            foreach (char c in expresion)
            {
                // Si es apertura, se apila
                if (c == '(' || c == '{' || c == '[')
                {
                    pila.Push(c);
                }
                // Si es cierre, se compara
                else if (c == ')' || c == '}' || c == ']')
                {
                    if (pila.Count == 0) return false;

                    char ultimo = pila.Pop();

                    if (!EsPar(ultimo, c)) return false;
                }
            }

            // Si la pila está vacía, está balanceada
            return pila.Count == 0;
        }

        // Comprueba si los símbolos forman un par correcto
        static bool EsPar(char apertura, char cierre)
        {
            if (apertura == '(' && cierre == ')') return true;
            if (apertura == '{' && cierre == '}') return true;
            if (apertura == '[' && cierre == ']') return true;
            return false;
        }
    }
}
