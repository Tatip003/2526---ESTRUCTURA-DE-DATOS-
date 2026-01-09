using System;
using System.Collections.Generic;

namespace LoteriaPrimitiva
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numeros = new List<int>();

            Console.WriteLine("Ingrese 6 números ganadores de la lotería primitiva:");

            for (int i = 0; i < 6; i++)
            {
                Console.Write("Número " + (i + 1) + ": ");
                int numero = int.Parse(Console.ReadLine());
                numeros.Add(numero);
            }

            // Ordenar de menor a mayor
            numeros.Sort();

            Console.WriteLine("\nNúmeros ordenados:");
            foreach (int n in numeros)
            {
                Console.Write(n + " ");
            }

            Console.WriteLine("\n\nPresione una tecla para salir...");
            Console.ReadKey();
        }
    }
}

