using System;
using System.Collections.Generic;

namespace AsignaturasRepetir
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> asignaturas = new List<string>()
            {
                "Matemáticas",
                "Física",
                "Química",
                "Historia",
                "Lengua"
            };

            // Lista para guardar las asignaturas reprobadas
            List<string> repetir = new List<string>();

            foreach (string asignatura in asignaturas)
            {
                Console.Write("Ingrese la nota de " + asignatura + ": ");
                double nota = double.Parse(Console.ReadLine());

                if (nota < 7) // nota mínima para aprobar
                {
                    repetir.Add(asignatura);
                }
            }

            Console.WriteLine("\nAsignaturas que debe repetir:");
            if (repetir.Count == 0)
            {
                Console.WriteLine("Ninguna. ¡Felicitaciones!");
            }
            else
            {
                foreach (string a in repetir)
                {
                    Console.WriteLine("- " + a);
                }
            }

            Console.WriteLine("\nPresione una tecla para salir...");
            Console.ReadKey();
        }
    }
}
