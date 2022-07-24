using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._The_V_Logger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var vLogger = new Dictionary<string, VloggerStatistics>();

            string cmd = Console.ReadLine();

            while (cmd != "Statistics")
            {
                string[] cmdArgs = cmd.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string @event = cmdArgs[1];

                if (@event == "joined" && !vLogger.ContainsKey(cmdArgs[0]))
                {
                    vLogger[cmdArgs[0]] = new VloggerStatistics();
                }
                else if (@event == "followed"
                    && vLogger.ContainsKey(cmdArgs[0])
                    && vLogger.ContainsKey(cmdArgs[2])
                    && cmdArgs[0] != cmdArgs[2])
                {
                    string follower = cmdArgs[0];
                    string following = cmdArgs[2];

                    vLogger[follower].Following.Add(following);
                    vLogger[following].Followers.Add(follower);
                }

                cmd = Console.ReadLine();
            }

            Console.WriteLine($"The V-Logger has a total of {vLogger.Keys.Count} vloggers in its logs.");

            int number = 1;

            foreach (var vlogger in vLogger
                .OrderByDescending(vl => vl.Value.Followers.Count)
                .ThenBy(vl => vl.Value.Following.Count).Take(1))
            {
                Console.WriteLine($"{number}. {vlogger.Key} : {vlogger.Value.Followers.Count} followers, {vlogger.Value.Following.Count} following");

                foreach (var follower in vlogger.Value.Followers.OrderBy(f => f))
                {
                    Console.WriteLine($"*  {follower}");
                }

                number++;
            }

            foreach (var vlogger in vLogger
                .OrderByDescending(vl => vl.Value.Followers.Count)
                .ThenBy(vl => vl.Value.Following.Count).Skip(1))
            {
                Console.WriteLine($"{number}. {vlogger.Key} : {vlogger.Value.Followers.Count} followers, {vlogger.Value.Following.Count} following");

                number++;
            }
        }
    }

    class VloggerStatistics
    {
        public HashSet<string> Followers { get; set; } = new HashSet<string>();
        public HashSet<string> Following { get; set; } = new HashSet<string>();
    }
}
