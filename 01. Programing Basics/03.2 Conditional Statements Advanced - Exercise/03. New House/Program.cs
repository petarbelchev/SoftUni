using System;

namespace _03._New_House
{
    class Program
    {
        static void Main(string[] args)
        {
            string flowers = Console.ReadLine();
            int Quantity = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());

            if (flowers == "Roses")
            {
                double price = Quantity * 5;
                if (Quantity > 80)
                {
                    price = price - (price * 0.1);
                }
                if (budget >= price)
                {
                    Console.WriteLine($"Hey, you have a great garden with {Quantity} {flowers} and {budget - price:f2} leva left.");
                }
                else
                {
                    Console.WriteLine($"Not enough money, you need {price - budget:f2} leva more.");
                }
            }
            else if (flowers == "Dahlias")
            {
                double price = Quantity * 3.8;
                if (Quantity > 90)
                {
                    price = price - (price * 0.15);
                }
                if (budget >= price)
                {
                    Console.WriteLine($"Hey, you have a great garden with {Quantity} {flowers} and {budget - price:f2} leva left.");
                }
                else
                {
                    Console.WriteLine($"Not enough money, you need {price - budget:f2} leva more.");
                }
            }
            else if (flowers == "Tulips")
            {
                double price = Quantity * 2.8;
                if (Quantity > 80)
                {
                    price = price - (price * 0.15);
                }
                if (budget >= price)
                {
                    Console.WriteLine($"Hey, you have a great garden with {Quantity} {flowers} and {budget - price:f2} leva left.");
                }
                else
                {
                    Console.WriteLine($"Not enough money, you need {price - budget:f2} leva more.");
                }
            }
            else if (flowers == "Narcissus")
            {
                double price = Quantity * 3;
                if (Quantity < 120)
                {
                    price = price + (price * 0.15);
                }
                if (budget >= price)
                {
                    Console.WriteLine($"Hey, you have a great garden with {Quantity} {flowers} and {budget - price:f2} leva left.");
                }
                else
                {
                    Console.WriteLine($"Not enough money, you need {price - budget:f2} leva more.");
                }
            }
            else if (flowers == "Gladiolus")
            {
                double price = Quantity * 2.5;
                if (Quantity < 80)
                {
                    price = price + (price * 0.2);
                }
                if (budget >= price)
                {
                    Console.WriteLine($"Hey, you have a great garden with {Quantity} {flowers} and {budget - price:f2} leva left.");
                }
                else
                {
                    Console.WriteLine($"Not enough money, you need {price - budget:f2} leva more.");
                }
            }
        }
    }
}
