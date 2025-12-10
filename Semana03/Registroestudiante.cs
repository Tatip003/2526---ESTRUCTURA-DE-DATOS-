using System;

namespace RegistroEstudiantes
{
    // Clase que representa a un Estudiante
    public class Estudiante
    {
        public int ID { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }

        // Array para almacenar 3 números de teléfono
        public string[] Telefonos { get; set; }

        public Estudiante()
        {
            Telefonos = new string[3];
        }

        public void MostrarDatos()
        {
            Console.WriteLine("\n=== DATOS DEL ESTUDIANTE ===");
            Console.WriteLine($"ID: {ID}");
            Console.WriteLine($"Nombres: {Nombres}");
            Console.WriteLine($"Apellidos: {Apellidos}");
            Console.WriteLine($"Dirección: {Direccion}");
            Console.WriteLine("Teléfonos:");
            for (int i = 0; i < Telefonos.Length; i++)
            {
                Console.WriteLine($"  Teléfono {i + 1}: {Telefonos[i]}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Estudiante estudiante = new Estudiante();

            Console.WriteLine("=== REGISTRO DE ESTUDIANTE ===");

            Console.Write("Ingrese ID: ");
            estudiante.ID = int.Parse(Console.ReadLine());

            Console.Write("Ingrese nombres: ");
            estudiante.Nombres = Console.ReadLine();

            Console.Write("Ingrese apellidos: ");
            estudiante.Apellidos = Console.ReadLine();

            Console.Write("Ingrese dirección: ");
            estudiante.Direccion = Console.ReadLine();

            Console.WriteLine("\n--- Registro de teléfonos ---");
            for (int i = 0; i < 3; i++)
            {
                Console.Write($"Ingrese teléfono {i + 1}: ");
                estudiante.Telefonos[i] = Console.ReadLine();
            }

            Console.WriteLine("\nRegistro completado.");

            // Mostrar la información ingresada
            estudiante.MostrarDatos();

            Console.WriteLine("\nPresione cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}

