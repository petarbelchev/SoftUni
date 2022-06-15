using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine().Split().Select(int.Parse).ToList();
            int maxCapacity = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] commands = input.Split();

                if (commands[0] == "Add")
                {
                    int newWagon = int.Parse(commands[1]);

                    wagons.Add(newWagon);
                }
                else
                {
                    int newPassengers = int.Parse(commands[0]);

                    for (int i = 0; i < wagons.Count; i++)
                    {
                        if (wagons[i] + newPassengers <= maxCapacity)
                        {
                            wagons[i] += newPassengers;
                            break;
                        }
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", wagons));
        }
    }
}
