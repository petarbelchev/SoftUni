using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._List_Of_Predicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int endOfRange = int.Parse(Console.ReadLine());
            List<int> nums = new List<int>();

            for (int i = 1; i <= endOfRange; i++)
                nums.Add(i);

            int[] dividers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Predicate<int> isNotDivisible = num =>
            {
                foreach (int divider in dividers)
                {
                    if (num % divider != 0)
                        return true;
                }
                return false;
            };

            Console.WriteLine(string.Join(' ', nums.Where(num => !isNotDivisible(num))));
        }
    }
}
