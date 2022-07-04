using System;
using System.Collections.Generic;

namespace _02._A_Miner_Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> resources = new Dictionary<string, int>();
            
            string input = Console.ReadLine();
            
            while (input != "stop")
            {
                int quantity = int.Parse(Console.ReadLine());

                if (resources.ContainsKey(input))
                {
                    resources[input] += quantity;
                }
                else
                {
                    resources.Add(input, quantity);
                }

                input = Console.ReadLine();
            }

            foreach (var item in resources)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
