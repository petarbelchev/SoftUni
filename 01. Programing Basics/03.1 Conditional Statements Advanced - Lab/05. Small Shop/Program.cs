using System;

namespace _05._Small_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            string city = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());

            switch (city)
            {
                case "Sofia":
                    if (product == "coffee")
                    {
                        Console.WriteLine(quantity * 0.5);
                    }
                    else if (product == "water")
                    {
                        Console.WriteLine(quantity * 0.8);
                    }
                    else if (product == "beer")
                    {
                        Console.WriteLine(quantity * 1.2);
                    }
                    else if (product == "sweets")
                    {
                        Console.WriteLine(quantity * 1.45);
                    }
                    else if (product == "peanuts")
                    {
                        Console.WriteLine(quantity * 1.6);
                    }
                    break;

                case "Plovdiv":
                    if (product == "coffee")
                    {
                        Console.WriteLine(quantity * 0.40);
                    }
                    else if (product == "water")
                    {
                        Console.WriteLine(quantity * 0.70);
                    }
                    else if (product == "beer")
                    {
                        Console.WriteLine(quantity * 1.15);
                    }
                    else if (product == "sweets")
                    {
                        Console.WriteLine(quantity * 1.30);
                    }
                    else if (product == "peanuts")
                    {
                        Console.WriteLine(quantity * 1.50);
                    }
                    break;

                case "Varna":
                    if (product == "coffee")
                    {
                        Console.WriteLine(quantity * 0.45);
                    }
                    else if (product == "water")
                    {
                        Console.WriteLine(quantity * 0.70);
                    }
                    else if (product == "beer")
                    {
                        Console.WriteLine(quantity * 1.1);
                    }
                    else if (product == "sweets")
                    {
                        Console.WriteLine(quantity * 1.35);
                    }
                    else if (product == "peanuts")
                    {
                        Console.WriteLine(quantity * 1.55);
                    }
                    break;
            }
        }
    }
}
