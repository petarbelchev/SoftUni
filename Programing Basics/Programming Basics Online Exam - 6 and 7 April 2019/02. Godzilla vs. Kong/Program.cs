using System;

namespace _05._Godzilla_vs._Kong
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int peopleCount = int.Parse(Console.ReadLine());
            double clothingPricePerMan = double.Parse(Console.ReadLine());

            double clothingPrice = clothingPricePerMan * peopleCount;
            double decorPrice = budget * 0.1;

            if (peopleCount > 150)
            {
                clothingPrice = clothingPrice - (clothingPrice * 0.1);
            }

            if ((decorPrice + clothingPrice) > budget)
            {
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {(decorPrice + clothingPrice) - budget:f2} leva more.");
            }
            else
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {budget - (decorPrice + clothingPrice):f2} leva left.");
            }
        }
    }
}
