using System;
using System.Numerics;

namespace _11._Snowballs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfBalls = int.Parse(Console.ReadLine());
            BigInteger highestValue = 0;
            int snowballSnow = 0;
            int snowballTime = 0;
            int snowballQuality = 0;

            for (int i = 1; i <= numberOfBalls; i++)
            {
                int currSnowballSnow = int.Parse(Console.ReadLine());
                int currSnowballTime = int.Parse(Console.ReadLine());
                int currSnowballQuality = int.Parse(Console.ReadLine());

                BigInteger currSnowballValue = BigInteger.Pow(currSnowballSnow / currSnowballTime, currSnowballQuality);

                if (currSnowballValue >= highestValue)
                {
                    highestValue = currSnowballValue;
                    snowballSnow = currSnowballSnow;
                    snowballQuality = currSnowballQuality;
                    snowballTime = currSnowballTime;
                }
            }

            Console.WriteLine($"{snowballSnow} : {snowballTime} = {highestValue} ({snowballQuality})");
        }
    }
}
