using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _04._Star_Enigma
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfMessages = int.Parse(Console.ReadLine());

            List<string> attackedPlanets = new List<string>();
            List<string> destroyedPlanets = new List<string>();

            for (int i = 0; i < numberOfMessages; i++)
            {
                string encryptedMessage = Console.ReadLine();

                int lettersCount = encryptedMessage.Where(ch => new char[] { 's', 't', 'a', 'r' }.Contains(char.ToLower(ch))).Count();

                StringBuilder decryptedMessage = new StringBuilder();

                decryptedMessage.Append(new string (encryptedMessage.Select(ch => (char)(ch - lettersCount)).ToArray()));

                Regex regex = new Regex(@"@(?<planet>[A-Za-z]+)[^@\-!:>]*?:(?<population>\d+)[^@\-!:>]*?!(?<attackType>[AD])![^@\-!:>]*?->(?<soldierCount>\d+)");

                Match match = regex.Match(decryptedMessage.ToString());

                if (match.Success)
                {
                    string planetName = match.Groups["planet"].Value;
                    char attackType = char.Parse(match.Groups["attackType"].Value);

                    if (attackType == 'A')
                    {
                        attackedPlanets.Add(planetName);
                    }
                    else if (attackType == 'D')
                    {
                        destroyedPlanets.Add(planetName);
                    }
                }
            }

            Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");
            foreach (string planet in attackedPlanets.OrderBy(p => p))
            {
                Console.WriteLine($"-> {planet}");
            }

            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");
            foreach (string planet in destroyedPlanets.OrderBy(p => p))
            {
                Console.WriteLine($"-> {planet}");
            }
        }
    }
}
