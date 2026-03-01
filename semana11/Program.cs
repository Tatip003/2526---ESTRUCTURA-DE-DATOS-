using System;
using System.Collections.Generic;
using System.Linq;

class Traductor
{
    static void Main(string[] args)
    {
        // Diccionario Español → Inglés
        Dictionary<string, string> diccionario = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            {"tiempo", "time"},
            {"persona", "person"},
            {"año", "year"},
            {"camino", "way"},
            {"forma", "way"},
            {"día", "day"},
            {"cosa", "thing"},
            {"hombre", "man"},
            {"mundo", "world"},
            {"vida", "life"},
            {"mano", "hand"},
            {"parte", "part"},
            {"niño", "child"},
            {"niña", "child"},
            {"ojo", "eye"},
            {"mujer", "woman"},
            {"lugar", "place"},
            {"trabajo", "work"},
            {"semana", "week"},
            {"caso", "case"},
            {"punto", "point"},
            {"tema", "point"},
            {"gobierno", "government"},
            {"empresa", "company"},
            {"compañía", "company"}
        };

        int opcion;

        do
        {
            Console.WriteLine("\n==================== MENÚ ====================");
            Console.WriteLine("1. Traducir una frase");
            Console.WriteLine("2. Agregar palabras al diccionario");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");

            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    TraducirFrase(diccionario);
                    break;

                case 2:
                    AgregarPalabra(diccionario);
                    break;

                case 0:
                    Console.WriteLine("Saliendo del programa...");
                    break;

                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }

        } while (opcion != 0);
    }

    static void TraducirFrase(Dictionary<string, string> diccionario)
    {
        Console.Write("\nIngrese la frase: ");
        string frase = Console.ReadLine();

        string[] palabras = frase.Split(' ');

        for (int i = 0; i < palabras.Length; i++)
        {
            string palabraLimpia = palabras[i].ToLower().Trim(',', '.', ';', ':', '¿', '?', '¡', '!');
            
            if (diccionario.ContainsKey(palabraLimpia))
            {
                palabras[i] = palabras[i].Replace(palabraLimpia, diccionario[palabraLimpia]);
            }
        }

        string traduccion = string.Join(" ", palabras);
        Console.WriteLine("\nTraducción: " + traduccion);
    }

    static void AgregarPalabra(Dictionary<string, string> diccionario)
    {
        Console.Write("\nIngrese la palabra en español: ");
        string esp = Console.ReadLine().ToLower();

        Console.Write("Ingrese la traducción en inglés: ");
        string ing = Console.ReadLine().ToLower();

        if (!diccionario.ContainsKey(esp))
        {
            diccionario.Add(esp, ing);
            Console.WriteLine("Palabra agregada correctamente.");
        }
        else
        {
            Console.WriteLine("La palabra ya existe en el diccionario.");
        }
    }
}