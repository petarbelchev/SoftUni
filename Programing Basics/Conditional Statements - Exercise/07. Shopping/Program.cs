using System;

namespace _07._Shopping
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int videocardsQuantity = int.Parse(Console.ReadLine());
            int processorsQuantity = int.Parse(Console.ReadLine());
            int ramQuantity = int.Parse(Console.ReadLine());

            double videocardsPrice = videocardsQuantity * 250;
            double processorsPrice = (videocardsPrice * 0.35) * processorsQuantity;
            double ramPrice = (videocardsPrice * 0.1) * ramQuantity;

            double totalPrice = videocardsPrice + processorsPrice + ramPrice;

            if (videocardsQuantity > processorsQuantity)
            {
                totalPrice = totalPrice - totalPrice * 0.15;
            }

            if (totalPrice <= budget)
            {
                Console.WriteLine($"You have {budget - totalPrice:f2} leva left!");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {totalPrice - budget:f2} leva more!");
            }
        }
    }
}
