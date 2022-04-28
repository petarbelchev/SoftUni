using System;

namespace _06._Truck_Driver
{
    class Program
    {
        static void Main(string[] args)
        {
            string season = Console.ReadLine();
            double kilometers = double.Parse(Console.ReadLine());
            double pricePerKm = 0;

            if (kilometers > 10000 && kilometers <= 20000)
            {
                pricePerKm = 1.45;
            }
            else if (season == "Spring" || season == "Autumn")
            {
                if (kilometers <= 5000)
                {
                    pricePerKm = 0.75;
                }
                else if (kilometers > 5000 && kilometers <= 10000)
                {
                    pricePerKm = 0.95;
                }
            }
            else if (season == "Summer")
            {
                if (kilometers <= 5000)
                {
                    pricePerKm = 0.9;
                }
                else if (kilometers > 5000 && kilometers <= 10000)
                {
                    pricePerKm = 1.1;
                }
            }
            else if (season == "Winter")
            {
                if (kilometers <= 5000)
                {
                    pricePerKm = 1.05;
                }
                else if (kilometers > 5000 && kilometers <= 10000)
                {
                    pricePerKm = 1.25;
                }
            }

            double salary = (kilometers * 4) * pricePerKm - (((kilometers * 4) * pricePerKm) * 0.1);

            Console.WriteLine($"{salary:f2}");
        }
    }
}
