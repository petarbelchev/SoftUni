using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Even_Times
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = new Dictionary<string, int>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string number = Console.ReadLine();

                if (numbers.ContainsKey(number))
                    numbers[number]++;
                else
                    numbers[number] = 1;
            }
            Console.WriteLine(numbers.Where(kvp => kvp.Value % 2 == 0).Select(key => key.Key).First());
        }
    }
}
