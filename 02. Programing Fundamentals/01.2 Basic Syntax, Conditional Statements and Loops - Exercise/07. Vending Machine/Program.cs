using System;

namespace _07._Vending_Machine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double coins = 0;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Start")
                {
                    break;
                }
                else
                {
                    double currCoin = double.Parse(input);

                    if (currCoin == 0.1 || currCoin == 0.2 || currCoin == 0.5 || currCoin == 1 || currCoin == 2)
                    {
                        coins += currCoin;
                    }
                    else
                    {
                        Console.WriteLine($"Cannot accept {currCoin}");
                    }
                }
            }

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Nuts")
                {
                    if (coins >= 2)
                    {
                        Console.WriteLine("Purchased nuts");
                        coins -= 2;
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
                else if (input == "Water")
                {
                    if (coins >= 0.7)
                    {
                        Console.WriteLine("Purchased water");
                        coins -= 0.7;
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
                else if (input == "Crisps")
                {
                    if (coins >= 1.5)
                    {
                        Console.WriteLine("Purchased crisps");
                        coins -= 1.5;
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
                else if (input == "Soda")
                {
                    if (coins >= 0.8)
                    {
                        Console.WriteLine("Purchased soda");
                        coins -= 0.8;
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
                else if (input == "Coke")
                {
                    if (coins >= 1)
                    {
                        Console.WriteLine("Purchased coke");
                        coins -= 1;
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
                else if (input == "End")
                {
                    Console.WriteLine($"Change: {coins:f2}");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid product");
                }
            }
        }
    }
}
