using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._2_Append_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split('|').ToList();

            input.Reverse();
            
            List<string> result = new List<string>();
            
            foreach (string item in input)
            {
                result.AddRange(item.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList());
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
