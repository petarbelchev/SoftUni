using System;
using System.Collections.Generic;

namespace _6._Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> costumers = new Queue<string>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }

                if (input == "Paid")
                {
                    Console.WriteLine(string.Join(Environment.NewLine, costumers));
                    costumers.Clear();
                }
                else
                {
                    costumers.Enqueue(input);
                }
            }

            Console.WriteLine($"{costumers.Count} people remaining.");
        }
    }
}
