using System;

namespace _01._Day_of_Week
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] daysOfTheWeek = {
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday"
            };

            int dayOfTheWeek = int.Parse(Console.ReadLine());

            if (dayOfTheWeek >= 1 && dayOfTheWeek <= 7)
            {
                Console.WriteLine(daysOfTheWeek[dayOfTheWeek - 1]);
            }
            else
            {
                Console.WriteLine("Invalid day!");
            }
        }
    }
}
