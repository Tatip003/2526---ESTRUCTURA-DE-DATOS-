using System;
using System.Collections.Generic;

namespace TorresDeHanoiConPilas
{
    class Program
    {
        // Función principal: pide el número de discos y crea las torres
        static void Main(string[] args)
        {
            Console.Write("Ingrese el número de discos: ");
            string? entrada = Console.ReadLine();

            if (!int.TryParse(entrada, out int n) || n <= 0)
            {
                Console.WriteLine("Por favor ingrese un número entero positivo.");
                return;
            }

            // Torres representadas como pilas
            Stack<int> origen = new Stack<int>();
            Stack<int> auxiliar = new Stack<int>();
            Stack<int> destino = new Stack<int>();

            // Se cargan los discos en la torre origen
            for (int i = n; i >= 1; i--)
            {
                origen.Push(i);
            }

            Console.WriteLine("\n--- Movimientos de las Torres de Hanoi ---\n");

            // Llamada al método recursivo
            ResolverHanoi(n, origen, destino, auxiliar, "Origen", "Destino", "Auxiliar");

            Console.WriteLine("\nProceso finalizado.");
            Console.ReadKey();
        }

        // Método recursivo que resuelve el problema de las Torres de Hanoi
        static void ResolverHanoi(int n, Stack<int> origen, Stack<int> destino, Stack<int> auxiliar,
                                  string nombreOrigen, string nombreDestino, string nombreAuxiliar)
        {
            // Caso base: mover un solo disco
            if (n == 1)
            {
                int disco = origen.Pop();
                destino.Push(disco);
                Console.WriteLine($"Mover disco {disco} de {nombreOrigen} a {nombreDestino}");
            }
            else
            {
                ResolverHanoi(n - 1, origen, auxiliar, destino,
                              nombreOrigen, nombreAuxiliar, nombreDestino);

                int disco = origen.Pop();
                destino.Push(disco);
                Console.WriteLine($"Mover disco {disco} de {nombreOrigen} a {nombreDestino}");

                ResolverHanoi(n - 1, auxiliar, destino, origen,
                              nombreAuxiliar, nombreDestino, nombreOrigen);
            }
        }
    }
}
