using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var dictionary = new Dictionary<string, List<string>>();

        string[] wordsDefinitionPairs = Console.ReadLine()
            .Split(" | ", StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < wordsDefinitionPairs.Length; i++)
        {
            string[] currWordDefPair = wordsDefinitionPairs[i]
                .Split(": ", StringSplitOptions.RemoveEmptyEntries);

            if (dictionary.ContainsKey(currWordDefPair[0]) == false)
            {
                dictionary[currWordDefPair[0]] = new List<string>();
            }

            dictionary[currWordDefPair[0]].Add(currWordDefPair[1]);
        }

        string[] words = Console.ReadLine().Split(" | ", StringSplitOptions.RemoveEmptyEntries);

        string cmd = Console.ReadLine();

        if (cmd == "Test")
        {
            foreach (var word in words)
            {
                if (dictionary.ContainsKey(word))
                {                    
                    Console.WriteLine($"{word}:");
                    foreach (var definition in dictionary[word])
                    {
                        Console.WriteLine($" -{definition}");
                    }
                }
            }
        }
        else if (cmd == "Hand Over")
        {
            Console.WriteLine(string.Join(' ', dictionary.Keys));
        }
    }
}