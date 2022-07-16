using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _1._Winning_Ticket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Regex regex = new Regex(@"[^\s,]+");

            MatchCollection tickets = regex.Matches(input);

            foreach (Match ticket in tickets)
            {
                if (ticket.Length != 20)
                {
                    Console.WriteLine("invalid ticket");
                    continue;
                }

                string firstHalf = ticket.Value.Substring(0, ticket.Length / 2);
                string secondHalf = ticket.Value.Substring(ticket.Length - firstHalf.Length);

                regex = new Regex(@"(\^{6,})|(\${6,})|(@{6,})|(#{6,})");

                Match firstHalfMatches = regex.Match(firstHalf);
                Match secondHalfMatches = regex.Match(secondHalf);

                if (!(firstHalfMatches.Success && secondHalfMatches.Success))
                {
                    Console.WriteLine($"ticket \"{ticket}\" - no match");
                    continue;
                }

                int matchLength = Math.Min(firstHalfMatches.Value.Length, secondHalfMatches.Value.Length);
                string symbol = firstHalfMatches.Value.Substring(0, 1);

                if (matchLength == 10)
                {
                    Console.WriteLine($"ticket \"{ticket}\" - {matchLength}{symbol} Jackpot!");
                }
                else
                {
                    Console.WriteLine($"ticket \"{ticket}\" - {matchLength}{symbol}");
                }
            }
        }
    }
}
