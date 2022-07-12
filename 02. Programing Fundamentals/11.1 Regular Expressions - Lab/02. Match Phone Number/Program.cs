using System;
using System.Text.RegularExpressions;

namespace _02._Match_Phone_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"(\+359)(( )|(-))2\2\d{3}\2\d{4}\b");

            string phoneNumbers = Console.ReadLine();

            MatchCollection matchedPhones = regex.Matches(phoneNumbers);

            Console.WriteLine(string.Join(", ", matchedPhones));
        }
    }
}
