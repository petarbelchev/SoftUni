using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _2._Rage_Quit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Regex regex = new Regex(@"(\D+)(\d+)");

            MatchCollection matches = regex.Matches(input);

            StringBuilder sb = new StringBuilder();

            foreach (Match match in matches)
            {
                string str = match.Groups[1].Value;
                int repeatCount = int.Parse(match.Groups[2].Value);

                for (int i = 0; i < repeatCount; i++)
                {
                    sb.Append(str);
                }
            }

            string output = sb.ToString().ToUpper();
            int uniqueSymbolsCount = output.Distinct().Count();

            Console.WriteLine($"Unique symbols used: {uniqueSymbolsCount}");
            Console.WriteLine(output);
        }
    }
}
