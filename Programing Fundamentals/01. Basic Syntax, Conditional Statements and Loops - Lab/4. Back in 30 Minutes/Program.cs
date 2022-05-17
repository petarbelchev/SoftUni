using System;

namespace _4._Back_in_30_Minutes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            int arriveInMinutes = hours * 60 + minutes;
            int comeBackInMinutes = arriveInMinutes + 30;

            int hoursToCome = comeBackInMinutes / 60;

            if (hoursToCome > 23)
            {
                hoursToCome = 0;
            }

            int minutesToCome = comeBackInMinutes % 60;

            Console.WriteLine($"{hoursToCome}:{minutesToCome:d2}");
        }
    }
}
