using System;

namespace FigurasGeometricas
{
  
    // Clase Circulo
    // Esta clase representa un círculo y encapsula su radio.
    // Incluye métodos para calcular su área y su perímetro.
    
    public class Circulo
    {
        private double radio; // Encapsulación del dato

        // Propiedad pública para acceder y modificar el radio
        public double Radio
        {
            get { return radio; }
            set
            {
                // Validación básica para evitar valores negativos
                if (value > 0)
                    radio = value;
            }
        }

        // Método para calcular el área del círculo
        // Fórmula: A = π * r^2
        public double CalcularArea()
        {
            return Math.PI * radio * radio;
        }

        // Método para calcular el perímetro del círculo
        // Fórmula: P = 2 * π * r
        public double CalcularPerimetro()
        {
            return 2 * Math.PI * radio;
        }
    }



    // Clase Cuadrado
    // Esta clase representa un cuadrado y encapsula su lado.
    // Incluye métodos para calcular su área y su perímetro.

    public class Cuadrado
    {
        private double lado; // Encapsulación del dato

        // Propiedad pública para acceder y modificar el lado
        public double Lado
        {
            get { return lado; }
            set
            {
                if (value > 0)
                    lado = value;
            }
        }

        // Método para calcular el área del cuadrado
        // Fórmula: A = lado * lado
        public double CalcularArea()
        {
            return lado * lado;
        }

        // Método para calcular el perímetro del cuadrado
        // Fórmula: P = 4 * lado
        public double CalcularPerimetro()
        {
            return 4 * lado;
        }
    }


    // Clase principal Program con método Main
  
    class Program
    {
        static void Main()
        {
            // Crear un círculo con radio 5
            Circulo c = new Circulo();
            c.Radio = 5;

            Console.WriteLine("Círculo (radio = 5)");
            Console.WriteLine("Área: " + c.CalcularArea());
            Console.WriteLine("Perímetro: " + c.CalcularPerimetro());
            Console.WriteLine();

            // Crear un cuadrado con lado 4
            Cuadrado q = new Cuadrado();
            q.Lado = 4;

            Console.WriteLine("Cuadrado (lado = 4)");
            Console.WriteLine("Área: " + q.CalcularArea());
            Console.WriteLine("Perímetro: " + q.CalcularPerimetro());

            Console.WriteLine("\nPresione una tecla para salir...");
            Console.ReadKey();
        }
    }
}


