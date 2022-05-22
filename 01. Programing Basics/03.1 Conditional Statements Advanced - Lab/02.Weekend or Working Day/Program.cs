using System;

namespace _02.Weekend_or_Working_Day
{
    class Program
    {
        static void Main(string[] args)
        {
            string dayOfWeek = Console.ReadLine();

            bool itsWorkingDay = dayOfWeek == "Monday" || dayOfWeek == "Tuesday" ||
                dayOfWeek == "Wednesday" || dayOfWeek == "Thursday" || dayOfWeek == "Friday";

            bool itsWeekend = dayOfWeek == "Saturday" || dayOfWeek == "Sunday";

            if (itsWorkingDay == true)
            {
                Console.WriteLine("Working day");
            }
            else if (itsWeekend == true)
            {
                Console.WriteLine("Weekend");
            }
            else
            {
                Console.WriteLine("Error");
            }
        }
    }
}
