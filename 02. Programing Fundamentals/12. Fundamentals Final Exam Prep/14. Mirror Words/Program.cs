using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string text = Console.ReadLine();

        var regex = new Regex(@"(@|#)(?<word1>[A-Za-z]{3,})\1\1(?<word2>[A-Za-z]{3,})\1");

        MatchCollection matches = regex.Matches(text);

        var mirrorWords = new List<string>();

        foreach (Match match in matches)
        {
            string firstWord = match.Groups["word1"].Value;
            char[] secondWordToChars = match.Groups["word2"].Value.ToCharArray();
            Array.Reverse(secondWordToChars);
            string secondWord = new string(secondWordToChars);
            if (firstWord == secondWord)
            {
                mirrorWords.Add($"{firstWord} <=> {match.Groups["word2"].Value}");
            }
        }

        if (matches.Count == 0)
            Console.WriteLine("No word pairs found!");
        else
            Console.WriteLine($"{matches.Count} word pairs found!");

        if (mirrorWords.Count == 0)
            Console.WriteLine("No mirror words!");
        else
        {
            Console.WriteLine($"The mirror words are:");
            Console.WriteLine(string.Join(", ", mirrorWords));
        }
    }
}
