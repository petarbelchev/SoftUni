using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contests = new Dictionary<string, string>();

            string cmd;

            while ((cmd = Console.ReadLine()) != "end of contests")
            {
                string[] cmdArgs = cmd.Split(':', StringSplitOptions.RemoveEmptyEntries);
                string contest = cmdArgs[0];
                string password = cmdArgs[1];
                contests.Add(contest, password);
            }

            List<User> users = new List<User>();

            while ((cmd = Console.ReadLine()) != "end of submissions")
            {
                string[] cmdArgs = cmd.Split("=>", StringSplitOptions.RemoveEmptyEntries);
                string contest = cmdArgs[0];
                string password = cmdArgs[1];
                string username = cmdArgs[2];
                int points = int.Parse(cmdArgs[3]);

                if (contests.ContainsKey(contest) && contests[contest] == password)
                {
                    if (users.Any(u => u.Name == username))
                    {
                        User user = users.Where(u => u.Name == username).First();

                        if (!user.Contests.ContainsKey(contest))
                        {
                            user.Contests.Add(contest, 0);
                        }

                        if (user.Contests[contest] < points)
                        {
                            user.Contests[contest] = points;
                        }
                    }
                    else
                    {
                        users.Add(new User(username, contest, points));
                    }
                }
            }

            string bestUserName = string.Empty;
            int bestPointsSum = 0;

            foreach (var user in users)
            {
                int currSumPoints = user.Contests.Values.Sum();

                if (bestPointsSum < currSumPoints)
                {
                    bestPointsSum = currSumPoints;
                    bestUserName = user.Name;
                }
            }

            Console.WriteLine($"Best candidate is {bestUserName} with total {bestPointsSum} points.");

            Console.WriteLine("Ranking: ");

            foreach (var user in users.OrderBy(u => u.Name))
            {
                Console.WriteLine($"{user.Name}");

                foreach (var contest in user.Contests.OrderByDescending(u => u.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }
    }

    class User
    {
        public User(string name, string contest, int points)
        {
            Name = name;
            Contests.Add(contest, points);
        }

        public string Name { get; set; }
        public Dictionary<string, int> Contests { get; set; } = new Dictionary<string, int>();
    }
}
