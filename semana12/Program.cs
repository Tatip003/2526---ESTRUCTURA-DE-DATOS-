using System;
using System.Collections.Generic;

namespace SistemaDeportivoCon10Participantes
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            //  Conjunto Universo (10 participantes)
            HashSet<string> universo = new HashSet<string>
            {
                "Ana", "Luis", "Carlos", "María", "Pedro",
                "Sofía", "Jorge", "Valentina", "Diego", "Camila"
            };

            //  Disciplinas (Subconjuntos del universo)
            Dictionary<string, HashSet<string>> disciplinas =
                new Dictionary<string, HashSet<string>>
            {
                { "Fútbol", new HashSet<string> { "Ana", "Luis", "Pedro", "Jorge", "Diego" } },
                { "Natación", new HashSet<string> { "Luis", "María", "Sofía", "Camila", "Valentina" } },
                { "Atletismo", new HashSet<string> { "Carlos", "Ana", "Sofía", "Diego", "Valentina" } }
            };

            //  Diccionario para contar primeros lugares (Mapa clave-valor)
            Dictionary<string, int> primerosLugares =
                new Dictionary<string, int>();

            foreach (var jugador in universo)
            {
                primerosLugares[jugador] = 0; // Inserción en el mapa
            }

            // Mostrar Conjunto Universo
            Console.WriteLine("====== CONJUNTO UNIVERSO (U) ======");
            foreach (var jugador in universo)
            {
                Console.WriteLine(jugador);
            }

            // Mostrar Disciplinas
            Console.WriteLine("\n====== DISCIPLINAS ======");
            foreach (var disciplina in disciplinas)
            {
                Console.WriteLine($"\n{disciplina.Key}:");
                foreach (var jugador in disciplina.Value)
                {
                    Console.WriteLine($" - {jugador}");
                }
            }

            //  Seleccionar ganador aleatorio por disciplina
            Console.WriteLine("\n====== GANADORES POR DISCIPLINA ======");
            foreach (var disciplina in disciplinas)
            {
                List<string> participantes = new List<string>(disciplina.Value);
                string ganador = participantes[random.Next(participantes.Count)];

                primerosLugares[ganador]++; // Búsqueda y actualización por clave

                Console.WriteLine($"{disciplina.Key} → Ganador: {ganador}");
            }

            //  Mostrar tabla final
            Console.WriteLine("\n====== TABLA DE GANADORES ======");

            string campeon = "";
            int maxPremios = -1;

            foreach (var jugador in primerosLugares)
            {
                Console.WriteLine($"{jugador.Key} | Primeros lugares: {jugador.Value}");

                if (jugador.Value > maxPremios)
                {
                    maxPremios = jugador.Value;
                    campeon = jugador.Key;
                }
            }

            Console.WriteLine($"\n🏆 Campeón general: {campeon} con {maxPremios} primeros lugares.");

            Console.ReadKey();
        }
    }
}
