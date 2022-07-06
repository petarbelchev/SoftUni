using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._MOBA_Challenger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var pool = new Dictionary<string, Dictionary<string, int>>();

            string input = Console.ReadLine();

            while (input != "Season end")
            {
                string[] inputArgs = input
                    .Split(new string[] { " -> ", " vs " }, StringSplitOptions.RemoveEmptyEntries);
                
                if (inputArgs.Length == 3)
                {
                    string player = inputArgs[0];
                    string position = inputArgs[1];
                    int skill = int.Parse(inputArgs[2]);

                    if (!pool.ContainsKey(player))
                    {
                        pool.Add(player, new Dictionary<string, int>());
                        pool[player].Add(position, skill);
                    }
                    else
                    {
                        if (!pool[player].ContainsKey(position))
                        {
                            pool[player].Add(position, 0);
                        }

                        if (pool[player][position] < skill)
                        {
                            pool[player][position] = skill;
                        }
                    }
                }
                else if (inputArgs.Length == 2)
                {
                    string player1 = inputArgs[0];
                    string player2 = inputArgs[1];

                    if (pool.ContainsKey(player1) && pool.ContainsKey(player2))
                    {
                        foreach (var position in pool[player1].Keys)
                        {
                            if (pool[player2].ContainsKey(position))
                            {
                                int skillPlayer1 = pool[player1].Values.Sum();
                                int skillPlayer2 = pool[player2].Values.Sum();

                                if (skillPlayer1 > skillPlayer2)
                                {
                                    pool.Remove(player2);
                                }
                                else if (skillPlayer2 > skillPlayer1)
                                {
                                    pool.Remove(player1);
                                }

                                break;
                            }
                        }
                    }
                }

                input = Console.ReadLine();
            }

            var orderedPlayerBySkillSum = new Dictionary<string, int>();

            foreach (var player in pool)
            {
                int sumSkills = player.Value.Values.Sum();
                orderedPlayerBySkillSum.Add(player.Key, sumSkills);
            }

            foreach (var player in orderedPlayerBySkillSum.OrderByDescending(s => s.Value))
            {
                Console.WriteLine($"{player.Key}: {player.Value} skill");

                foreach (var currPlayer in pool[player.Key].OrderByDescending(s => s.Value))
                {
                    Console.WriteLine($"- {currPlayer.Key} <::> {currPlayer.Value}");
                }
            }
        }
    }
}
