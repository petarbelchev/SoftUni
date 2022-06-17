using System;

namespace _01._Computer_Store
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double priceSum = 0;

            string input = Console.ReadLine();

            while (true)
            {
                if (input == "special" || input == "regular")
                {
                    break;
                }

                double price = double.Parse(input);

                if (price < 0)
                {
                    Console.WriteLine("Invalid price!");
                    input = Console.ReadLine();
                    continue;
                }

                priceSum += double.Parse(input);

                input = Console.ReadLine();
            }

            double taxes = priceSum * 0.2;

            double priceWithTax = priceSum + taxes;

            if (input == "special")
            {
                priceWithTax -= priceWithTax * 0.1;
            }

            if (priceWithTax <= 0)
            {
                Console.WriteLine("Invalid order!");
                return;
            }

            Console.WriteLine($"Congratulations you've just bought a new computer!");
            Console.WriteLine($"Price without taxes: {priceSum:f2}$");
            Console.WriteLine($"Taxes: {taxes:f2}$");
            Console.WriteLine("-----------");
            Console.WriteLine($"Total price: {priceWithTax:f2}$");
        }
    }
}
