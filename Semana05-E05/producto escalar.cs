using System;
using System.Collections.Generic;

namespace ProductoEscalar
{
    class Program
    {
        static void Main(string[] args)
        {
                        Console.WriteLine("VEjemplo visual code");

            List<int> vector1 = new List<int>() { 1, 2, 3 };
            List<int> vector2 = new List<int>() { -1, 0, 2 };

            int productoEscalar = 0;

            for (int i = 0; i < vector1.Count; i++)
            {
                productoEscalar += vector1[i] * vector2[i];
            }

            Console.WriteLine("Vector 1: (1, 2, 3)");
            Console.WriteLine("Vector 2: (-1, 0, 2)");
            Console.WriteLine("Producto escalar: " + productoEscalar);

            Console.WriteLine("\nPresione una tecla para salir...");
            Console.ReadKey();
        }
    }
}
