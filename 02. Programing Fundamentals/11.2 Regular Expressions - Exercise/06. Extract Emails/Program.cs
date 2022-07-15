using System;
using System.Text.RegularExpressions;

namespace _06._Extract_Emails
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            Regex regex = new Regex(@"\s(?<user>[a-z0-9]+[.\-_]?[a-z0-9]+)@(?<host>[a-z]{2,}-?[a-z]{2,}\.[a-z]{2,}(?:\.[a-z]{2,})*)");

            MatchCollection matches = regex.Matches(text);

            foreach (Match match in matches)
            {
                Console.WriteLine(match.Value);
            }
        }
    }
}
