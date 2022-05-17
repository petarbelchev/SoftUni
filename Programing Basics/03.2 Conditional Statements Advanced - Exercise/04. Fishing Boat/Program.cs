using System;

namespace _04._Fishing_Boat
{
    class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int quantityFishers = int.Parse(Console.ReadLine());
            double shipPrice = 0;

            if (season == "Spring")
            {
                shipPrice = 3000;

            }
            else if (season == "Summer")
            {
                shipPrice = 4200;

            }
            else if (season == "Autumn")
            {
                shipPrice = 4200;

            }
            else if (season == "Winter")
            {
                shipPrice = 2600;

            }
            if (quantityFishers <= 6)
            {
                shipPrice = shipPrice - (shipPrice * 0.1);
                if (quantityFishers % 2 == 0 && season != "Autumn")
                {
                    shipPrice = shipPrice - (shipPrice * 0.05);
                }
            }
            else if (7 <= quantityFishers && quantityFishers <= 11)
            {
                shipPrice = shipPrice - (shipPrice * 0.15);
                if (quantityFishers % 2 == 0 && season != "Autumn")
                {
                    shipPrice = shipPrice - (shipPrice * 0.05);
                }
            }
            else if (quantityFishers >= 12)
            {
                shipPrice = shipPrice - (shipPrice * 0.25);
                if (quantityFishers % 2 == 0 && season != "Autumn")
                {
                    shipPrice = shipPrice - (shipPrice * 0.05);
                }
            }
            if (budget >= shipPrice)
            {
                Console.WriteLine($"Yes! You have {budget - shipPrice:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {shipPrice - budget:f2} leva.");
            }
        }
    }
}
