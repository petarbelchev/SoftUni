using System;

namespace _05._Journey
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            double spend = 0;
            string place = null;

            if (budget <= 100)
            {
                if (season == "summer")
                {
                    spend = budget * 0.3;
                    place = "Camp";
                }
                else
                {
                    spend = budget * 0.7;
                    place = "Hotel";
                }
                Console.WriteLine("Somewhere in Bulgaria");
                Console.WriteLine($"{place} - {spend:f2}");
            }
            else if (100 < budget && budget <= 1000)
            {
                if (season == "summer")
                {
                    spend = budget * 0.4;
                    place = "Camp";
                }
                else
                {
                    spend = budget * 0.8;
                    place = "Hotel";
                }
                Console.WriteLine("Somewhere in Balkans");
                Console.WriteLine($"{place} - {spend:f2}");
            }
            else
            {
                spend = budget * 0.9;
                place = "Hotel";

                Console.WriteLine("Somewhere in Europe");
                Console.WriteLine($"{place} - {spend:f2}");
            }
        }
    }
}
