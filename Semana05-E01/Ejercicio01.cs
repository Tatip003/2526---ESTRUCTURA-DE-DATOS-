using System;

namespace Asignaturas
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] asignaturas = {
                "Matemáticas",
                "Física",
                "Química",
                "Historia",
                "Lengua"
            };

            foreach (string asignatura in asignaturas)
            {
                Console.WriteLine("Yo estudio " + asignatura);
            }

            Console.WriteLine("\nPresione una tecla para salir...");
            Console.ReadKey();
        }
    }
}


