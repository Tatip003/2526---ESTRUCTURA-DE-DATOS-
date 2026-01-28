using System;
using System.Collections.Generic;

namespace ParqueDiversiones
{
    class Persona
    {
        public string Nombre { get; set; }
        public int Turno { get; set; }

        public Persona(string nombre, int turno)
        {
            Nombre = nombre;
            Turno = turno;
        }

        public override string ToString()
        {
            return $"Turno {Turno} - {Nombre}";
        }
    }

    class Atraccion
    {
        private Queue<Persona> cola = new Queue<Persona>();
        private int capacidad = 30;
        private int contadorTurnos = 1;

        public void AgregarPersona(string nombre)
        {
            Persona p = new Persona(nombre, contadorTurnos++);
            cola.Enqueue(p);
            Console.WriteLine("Persona agregada: " + p);
            MostrarEstadoAsientos();
        }

        public void MostrarCola()
        {
            Console.WriteLine("\nPersonas en la cola:");
            if (cola.Count == 0)
            {
                Console.WriteLine("La cola está vacía.");
                return;
            }

            foreach (Persona p in cola)
            {
                Console.WriteLine(p);
            }
        }

        public void MostrarEstadoAsientos()
        {
            int ocupados = cola.Count;
            int disponibles = capacidad - ocupados;

            Console.WriteLine("Asientos ocupados: " + ocupados);
            Console.WriteLine("Asientos disponibles: " + disponibles + "\n");
        }

        public void SubirAtraccion()
        {
            Console.WriteLine("\nSubiendo a la atracción...");
            while (cola.Count > 0)
            {
                Persona p = cola.Dequeue();
                Console.WriteLine("Sube: " + p);
            }
            Console.WriteLine("Todos los asientos fueron ocupados.");
        }

        public bool EstaLlena()
        {
            return cola.Count == capacidad;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Atraccion juego = new Atraccion();
            string? nombre;

            Console.WriteLine("SIMULADOR DE COLA - ATRACCIÓN\n");

            while (!juego.EstaLlena())
            {
                do
                {
                    Console.Write("Ingrese nombre de la persona: ");
                    nombre = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(nombre))
                    {
                        Console.WriteLine("Error: debe ingresar un nombre válido.\n");
                    }

                } while (string.IsNullOrWhiteSpace(nombre));

                juego.AgregarPersona(nombre);
            }

            juego.MostrarCola();
            juego.SubirAtraccion();

            Console.WriteLine("\nPresione una tecla para salir...");
            Console.ReadKey();
        }
    }
}

