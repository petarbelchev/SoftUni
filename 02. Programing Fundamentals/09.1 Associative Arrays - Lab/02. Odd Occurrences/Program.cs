using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Odd_Occurrences
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> words = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            Dictionary<string, int> result = new Dictionary<string, int>();

            foreach (var word in words)
            {
                string lowerWord = word.ToLower();

                if (result.ContainsKey(lowerWord))
                {
                    result[lowerWord]++;
                }
                else
                {
                    result.Add(lowerWord, 1);
                }
            }

            words = result
                .Where(word => word.Value % 2 != 0)
                .Select(word => word.Key)
                .ToList();

            Console.WriteLine(string.Join(" ", words));
        }
    }
}
