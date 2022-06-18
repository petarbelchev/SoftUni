using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            double avValue = (double)numbers.Sum() / (double)numbers.Count;

            numbers.RemoveAll(x => x <= avValue);

            if (numbers.Count == 0)
            {
                Console.WriteLine("No");
                return;
            }

            numbers.Sort();
            numbers.Reverse();

            int topNumsCount = 5;

            if (numbers.Count < topNumsCount)
            {
                topNumsCount = numbers.Count;
            }

            for (int i = 0; i < topNumsCount; i++)
            {
                Console.Write(numbers[i] + " ");
            }
        }
    }
}
