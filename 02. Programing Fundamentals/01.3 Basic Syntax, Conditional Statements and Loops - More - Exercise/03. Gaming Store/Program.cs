using System;

namespace _03._Gaming_Store
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double currBalance = double.Parse(Console.ReadLine());
            double totalSpent = 0;
            string gameToBuy = Console.ReadLine();

            while (gameToBuy != "Game Time")
            {
                switch (gameToBuy)
                {
                    case "OutFall 4":
                    case "RoverWatch Origins Edition":
                        if (currBalance >= 39.99)
                        {
                            totalSpent += 39.99;
                            currBalance -= 39.99;
                            Console.WriteLine($"Bought {gameToBuy}");
                        }
                        else
                        {
                            Console.WriteLine("Too Expensive");
                        }
                        break;

                    case "CS: OG":
                        if (currBalance >= 15.99)
                        {
                            totalSpent += 15.99;
                            currBalance -= 15.99;
                            Console.WriteLine($"Bought {gameToBuy}");
                        }
                        else
                        {
                            Console.WriteLine("Too Expensive");
                        }
                        break;

                    case "Zplinter Zell":
                        if (currBalance >= 19.99)
                        {
                            totalSpent += 19.99;
                            currBalance -= 19.99;
                            Console.WriteLine($"Bought {gameToBuy}");
                        }
                        else
                        {
                            Console.WriteLine("Too Expensive");
                        }
                        break;

                    case "Honored 2":
                        if (currBalance >= 59.99)
                        {
                            totalSpent += 59.99;
                            currBalance -= 59.99;
                            Console.WriteLine($"Bought {gameToBuy}");
                        }
                        else
                        {
                            Console.WriteLine("Too Expensive");
                        }
                        break;

                    case "RoverWatch":
                        if (currBalance >= 29.99)
                        {
                            totalSpent += 29.99;
                            currBalance -= 29.99;
                            Console.WriteLine($"Bought {gameToBuy}");
                        }
                        else
                        {
                            Console.WriteLine("Too Expensive");
                        }
                        break;

                    default:
                        Console.WriteLine("Not Found");
                        break;
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
