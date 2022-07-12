using System;
using System.Text.RegularExpressions;

namespace _03._Match_Dates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string dates = Console.ReadLine();

            Regex regex = new Regex(@"\b(?<day>\d{2})(-|\.|\/)(?<month>[A-Z][a-z]{2})\1(?<year>\d{4})\b");

            MatchCollection matchedDates = regex.Matches(dates);

            foreach (Match date in matchedDates)
            {
                Console.WriteLine($"Day: {date.Groups["day"]}, Month: {date.Groups["month"]}, Year: {date.Groups["year"]}");
            }
        }
    }
}
