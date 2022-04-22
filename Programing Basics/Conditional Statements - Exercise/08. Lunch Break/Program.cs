using System;

namespace _08._Lunch_Break
{
    class Program
    {
        static void Main(string[] args)
        {
            string nameSeries = Console.ReadLine();
            int durationEpisod = int.Parse(Console.ReadLine());
            int durationBreak = int.Parse(Console.ReadLine());

            double timeLunch = durationBreak / 8.0;
            double timeRest = durationBreak / 4.0;

            if (durationBreak >= durationEpisod + timeLunch + timeRest)
            {
                Console.WriteLine($"You have enough time to watch {nameSeries} and left with " +
                    $"{Math.Ceiling(durationBreak - (durationEpisod + timeLunch + timeRest))} " +
                    $"minutes free time.");
            }
            else
            {
                Console.WriteLine($"You don't have enough time to watch {nameSeries}, " +
                    $"you need {Math.Ceiling((durationEpisod + timeLunch + timeRest) - durationBreak)} " +
                    $"more minutes.");
            }
        }
    }
}
