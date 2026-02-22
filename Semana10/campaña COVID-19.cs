using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine("==== Campaña de Vacunación COVID-19 ====\n");

        // Universo de 500 ciudadanos
        HashSet<int> ciudadanos = new HashSet<int>(Enumerable.Range(1, 500));

        Random random = new Random();

        // 75 vacunados con Pfizer
        HashSet<int> pfizer = new HashSet<int>();
        while (pfizer.Count < 75)
            pfizer.Add(random.Next(1, 501));

        // 75 vacunados con AstraZeneca
        HashSet<int> astraZeneca = new HashSet<int>();
        while (astraZeneca.Count < 75)
            astraZeneca.Add(random.Next(1, 501));

        // Operaciones de conjuntos
        var ambasDosis = pfizer.Intersect(astraZeneca).OrderBy(x => x);
        var soloPfizer = pfizer.Except(astraZeneca).OrderBy(x => x);
        var soloAstraZeneca = astraZeneca.Except(pfizer).OrderBy(x => x);
        var vacunados = pfizer.Union(astraZeneca);
        var noVacunados = ciudadanos.Except(vacunados).OrderBy(x => x);

        // 📊 Resumen
        Console.WriteLine($"Total ciudadanos: {ciudadanos.Count}");
        Console.WriteLine($"Vacunados con Pfizer: {pfizer.Count}");
        Console.WriteLine($"Vacunados con AstraZeneca: {astraZeneca.Count}");
        Console.WriteLine($"Vacunados (al menos una dosis): {vacunados.Count()}");
        Console.WriteLine($"No vacunados: {noVacunados.Count()}");
        Console.WriteLine($"Ambas dosis: {ambasDosis.Count()}");
        Console.WriteLine($"Solo Pfizer: {soloPfizer.Count()}");
        Console.WriteLine($"Solo AstraZeneca: {soloAstraZeneca.Count()}");

        // 📋 Listados

        Console.WriteLine("\n--- Ciudadanos No Vacunados ---");
        foreach (var c in noVacunados)
            Console.WriteLine("Ciudadano " + c);

        Console.WriteLine("\n--- Ciudadanos con Ambas Dosis ---");
        foreach (var c in ambasDosis)
            Console.WriteLine("Ciudadano " + c);

        Console.WriteLine("\n--- Ciudadanos Solo Pfizer ---");
        foreach (var c in soloPfizer)
            Console.WriteLine("Ciudadano " + c);

        Console.WriteLine("\n--- Ciudadanos Solo AstraZeneca ---");
        foreach (var c in soloAstraZeneca)
            Console.WriteLine("Ciudadano " + c);
    }
}
