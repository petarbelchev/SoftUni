using System;

namespace _06._Name_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            int pointsWinner = 0;
            string nameWinner = "";

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Stop")
                {
                    break;
                }

                string namePlayer = input;
                int pointsPlayer = 0;

                for (int letter = 0; letter < namePlayer.Length; letter++)
                {
                    int num = int.Parse(Console.ReadLine());

                    if (num == namePlayer[letter])
                    {
                        pointsPlayer += 10;
                    }
                    else
                    {
                        pointsPlayer += 2;
                    }
                }

                if (pointsPlayer >= pointsWinner)
                {
                    pointsWinner = pointsPlayer;
                    nameWinner = namePlayer;
                }
            }

            Console.WriteLine($"The winner is {nameWinner} with {pointsWinner} points!");
        }
    }
}
