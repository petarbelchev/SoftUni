using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Word_Filter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> wordsLength = new Dictionary<string, int>();

            foreach (string word in words)
            {
                wordsLength.Add(word, word.Length);
            }

            string[] evenWords = wordsLength
                .Where(word => word.Value % 2 == 0)
                .Select(word => word.Key)
                .ToArray();

            Console.WriteLine(string.Join(Environment.NewLine, evenWords));
        }
    }
}
