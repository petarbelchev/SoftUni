using System;

namespace _01._Match_Tickets
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string category = Console.ReadLine();
            int groupQuantity = int.Parse(Console.ReadLine());
            double transportPrice = 0;

            if (groupQuantity >= 1 && groupQuantity <= 4)
            {
                transportPrice = budget * 0.75;
            }
            else if (groupQuantity >= 5 && groupQuantity <= 9)
            {
                transportPrice = budget * 0.6;
            }
            else if (groupQuantity >= 10 && groupQuantity <= 24)
            {
                transportPrice = budget * 0.5;
            }
            else if (groupQuantity >= 25 && groupQuantity <= 49)
            {
                transportPrice = budget * 0.4;
            }
            else if (groupQuantity > 50)
            {
                transportPrice = budget * 0.25;
            }

            double ticketPrice = 0;

            if (category == "VIP")
            {
                ticketPrice = 499.99 * groupQuantity;
            }
            else if (category == "Normal")
            {
                ticketPrice = 249.99 * groupQuantity;
            }

            double isMoneyEnough = budget - transportPrice - ticketPrice;


            if (isMoneyEnough >= 0)
            {
                Console.WriteLine($"Yes! You have {isMoneyEnough:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {Math.Abs(isMoneyEnough):f2} leva.");
            }
        }
    }
}
