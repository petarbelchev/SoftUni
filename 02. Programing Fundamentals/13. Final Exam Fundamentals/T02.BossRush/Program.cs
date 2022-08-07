using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        int numsOfLines = int.Parse(Console.ReadLine());

        var regex = new Regex(@"\|(?<boss>[A-Z]{4,})\|:#(?<title>[A-Za-z]+\s[A-Za-z]+)#");

        for (int i = 0; i < numsOfLines; i++)
        {
            string input = Console.ReadLine();

            Match match = regex.Match(input);

            if (match.Success)
            {
                Console.WriteLine($"{match.Groups["boss"].Value}, The {match.Groups["title"].Value}");
                Console.WriteLine($">> Strength: {match.Groups["boss"].Value.Length}");
                Console.WriteLine($">> Armor: {match.Groups["title"].Value.Length}");
            }
            else
            {
                Console.WriteLine("Access denied!");
            }
        }
    }
}