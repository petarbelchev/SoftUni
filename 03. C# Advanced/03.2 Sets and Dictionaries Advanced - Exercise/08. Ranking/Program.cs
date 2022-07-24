using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var contests = new Dictionary<string, string>();

            var candidates = new Dictionary<string, Dictionary<string, int>>();

            string input = Console.ReadLine();

            while (input != "end of contests")
            {
                string[] contestData = input.Split(':');
                contests.Add(contestData[0], contestData[1]);

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "end of submissions")
            {
                string[] candidateData = input.Split("=>");
                string contest = candidateData[0];
                string password = candidateData[1];
                string username = candidateData[2];
                int points = int.Parse(candidateData[3]);

                if (contests.ContainsKey(contest) && contests[contest] == password)
                {
                    if (!candidates.ContainsKey(username))
                    {
                        candidates[username] = new Dictionary<string, int>();
                        candidates[username].Add(contest, 0);
                    }

                    if (!candidates[username].ContainsKey(contest))
                    {
                        candidates[username].Add(contest, 0);
                    }

                    if (candidates[username][contest] < points)
                    {
                        candidates[username][contest] = points;
                    }
                }

                input = Console.ReadLine();
            }

            string bestCandidateName = candidates
                .OrderByDescending(c => c.Value.Values.Sum())
                .Select(c => c.Key).First();

            Console.WriteLine($"Best candidate is {bestCandidateName} with total {candidates[bestCandidateName].Values.Sum()} points.");

            Console.WriteLine($"Ranking:");

            foreach (var candidate in candidates.OrderBy(n => n.Key))
            {
                Console.WriteLine($"{candidate.Key}");
                foreach (var currContest in candidate.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {currContest.Key} -> {currContest.Value}");
                }
            }
        }
    }
}
