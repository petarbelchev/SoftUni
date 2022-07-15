using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _05._Nether_Realms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Regex regex = new Regex(@"([^, ]+)");

            MatchCollection demonsMatches = regex.Matches(input);

            List<string> demons = new List<string>(demonsMatches.Select(x => x.Value));

            foreach (string demon in demons.OrderBy(n => n))
            {
                regex = new Regex(@"[^0-9\+\-\*\/\.]");
                
                MatchCollection healthMatches = regex.Matches(demon);

                int health = 0;

                foreach (Match match in healthMatches)
                {
                    health += char.Parse(match.Value);
                }

                regex = new Regex(@"(\+|-)?\d+(\.\d+)*");

                MatchCollection damageMatches = regex.Matches(demon);

                double damage = 0;

                foreach (Match match in damageMatches)
                {
                    damage += double.Parse(match.Value);
                }

                regex = new Regex(@"[\*]");

                MatchCollection multiplyMatches = regex.Matches(demon);

                if (multiplyMatches.Count > 0)
                {
                    for (int i = 0; i < multiplyMatches.Count; i++)
                    {
                        damage *= 2;
                    }
                }

                regex = new Regex(@"[\/]");

                MatchCollection divideMatches = regex.Matches(demon);

                if (divideMatches.Count > 0)
                {
                    for (int i = 0; i < divideMatches.Count; i++)
                    {
                        damage /= 2;
                    }
                }

                Console.WriteLine($"{demon} - {health} health, {damage:f2} damage");
            }
        }
    }
}
