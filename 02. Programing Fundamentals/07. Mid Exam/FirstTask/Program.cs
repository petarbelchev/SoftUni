using System;

namespace FirstTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numCities = int.Parse(Console.ReadLine());
            double totalProfit = 0;

            for (int city = 1; city <= numCities; city++)
            {
                string name = Console.ReadLine();
                double income = double.Parse(Console.ReadLine());
                double expenses = double.Parse(Console.ReadLine());

                if (city % 3 == 0 && city % 5 != 0)
                {
                    expenses += expenses * 0.5;
                }

                if (city % 5 == 0)
                {
                    income -= income * 0.1;
                }

                double profit = income - expenses;

                totalProfit += profit;

                Console.WriteLine($"In {name} Burger Bus earned {profit:f2} leva.");
            }

            Console.WriteLine($"Burger Bus total profit: {totalProfit:f2} leva.");
        }
    }
}
