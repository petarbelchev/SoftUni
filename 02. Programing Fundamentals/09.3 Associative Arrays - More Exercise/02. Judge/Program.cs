using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Judge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var contests = new Dictionary<string, Dictionary<string, int>>();

            string input = Console.ReadLine();

            while (input != "no more time")
            {
                string[] inputArgs = input
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                string username = inputArgs[0];
                string contest = inputArgs[1];
                int points = int.Parse(inputArgs[2]);

                if (!contests.ContainsKey(contest))
                {
                    contests.Add(contest, new Dictionary<string, int>());
                }

                if (!contests[contest].ContainsKey(username))
                {
                    contests[contest].Add(username, points);
                }

                if (contests[contest][username] < points)
                {
                    contests[contest][username] = points;
                }

                input = Console.ReadLine();
            }

            int position;

            foreach (var contest in contests)
            {
                Console.WriteLine($"{contest.Key}: {contest.Value.Count} participants");

                position = 1;

                foreach (var user in contest.Value
                    .OrderByDescending(user => user.Value)
                    .ThenBy(user => user.Key))
                {
                    Console.WriteLine($"{position}. {user.Key} <::> {user.Value}");
                    position++;
                }
            }

            Dictionary<string, int> users = new Dictionary<string, int>();

            foreach (var contest in contests)
            {
                foreach (var user in contest.Value)
                {
                    if (!users.ContainsKey(user.Key))
                    {
                        users.Add(user.Key, user.Value);
                    }
                    else
                    {
                        users[user.Key] += user.Value;
                    }
                }
            }
            
            Console.WriteLine("Individual standings:");

            position = 1;

            foreach (var user in users
                .OrderByDescending(u => u.Value)
                .ThenBy(u => u.Key))
            {
                Console.WriteLine($"{position}. {user.Key} -> {user.Value}");
                position++;
            }
        }
    }
}
