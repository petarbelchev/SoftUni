using System;

namespace _03._Time___15_Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            int inMinutes = (hours * 60) + minutes;

            int inMinutesAfter = inMinutes + 15;
            int hoursAfter = inMinutesAfter / 60;
            int minutesAfter = inMinutesAfter % 60;

            if (hoursAfter > 23)
            {
                hoursAfter = 0;
            }

            if (minutesAfter < 10)
            {
                Console.WriteLine($"{hoursAfter}:0{minutesAfter}");
            }
            else
            {
                Console.WriteLine($"{hoursAfter}:{minutesAfter}");
            }
        }
    }
}
