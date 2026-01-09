using System;

namespace Palindromo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Ingrese una palabra: ");
            string palabra = Console.ReadLine();

            string palabraInvertida = "";

            // Invertir la palabra
            for (int i = palabra.Length - 1; i >= 0; i--)
            {
                palabraInvertida += palabra[i];
            }

            if (palabra.ToLower() == palabraInvertida.ToLower())
            {
                Console.WriteLine("La palabra ES un palíndromo.");
            }
            else
            {
                Console.WriteLine("La palabra NO es un palíndromo.");
            }

            Console.WriteLine("\nPresione una tecla para salir...");
            Console.ReadKey();
        }
    }
}

