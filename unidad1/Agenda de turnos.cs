using System;

namespace AgendaClinica
{
    // STRUCT: Representa un registro simple de un turno médico
    // Se usa para almacenar datos relacionados de forma compacta
    public struct Turno
    {
        public int IdTurno;              // Identificador único del turno
        public string NombrePaciente;    // Nombre del paciente
        public string Fecha;             // Fecha del turno
        public string Hora;              // Hora del turno
    }

    // CLASE: Aplica Programación Orientada a Objetos
    // Se encarga de gestionar la agenda de turnos
    public class AgendaTurnos
    {
        private Turno[] turnos;   // Array que almacena los turnos registrados
        private int contador;     // Contador de turnos registrados

        // Constructor: inicializa el array con una capacidad definida
        public AgendaTurnos(int capacidad)
        {
            turnos = new Turno[capacidad];
            contador = 0;
        }

        // Método para registrar un nuevo turno
        public void AgregarTurno()
        {
            // Verifica si la agenda ya está llena
            if (contador >= turnos.Length)
            {
                Console.WriteLine("Agenda llena. No se pueden agregar más turnos.");
                return;
            }

            // Se crea un nuevo turno
            Turno nuevoTurno = new Turno();

            try
            {
                // Solicita y lee el ID del turno
                Console.Write("Ingrese ID del turno: ");
                nuevoTurno.IdTurno = int.Parse(Console.ReadLine());

                // Solicita y lee el nombre del paciente
                Console.Write("Ingrese nombre del paciente: ");
                nuevoTurno.NombrePaciente = Console.ReadLine();

                // Solicita y lee la fecha del turno
                Console.Write("Ingrese fecha (dd/mm/yyyy): ");
                nuevoTurno.Fecha = Console.ReadLine();

                // Solicita y lee la hora del turno
                Console.Write("Ingrese hora (hh:mm): ");
                nuevoTurno.Hora = Console.ReadLine();

                // Guarda el turno en el array
                turnos[contador] = nuevoTurno;
                contador++;

                Console.WriteLine("Turno registrado correctamente.");
            }
            catch (FormatException)
            {
                // Controla errores de conversión de datos
                Console.WriteLine("Error: El ID debe ser un número entero.");
            }
            catch (Exception ex)
            {
                // Captura cualquier otro error inesperado
                Console.WriteLine($"Error inesperado: {ex.Message}");
            }
        }

        // Método de reportería: muestra todos los turnos registrados
        public void MostrarTurnos()
        {
            Console.WriteLine("\n=== LISTA DE TURNOS ===");

            // Verifica si existen turnos registrados
            if (contador == 0)
            {
                Console.WriteLine("No hay turnos registrados.");
                return;
            }

            // Recorre el array y muestra cada turno
            for (int i = 0; i < contador; i++)
            {
                Console.WriteLine($"Turno #{i + 1}");
                Console.WriteLine($"ID: {turnos[i].IdTurno}");
                Console.WriteLine($"Paciente: {turnos[i].NombrePaciente}");
                Console.WriteLine($"Fecha: {turnos[i].Fecha}");
                Console.WriteLine($"Hora: {turnos[i].Hora}");
                Console.WriteLine("------------------------");
            }
        }

        // Método de reportería: consulta un turno específico por ID
        public void ConsultarTurno()
        {
            try
            {
                // Solicita el ID a buscar
                Console.Write("Ingrese ID del turno a consultar: ");
                int id = int.Parse(Console.ReadLine());
                bool encontrado = false;

                // Busca el turno dentro del array
                for (int i = 0; i < contador; i++)
                {
                    if (turnos[i].IdTurno == id)
                    {
                        Console.WriteLine("\n=== TURNO ENCONTRADO ===");
                        Console.WriteLine($"ID: {turnos[i].IdTurno}");
                        Console.WriteLine($"Paciente: {turnos[i].NombrePaciente}");
                        Console.WriteLine($"Fecha: {turnos[i].Fecha}");
                        Console.WriteLine($"Hora: {turnos[i].Hora}");
                        encontrado = true;
                        break;
                    }
                }

                // Mensaje si no se encuentra el turno
                if (!encontrado)
                {
                    Console.WriteLine("Turno no encontrado.");
                }
            }
            catch (FormatException)
            {
                // Controla errores de ingreso de datos
                Console.WriteLine("Error: Debe ingresar un número entero válido.");
            }
        }
    }

    // Clase principal del programa
    class Program
    {
        static void Main(string[] args)
        {
            // Se crea la agenda con capacidad para 10 turnos
            AgendaTurnos agenda = new AgendaTurnos(10);
            int opcion;

            // Menú principal del sistema
            do
            {
                try
                {
                    Console.WriteLine("\n=== AGENDA DE TURNOS - CLÍNICA ===");
                    Console.WriteLine("1. Registrar turno");
                    Console.WriteLine("2. Mostrar turnos");
                    Console.WriteLine("3. Consultar turno");
                    Console.WriteLine("4. Salir");
                    Console.Write("Seleccione una opción: ");
                    opcion = int.Parse(Console.ReadLine());

                    // Control de opciones mediante switch
                    switch (opcion)
                    {
                        case 1:
                            agenda.AgregarTurno();
                            break;
                        case 2:
                            agenda.MostrarTurnos();
                            break;
                        case 3:
                            agenda.ConsultarTurno();
                            break;
                        case 4:
                            Console.WriteLine("Saliendo del sistema...");
                            break;
                        default:
                            Console.WriteLine("Opción inválida. Intente de nuevo.");
                            break;
                    }
                }
                catch (FormatException)
                {
                    // Maneja errores cuando no se ingresa un número
                    Console.WriteLine("Error: Debe ingresar un número entero válido.");
                    opcion = 0;
                }
                catch (Exception ex)
                {
                    // Maneja errores inesperados
                    Console.WriteLine($"Error inesperado: {ex.Message}");
                    opcion = 0;
                }

            } while (opcion != 4);
        }
    }
}
