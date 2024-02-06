using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<double> salaries = new List<double>();

        Console.WriteLine("Skriv in dina senaste månadslöner. Avsluta med att skriva 0.");

        double salary;
        do
        {
            Console.Write("Ange månadslön (0 för att avsluta): ");
            while (!double.TryParse(Console.ReadLine(), out salary))
            {
                Console.WriteLine("Felaktig inmatning. Försök igen.");
                Console.Write("Ange månadslön (0 för att avsluta): ");
            }

            if (salary != 0)
            {
                salaries.Add(salary);
            }
        } while (salary != 0);

        if (salaries.Count > 0)
        {
            double averageSalary = salaries.Average();
            double medianSalary = CalculateMedian(salaries);

            Console.WriteLine($"Din medellön är: {averageSalary:C}");
            Console.WriteLine($"Din medianlön är: {medianSalary:C}");
        }
        else
        {
            Console.WriteLine("Inga löner angivna.");
        }
    }

    static double CalculateMedian(List<double> salaries)
    {
        // Först sorterar vi lönelistan
        salaries.Sort();

        int count = salaries.Count;
        if (count % 2 == 0)
        {
            // Jämnt antal löner, medianen är genomsnittet av de två mittersta värdena
            return (salaries[count / 2 - 1] + salaries[count / 2]) / 2;
        }
        else
        {
            // Udda antal löner, medianen är det mittersta värdet
            return salaries[count / 2];
        }
    }
}