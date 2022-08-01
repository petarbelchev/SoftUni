using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        Regex regex = new Regex(@"\d");
        MatchCollection matches = regex.Matches(input);
        BigInteger coolThreshold = 1;
        foreach (Match match in matches)
            coolThreshold *= int.Parse(match.Value);
        regex = new Regex(@"((::)|(\*\*))([A-Z][a-z]{2,})(\1)");
        matches = regex.Matches(input);
        List<string> coolOnes = new List<string>();
        foreach (Match match in matches)
        {
            BigInteger coolCounter = 0;
            foreach (char ch in match.Value)
            {
                if (char.IsLetter(ch))
                    coolCounter += ch;
            }
            if (coolCounter > coolThreshold)
                coolOnes.Add(match.Value);
        }
        Console.WriteLine($"Cool threshold: {coolThreshold}");
        Console.WriteLine($"{matches.Count} emojis found in the text. The cool ones are:");
        Console.WriteLine(string.Join(Environment.NewLine, coolOnes));
    }
}
