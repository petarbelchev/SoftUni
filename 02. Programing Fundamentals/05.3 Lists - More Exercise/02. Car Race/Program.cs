using System;
using System.Linq;

namespace _02._Car_Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] raceTrack = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            double timeLeftRacer = GetTimeLeftRacer(raceTrack);

            double timeRightRacer = GetTimeRightRacer(raceTrack);

            if (timeLeftRacer < timeRightRacer)
            {
                Console.WriteLine($"The winner is left with total time: {timeLeftRacer}");
            }
            else if (timeRightRacer < timeLeftRacer)
            {
                Console.WriteLine($"The winner is right with total time: {timeRightRacer}");
            }
        }

        static double GetTimeLeftRacer(int[] raceTrack)
        {
            double time = 0;

            for (int step = 0; step < raceTrack.Length / 2; step++)
            {
                if (raceTrack[step] != 0)
                {
                    time += raceTrack[step];
                }
                else
                {
                    time -= time * 0.2;
                }
            }

            return time;
        }

        static double GetTimeRightRacer(int[] raceTrack)
        {
            double time = 0;

            for (int step = raceTrack.Length - 1; step > raceTrack.Length / 2; step--)
            {
                if (raceTrack[step] != 0)
                {
                    time += raceTrack[step];
                }
                else
                {
                    time -= time * 0.2;
                }
            }

            return time;
        }
    }
}
