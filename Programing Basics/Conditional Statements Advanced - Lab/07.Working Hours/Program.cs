using System;

namespace _07.Working_Hours
{
    class Program
    {
        static void Main(string[] args)
        {
            int hour = int.Parse(Console.ReadLine());
            string day = Console.ReadLine();

            bool inWorkingDay = day != "Sunday";
            bool inWorkingTime = hour >= 10 && hour <= 18;

            if (inWorkingDay == true && inWorkingTime == true)
            {
                Console.WriteLine("open");
            }
            else
            {
                Console.WriteLine("closed");
            }
        }
    }
}
