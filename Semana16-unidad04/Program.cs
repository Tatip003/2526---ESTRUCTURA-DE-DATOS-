using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    // Clase árbol
    class NodoArbol
    {
        public string Ciudad;
        public NodoArbol? Siguiente;

        public NodoArbol(string ciudad)
        {
            Ciudad = ciudad;
            Siguiente = null;
        }
    }

    static void CrearArchivo()
    {
        File.WriteAllLines("vuelos.txt", new string[]
        {
            "Guayaquil,Miami,450",
            "Miami,Roma,500",

            "Guayaquil,Amsterdam,800",
            "Amsterdam,Roma,250",

            "Quito,Bogota,120",
            "Bogota,Madrid,700",
            "Madrid,Roma,200",

            "Quito,Amsterdam,850"
        });
    }

    static Dictionary<string, List<(string, int)>> CargarVuelos(string archivo)
    {
        var grafo = new Dictionary<string, List<(string, int)>>();

        foreach (var linea in File.ReadAllLines(archivo))
        {
            var partes = linea.Split(',');

            string origen = partes[0];
            string destino = partes[1];
            int costo = int.Parse(partes[2]);

            if (!grafo.ContainsKey(origen))
                grafo[origen] = new List<(string, int)>();

            grafo[origen].Add((destino, costo));
        }

        return grafo;
    }

    static (Dictionary<string, int>, Dictionary<string, string>) Dijkstra(
        Dictionary<string, List<(string, int)>> grafo, string inicio)
    {
        var distancias = new Dictionary<string, int>();
        var anteriores = new Dictionary<string, string>();
        var visitados = new HashSet<string>();

        foreach (var nodo in grafo.Keys)
            distancias[nodo] = int.MaxValue;

        distancias[inicio] = 0;

        while (visitados.Count < grafo.Count)
        {
            string? actual = null;
            int minDist = int.MaxValue;

            foreach (var nodo in distancias)
            {
                if (!visitados.Contains(nodo.Key) && nodo.Value < minDist)
                {
                    minDist = nodo.Value;
                    actual = nodo.Key;
                }
            }

            if (actual == null) break;

            visitados.Add(actual);

            if (!grafo.ContainsKey(actual)) continue;

            foreach (var vecino in grafo[actual])
            {
                int nuevaDist = distancias[actual] + vecino.Item2;

                if (!distancias.ContainsKey(vecino.Item1) || nuevaDist < distancias[vecino.Item1])
                {
                    distancias[vecino.Item1] = nuevaDist;
                    anteriores[vecino.Item1] = actual;
                }
            }
        }

        return (distancias, anteriores);
    }

    static List<string> ObtenerRuta(Dictionary<string, string> anteriores, string destino)
    {
        var ruta = new List<string>();

        while (destino != null)
        {
            ruta.Insert(0, destino);
            anteriores.TryGetValue(destino, out destino!);
        }

        return ruta;
    }

    static NodoArbol? ConstruirArbol(List<string> ruta)
    {
        if (ruta.Count == 0) return null;

        NodoArbol raiz = new NodoArbol(ruta[0]);
        NodoArbol actual = raiz;

        for (int i = 1; i < ruta.Count; i++)
        {
            actual.Siguiente = new NodoArbol(ruta[i]);
            actual = actual.Siguiente;
        }

        return raiz;
    }

    static void MostrarArbol(NodoArbol? raiz)
    {
        Console.WriteLine("\nArbol de la ruta:");

        NodoArbol? actual = raiz;

        while (actual != null)
        {
            Console.Write(actual.Ciudad);
            if (actual.Siguiente != null)
                Console.Write(" -> ");
            actual = actual.Siguiente;
        }

        Console.WriteLine();
    }

    static void BuscarVuelo(Dictionary<string, List<(string, int)>> grafo)
    {
        Console.Write("Ingrese ciudad de origen: ");
        string origen = Console.ReadLine() ?? "";

        Console.Write("Ingrese ciudad de destino: ");
        string destino = Console.ReadLine() ?? "";

        if (string.IsNullOrWhiteSpace(origen) || string.IsNullOrWhiteSpace(destino))
        {
            Console.WriteLine("Entrada invalida");
            return;
        }

        if (!grafo.ContainsKey(origen))
        {
            Console.WriteLine("Ciudad de origen no valida");
            return;
        }

        var (distancias, anteriores) = Dijkstra(grafo, origen);

        if (!distancias.ContainsKey(destino))
        {
            Console.WriteLine("No existe ruta");
            return;
        }

        var ruta = ObtenerRuta(anteriores, destino);

        Console.WriteLine("\nRuta mas barata:");
        Console.WriteLine(string.Join(" -> ", ruta));
        Console.WriteLine("Costo total: " + distancias[destino]);

        var arbol = ConstruirArbol(ruta);
        MostrarArbol(arbol);
    }

    static void Main()
    {
        CrearArchivo();
        var grafo = CargarVuelos("vuelos.txt");

        int opcion;

        do
        {
            Console.WriteLine("\nSISTEMA DE VUELOS");
            Console.WriteLine("1. Buscar vuelo mas barato");
            Console.WriteLine("2. Salir");
            Console.Write("Seleccione una opcion: ");

            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Opcion invalida");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    BuscarVuelo(grafo);
                    break;
                case 2:
                    Console.WriteLine("Saliendo...");
                    break;
                default:
                    Console.WriteLine("Opcion no valida");
                    break;
            }

        } while (opcion != 2);
    }
}