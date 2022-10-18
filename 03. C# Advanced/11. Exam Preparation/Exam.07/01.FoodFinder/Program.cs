using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.FoodFinder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<char> vowels = new Queue<char>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse)
                .ToList());

            Stack<char> consonants = new Stack<char>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse)
                .ToList());

            var words = new Dictionary<string, HashSet<char>>()
            {
                { "pear", new HashSet<char>() },
                { "flour", new HashSet<char>() },
                { "pork", new HashSet<char>() },
                { "olive", new HashSet<char>() },
            };

            while (consonants.Count > 0)
            {
                char currVowel = vowels.Dequeue();
                char currConsonant = consonants.Pop();

                foreach (var word in words)
                {
                    if (word.Key.Contains(currVowel))
                    {
                        word.Value.Add(currVowel);
                    }

                    if (word.Key.Contains(currConsonant))
                    {
                        word.Value.Add(currConsonant);
                    }
                }

                vowels.Enqueue(currVowel);
            }

            string[] foundedWords = words
                .Where(w => w.Key.Length == w.Value.Count)
                .Select(w => w.Key)
                .ToArray();

            Console.WriteLine($"Words found: {foundedWords.Length}");

            Console.WriteLine(string.Join(Environment.NewLine, foundedWords));
        }
    }
}
