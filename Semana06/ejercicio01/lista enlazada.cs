using System;
using System.Collections.Generic;

namespace AsignaturasRepetir
{
    class Program
    {
        static void Main(string[] args)
        {
            ListaEnlazada lista = new ListaEnlazada();

            lista.Agregar(1);
            lista.Agregar(2);
            lista.Agregar(3);
            lista.Agregar(4);

            Console.WriteLine("Lista original:");
            lista.Mostrar();

            lista.Invertir();

            Console.WriteLine("\nLista invertida:");
            lista.Mostrar();

            Console.ReadKey();
        }
    }

    // Clase Nodo
    class Nodo
    {
        public int dato;
        public Nodo? siguiente;

        public Nodo(int valor)
        {
            dato = valor;
            siguiente = null;
        }
    }

    // Clase Lista Enlazada
    class ListaEnlazada
    {
        private Nodo? cabeza;

        public void Agregar(int valor)
        {
            Nodo nuevo = new Nodo(valor);

            if (cabeza == null)
            {
                cabeza = nuevo;
            }
            else
            {
                Nodo aux = cabeza;
                while (aux.siguiente != null)
                {
                    aux = aux.siguiente;
                }
                aux.siguiente = nuevo;
            }
        }

        // 👉 Método para invertir la lista enlazada
        public void Invertir()
        {
            Nodo? anterior = null;
            Nodo? actual = cabeza;
            Nodo? siguiente = null;

            while (actual != null)
            {
                siguiente = actual.siguiente;
                actual.siguiente = anterior;
                anterior = actual;
                actual = siguiente;
            }

            cabeza = anterior;
        }

        public void Mostrar()
        {
            Nodo? aux = cabeza;
            while (aux != null)
            {
                Console.Write(aux.dato + " -> ");
                aux = aux.siguiente;
            }
            Console.WriteLine("null");
        }
    }
}

