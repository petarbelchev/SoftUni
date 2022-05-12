using System;

namespace _05._Football_Tournament
{
    class Program
    {
        static void Main(string[] args)
        {
            string nameClub = Console.ReadLine();
            int playedGames = int.Parse(Console.ReadLine());
            int wins = 0;
            int loses = 0;
            int draws = 0;
            for (int currentGame = 1; currentGame <= playedGames; currentGame++)
            {
                char gameResult = char.Parse(Console.ReadLine());
                if (gameResult == 'W')
                {
                    wins++;
                }
                else if (gameResult == 'D')
                {
                    draws++;
                }
                else if (gameResult == 'L')
                {
                    loses++;
                }
            }
            int wonPoinds = wins * 3 + draws;
            if (playedGames == 0)
            {
                Console.WriteLine($"{nameClub} hasn't played any games during this season.");
            }
            else
            {
                Console.WriteLine($"{nameClub} has won {wonPoinds} points during this season.");
                Console.WriteLine("Total stats:");
                Console.WriteLine($"## W: {wins}");
                Console.WriteLine($"## D: {draws}");
                Console.WriteLine($"## L: {loses}");
                Console.WriteLine($"Win rate: {((double)wins / playedGames) * 100:f2}%");
            }
        }
    }
}
