using System;
using System.Text.RegularExpressions;

namespace _03._Match_Dates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string dates = Console.ReadLine();

            Regex regex = new Regex(@"\b(\d{2})([-\.\/])([A-Z][a-z]{2})\2(\d{4})\b");

            MatchCollection matchedDates = regex.Matches(dates);

            foreach (Match date in matchedDates)
            {
                Console.WriteLine($"Day: {date.Groups[1]}, Month: {date.Groups[3]}, Year: {date.Groups[4]}");
            }
        }
    }
}
