using System;

namespace _01._SoftUni_Reception
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int emp1PerHour = int.Parse(Console.ReadLine());
            int emp2PerHour = int.Parse(Console.ReadLine());
            int emp3PerHour = int.Parse(Console.ReadLine());
            int studentsCount = int.Parse(Console.ReadLine());

            int helpedPerHour = emp1PerHour + emp2PerHour + emp3PerHour;
            int neededHours = 0;
            int breaks = 0;

            while (studentsCount > 0)
            {
                studentsCount -= helpedPerHour;
                neededHours++;

                if (studentsCount <= 0)
                {
                    break;
                }

                if (neededHours % 3 == 0)
                {
                    breaks++;
                }
            }

            Console.WriteLine($"Time needed: {neededHours + breaks}h.");
        }
    }
}
