using System;

#nullable enable

// Clase Nodo
class Nodo
{
    public int Valor;
    public Nodo? Izquierdo;
    public Nodo? Derecho;

    public Nodo(int valor)
    {
        Valor = valor;
        Izquierdo = null;
        Derecho = null;
    }
}

// Clase Árbol Binario de Búsqueda
class ArbolBST
{
    private Nodo? raiz;

    public void Insertar(int valor)
    {
        raiz = InsertarRec(raiz, valor);
    }

    private Nodo InsertarRec(Nodo? nodo, int valor)
    {
        if (nodo == null)
            return new Nodo(valor);

        if (valor < nodo.Valor)
            nodo.Izquierdo = InsertarRec(nodo.Izquierdo, valor);
        else if (valor > nodo.Valor)
            nodo.Derecho = InsertarRec(nodo.Derecho, valor);

        return nodo;
    }

    public bool Buscar(int valor)
    {
        return BuscarRec(raiz, valor);
    }

    private bool BuscarRec(Nodo? nodo, int valor)
    {
        if (nodo == null)
            return false;

        if (valor == nodo.Valor)
            return true;
        else if (valor < nodo.Valor)
            return BuscarRec(nodo.Izquierdo, valor);
        else
            return BuscarRec(nodo.Derecho, valor);
    }

    public void Eliminar(int valor)
    {
        raiz = EliminarRec(raiz, valor);
    }

    private Nodo? EliminarRec(Nodo? nodo, int valor)
    {
        if (nodo == null)
            return null;

        if (valor < nodo.Valor)
            nodo.Izquierdo = EliminarRec(nodo.Izquierdo, valor);
        else if (valor > nodo.Valor)
            nodo.Derecho = EliminarRec(nodo.Derecho, valor);
        else
        {
            if (nodo.Izquierdo == null)
                return nodo.Derecho;
            else if (nodo.Derecho == null)
                return nodo.Izquierdo;

            nodo.Valor = Minimo(nodo.Derecho);
            nodo.Derecho = EliminarRec(nodo.Derecho, nodo.Valor);
        }

        return nodo;
    }

    public int Minimo(Nodo? nodo = null)
    {
        nodo ??= raiz;
        if (nodo == null)
            throw new InvalidOperationException("El árbol está vacío");

        while (nodo.Izquierdo != null)
            nodo = nodo.Izquierdo;
        return nodo.Valor;
    }

    public int Maximo()
    {
        if (raiz == null)
            throw new InvalidOperationException("El árbol está vacío");

        Nodo nodo = raiz;
        while (nodo.Derecho != null)
            nodo = nodo.Derecho;
        return nodo.Valor;
    }

    public int Altura()
    {
        return AlturaRec(raiz);
    }

    private int AlturaRec(Nodo? nodo)
    {
        if (nodo == null)
            return 0;

        int izq = AlturaRec(nodo.Izquierdo);
        int der = AlturaRec(nodo.Derecho);

        return Math.Max(izq, der) + 1;
    }

    public void Inorden()
    {
        InordenRec(raiz);
        Console.WriteLine();
    }

    private void InordenRec(Nodo? nodo)
    {
        if (nodo != null)
        {
            InordenRec(nodo.Izquierdo);
            Console.Write(nodo.Valor + " ");
            InordenRec(nodo.Derecho);
        }
    }

    public void Preorden()
    {
        PreordenRec(raiz);
        Console.WriteLine();
    }

    private void PreordenRec(Nodo? nodo)
    {
        if (nodo != null)
        {
            Console.Write(nodo.Valor + " ");
            PreordenRec(nodo.Izquierdo);
            PreordenRec(nodo.Derecho);
        }
    }

    public void Postorden()
    {
        PostordenRec(raiz);
        Console.WriteLine();
    }

    private void PostordenRec(Nodo? nodo)
    {
        if (nodo != null)
        {
            PostordenRec(nodo.Izquierdo);
            PostordenRec(nodo.Derecho);
            Console.Write(nodo.Valor + " ");
        }
    }

    public void Limpiar()
    {
        raiz = null;
    }
}

// Programa principal con menú
class Program
{
    static void Main()
    {
        ArbolBST arbol = new ArbolBST();
        int opcion = -1;

        do
        {
            Console.WriteLine("\n--- MENÚ ÁRBOL BST ---");
            Console.WriteLine("1. Insertar");
            Console.WriteLine("2. Buscar");
            Console.WriteLine("3. Eliminar");
            Console.WriteLine("4. Recorrido Inorden");
            Console.WriteLine("5. Recorrido Preorden");
            Console.WriteLine("6. Recorrido Postorden");
            Console.WriteLine("7. Mínimo");
            Console.WriteLine("8. Máximo");
            Console.WriteLine("9. Altura");
            Console.WriteLine("10. Limpiar árbol");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");

            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Entrada inválida");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    Console.Write("Ingrese valor: ");
                    if (int.TryParse(Console.ReadLine(), out int valInsertar))
                        arbol.Insertar(valInsertar);
                    else
                        Console.WriteLine("Valor inválido");
                    break;

                case 2:
                    Console.Write("Ingrese valor a buscar: ");
                    if (int.TryParse(Console.ReadLine(), out int valBuscar))
                        Console.WriteLine(arbol.Buscar(valBuscar) ? "Encontrado" : "No encontrado");
                    else
                        Console.WriteLine("Valor inválido");
                    break;

                case 3:
                    Console.Write("Ingrese valor a eliminar: ");
                    if (int.TryParse(Console.ReadLine(), out int valEliminar))
                        arbol.Eliminar(valEliminar);
                    else
                        Console.WriteLine("Valor inválido");
                    break;

                case 4:
                    Console.WriteLine("Inorden:");
                    arbol.Inorden();
                    break;

                case 5:
                    Console.WriteLine("Preorden:");
                    arbol.Preorden();
                    break;

                case 6:
                    Console.WriteLine("Postorden:");
                    arbol.Postorden();
                    break;

                case 7:
                    try
                    {
                        Console.WriteLine("Mínimo: " + arbol.Minimo());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    break;

                case 8:
                    try
                    {
                        Console.WriteLine("Máximo: " + arbol.Maximo());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    break;

                case 9:
                    Console.WriteLine("Altura: " + arbol.Altura());
                    break;

                case 10:
                    arbol.Limpiar();
                    Console.WriteLine("Árbol limpiado");
                    break;
            }

        } while (opcion != 0);
    }
}
