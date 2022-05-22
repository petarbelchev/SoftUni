using System;

namespace _12._Trade_Commissions
{
    class Program
    {
        static void Main(string[] args)
        {
            string city = Console.ReadLine();
            double selles = double.Parse(Console.ReadLine());
            
            switch (city)
            {
                case "Sofia":
                    if (selles >= 0 && selles <= 500)
                    {
                        Console.WriteLine($"{selles * 0.05:f2}");
                    }
                    else if (500 < selles && selles <= 1000)
                    {
                        Console.WriteLine($"{selles * 0.07:f2}");
                    }
                    else if (1000 < selles && selles <= 10000)
                    {
                        Console.WriteLine($"{selles * 0.08:f2}");
                    }
                    else if (selles > 10000)
                    {
                        Console.WriteLine($"{selles * 0.12:f2}");
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                    break;


                case "Plovdiv":
                    if (selles >= 0 && selles <= 500)
                    {
                        Console.WriteLine($"{selles * 0.055:f2}");
                    }
                    else if (500 < selles && selles <= 1000)
                    {
                        Console.WriteLine($"{selles * 0.08:f2}");
                    }
                    else if (1000 < selles && selles <= 10000)
                    {
                        Console.WriteLine($"{selles * 0.12:f2}");
                    }
                    else if (selles > 10000)
                    {
                        Console.WriteLine($"{selles * 0.145:f2}");
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                    break;


                case "Varna":
                    if (selles >= 0 && selles <= 500)
                    {
                        Console.WriteLine($"{selles * 0.045:f2}");
                    }
                    else if (500 < selles && selles <= 1000)
                    {
                        Console.WriteLine($"{selles * 0.075:f2}");
                    }
                    else if (1000 < selles && selles <= 10000)
                    {
                        Console.WriteLine($"{selles * 0.1:f2}");
                    }
                    else if (selles > 10000)
                    {
                        Console.WriteLine($"{selles * 0.13:f2}");
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                    break;


                default:
                    Console.WriteLine("error");
                    break;
            }
        }
    }
}
