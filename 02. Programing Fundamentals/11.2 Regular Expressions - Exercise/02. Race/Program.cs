using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _02._Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] racersArr = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> racers = new Dictionary<string, int>();

            foreach (string racer in racersArr)
            {
                racers.Add(racer, 0);
            }

            string racerRawDetails = Console.ReadLine();

            while (racerRawDetails != "end of race")
            {
                Regex regex = new Regex(@"[A-Z]*[a-z]*");

                MatchCollection matches = regex.Matches(racerRawDetails);

                StringBuilder sb = new StringBuilder();

                foreach (Match match in matches)
                {
                    sb.Append(match.Value);
                }

                string racerName = sb.ToString();

                if (racers.ContainsKey(racerName))
                {
                    regex = new Regex(@"[0-9]");

                    matches = regex.Matches(racerRawDetails);

                    foreach (Match match in matches)
                    {
                        racers[racerName] += int.Parse(match.Value);
                    }
                }

                racerRawDetails = Console.ReadLine();
            }

            racers = new Dictionary<string, int>(racers.OrderByDescending(x => x.Value));

            List<string> names = racers.Keys.ToList();

            Console.WriteLine($"1st place: {names[0]}");
            Console.WriteLine($"2nd place: {names[1]}");
            Console.WriteLine($"3rd place: {names[2]}");
        }
    }
}
