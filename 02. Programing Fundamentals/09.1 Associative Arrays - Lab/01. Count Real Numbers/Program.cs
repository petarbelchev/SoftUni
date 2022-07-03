using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Count_Real_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            SortedDictionary<int, int> result = new SortedDictionary<int, int>();

            foreach (var number in numbers)
            {
                if (result.ContainsKey(number))
                {
                    result[number] += 1;
                }
                else
                {
                    result.Add(number, 1);
                }
            }

            foreach (var item in result)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
