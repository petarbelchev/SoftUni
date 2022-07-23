using System;
using System.Collections.Generic;

namespace _01._Count_Same_Values_in_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] values = Console.ReadLine().Split();
            var valuesCounter = new Dictionary<string, int>();
            foreach (string value in values)
            {
                if (valuesCounter.ContainsKey(value))
                    valuesCounter[value]++;
                else
                    valuesCounter.Add(value, 1);
            }
            foreach (var kvp in valuesCounter)
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value} times");
            }
        }
    }
}
