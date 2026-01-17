using System;

namespace EstacionamientoIngenieria
{
    class Program
    {
        static void Main(string[] args)
        {
            ListaVehiculos lista = new ListaVehiculos();
            int opcion = -1;

            do
            {
                Console.WriteLine("\n===== MENU ESTACIONAMIENTO =====");
                Console.WriteLine("1. Agregar vehículo");
                Console.WriteLine("2. Buscar vehículo por placa");
                Console.WriteLine("3. Ver vehículos por año");
                Console.WriteLine("4. Ver todos los vehículos");
                Console.WriteLine("5. Eliminar vehículo");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opción: ");

                int.TryParse(Console.ReadLine(), out opcion);

                switch (opcion)
                {
                    case 1:
                        Console.Write("Placa: ");
                        string placa = Console.ReadLine() ?? "";

                        Console.Write("Marca: ");
                        string marca = Console.ReadLine() ?? "";

                        Console.Write("Modelo: ");
                        string modelo = Console.ReadLine() ?? "";

                        Console.Write("Año: ");
                        int.TryParse(Console.ReadLine(), out int año);

                        Console.Write("Precio: ");
                        double.TryParse(Console.ReadLine(), out double precio);

                        lista.Agregar(placa, marca, modelo, año, precio);
                        Console.WriteLine("Vehículo agregado correctamente.");
                        break;

                    case 2:
                        Console.Write("Ingrese placa a buscar: ");
                        lista.Buscar(Console.ReadLine() ?? "");
                        break;

                    case 3:
                        Console.Write("Ingrese año a filtrar: ");
                        int.TryParse(Console.ReadLine(), out int a);
                        lista.MostrarPorAño(a);
                        break;

                    case 4:
                        lista.MostrarTodos();
                        break;

                    case 5:
                        Console.Write("Ingrese placa a eliminar: ");
                        lista.Eliminar(Console.ReadLine() ?? "");
                        break;
                }

            } while (opcion != 0);
        }
    }

    // 👉 Nodo
    class Nodo
    {
        public string placa, marca, modelo;
        public int año;
        public double precio;
        public Nodo? siguiente;

        public Nodo(string p, string m, string mo, int a, double pr)
        {
            placa = p;
            marca = m;
            modelo = mo;
            año = a;
            precio = pr;
            siguiente = null;
        }
    }

    // 👉 Lista enlazada
    class ListaVehiculos
    {
        private Nodo? cabeza;

        public void Agregar(string p, string m, string mo, int a, double pr)
        {
            Nodo nuevo = new Nodo(p, m, mo, a, pr);

            if (cabeza == null)
                cabeza = nuevo;
            else
            {
                Nodo aux = cabeza;
                while (aux.siguiente != null)
                    aux = aux.siguiente;
                aux.siguiente = nuevo;
            }
        }

        public void Buscar(string placa)
        {
            Nodo? aux = cabeza;
            while (aux != null)
            {
                if (aux.placa == placa)
                {
                    MostrarVehiculo(aux);
                    return;
                }
                aux = aux.siguiente;
            }
            Console.WriteLine("Vehículo no encontrado.");
        }

        public void MostrarPorAño(int año)
        {
            Nodo? aux = cabeza;
            bool encontrado = false;

            while (aux != null)
            {
                if (aux.año == año)
                {
                    MostrarVehiculo(aux);
                    encontrado = true;
                }
                aux = aux.siguiente;
            }

            if (!encontrado)
                Console.WriteLine("No hay vehículos de ese año.");
        }

        public void MostrarTodos()
        {
            Nodo? aux = cabeza;

            if (aux == null)
            {
                Console.WriteLine("No hay vehículos registrados.");
                return;
            }

            while (aux != null)
            {
                MostrarVehiculo(aux);
                aux = aux.siguiente;
            }
        }

        public void Eliminar(string placa)
        {
            if (cabeza == null)
            {
                Console.WriteLine("Lista vacía.");
                return;
            }

            if (cabeza.placa == placa)
            {
                cabeza = cabeza.siguiente;
                Console.WriteLine("Vehículo eliminado.");
                return;
            }

            Nodo aux = cabeza;
            while (aux.siguiente != null && aux.siguiente.placa != placa)
                aux = aux.siguiente;

            if (aux.siguiente != null)
            {
                aux.siguiente = aux.siguiente.siguiente;
                Console.WriteLine("Vehículo eliminado.");
            }
            else
                Console.WriteLine("Vehículo no encontrado.");
        }

        private void MostrarVehiculo(Nodo v)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine($"Placa: {v.placa}");
            Console.WriteLine($"Marca: {v.marca}");
            Console.WriteLine($"Modelo: {v.modelo}");
            Console.WriteLine($"Año: {v.año}");
            Console.WriteLine($"Precio: {v.precio}");
        }
    }
}
