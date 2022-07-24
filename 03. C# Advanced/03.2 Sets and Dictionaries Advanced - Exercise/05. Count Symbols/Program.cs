using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Count_Symbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, int> keyValuePairs = new Dictionary<char, int>();
            char[] input = Console.ReadLine().ToCharArray();
            foreach (var item in input)
            {
                if (keyValuePairs.ContainsKey(item))
                    keyValuePairs[item]++;
                else
                    keyValuePairs[item] = 1;
            }
            foreach (var item in keyValuePairs.OrderBy(kvp => kvp.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}
