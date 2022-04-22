using System;

namespace _06._World_Swimming_Record
{
    class Program
    {
        static void Main(string[] args)
        {
            double recordInSeconds = double.Parse(Console.ReadLine());
            double distanceInMeters = double.Parse(Console.ReadLine());
            double timeForOneMeter = double.Parse(Console.ReadLine());

            double resistanceDelay = (distanceInMeters / 15);

            double roundedResistanceDelay = Math.Floor(resistanceDelay);

            double delayInSeconds = roundedResistanceDelay * 12.5;

            double ivanRecord = distanceInMeters * timeForOneMeter + delayInSeconds;

            if (ivanRecord < recordInSeconds)
            {
                Console.WriteLine($" Yes, he succeeded! The new world record is {ivanRecord:f2} seconds.");
            }
            else
            {
                Console.WriteLine($"No, he failed! He was {ivanRecord - recordInSeconds:f2} seconds slower.");
            }

        }
    }
}
