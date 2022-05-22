using System;

namespace _08._Tennis_Ranklist
{
    class Program
    {
        static void Main(string[] args)
        {
            int tournamentsQuantity = int.Parse(Console.ReadLine());
            int startPoints = int.Parse(Console.ReadLine());
            int w = 0;
            int f = 0;
            int sf = 0;
            double winnedTournament = 0;

            for (int i = 1; i <= tournamentsQuantity; i++)
            {
                string stage = Console.ReadLine();

                switch (stage)
                {
                    case "W":
                        w += 2000;
                        winnedTournament += 1;
                        break;

                    case "F":
                        f += 1200;
                        break;

                    case "SF":
                        sf += 720;
                        break;
                }
            }

            double avPoints = (w + f + sf) / tournamentsQuantity;
            double percentWinTournaments = winnedTournament / tournamentsQuantity * 100;

            Console.WriteLine($"Final points: {startPoints + w + f + sf}");
            Console.WriteLine($"Average points: {Math.Floor(avPoints)}");
            Console.WriteLine($"{percentWinTournaments:f2}%");
        }
    }
}
