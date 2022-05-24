using System;

namespace _03._Gaming_Store
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double currBalance = double.Parse(Console.ReadLine());
            double totalSpent = 0;
            double price = 0;
            string gameToBuy = Console.ReadLine();
            while (gameToBuy != "Game Time")
            {
                switch (gameToBuy)
                {
                    case "OutFall 4":
                    case "RoverWatch Origins Edition":
                        price = 39.99;
                        break;
                    case "CS: OG":
                        price = 15.99;
                        break;
                    case "Zplinter Zell":
                        price = 19.99;
                        break;
                    case "Honored 2":
                        price = 59.99;
                        break;
                    case "RoverWatch":
                        price = 29.99;
                        break;
                    default:
                        Console.WriteLine("Not Found");
                        gameToBuy = Console.ReadLine();
                        continue;
                }
                if (currBalance >= price)
                {
                    totalSpent += price;
                    currBalance -= price;
                    Console.WriteLine($"Bought {gameToBuy}");
                }
                else
                {
                    Console.WriteLine("Too Expensive");
                }
                if (currBalance == 0)
                {
                    Console.WriteLine("Out of money!");
                    return;
                }
                gameToBuy = Console.ReadLine();
            }
            Console.WriteLine($"Total spent: ${totalSpent:f2}. Remaining: ${currBalance:f2}");
        }
    }
}
