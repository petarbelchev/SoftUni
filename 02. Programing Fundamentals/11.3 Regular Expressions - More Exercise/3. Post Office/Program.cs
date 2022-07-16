using System;
using System.Text.RegularExpressions;

namespace _3._Post_Office
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] textParts = Console.ReadLine().Split('|');

            Regex regex = new Regex(@"(\$|\#|\%|\*|\&)(?<capitals>[A-Z]+)\1");

            Match matchedCapitalLetters = regex.Match(textParts[0]);

            char[] capitalLetters = matchedCapitalLetters.Groups["capitals"].Value.ToCharArray();

            for (int i = 0; i < capitalLetters.Length; i++)
            {
                int AsciiCodeFirstLetter = capitalLetters[i];

                regex = new Regex($@"(?<code>{AsciiCodeFirstLetter}):(?<length>\d{{2}})");

                Match matchedLetterAndLength = regex.Match(textParts[1]);

                int wordLength = int.Parse(matchedLetterAndLength.Groups["length"].Value);

                regex = new Regex(@$"(?<=\s|^){capitalLetters[i]}[^\s]{{{wordLength}}}(?=\s|$)");

                Match word = regex.Match(textParts[2]);

                Console.WriteLine(word.Value);
            }
        }
    }
}
