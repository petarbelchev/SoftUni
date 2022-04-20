using System;

namespace _04._Vacation_Books_List
{
    class Program
    {
        static void Main(string[] args)
        {
            int pagesCount = int.Parse(Console.ReadLine());
            int readedPagesPerHour = int.Parse(Console.ReadLine());
            int daysCount = int.Parse(Console.ReadLine());
            int neededHoursPerDay = (pagesCount / readedPagesPerHour) / daysCount;
            Console.WriteLine(neededHoursPerDay);
        }
    }
}
