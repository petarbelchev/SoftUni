using System;

namespace _05._Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            string place = null;
            string location = null;
            double price = 0;

            if (budget <= 1000)
            {
                place = "Camp";

                if (season == "Summer")
                {
                    location = "Alaska";
                    price = budget * 0.65;
                }
                else
                {
                    location = "Morocco";
                    price = budget * 0.45;
                }
            }
            else if (budget > 1000 && budget <= 3000)
            {
                place = "Hut";

                if (season == "Summer")
                {
                    location = "Alaska";
                    price = budget * 0.8;

                }
                else
                {
                    location = "Morocco";
                    price = budget * 0.6;
                }
            }
            else if (budget > 3000)
            {
                place = "Hotel";

                if (season == "Summer")
                {
                    location = "Alaska";
                    price = budget * 0.9;
                }
                else
                {
                    location = "Morocco";
                    price = budget * 0.9;
                }
            }

            Console.WriteLine($"{location} - {place} - {price:f2}");
        }
    }
}
