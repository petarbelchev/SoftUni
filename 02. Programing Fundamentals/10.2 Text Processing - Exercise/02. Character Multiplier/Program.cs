using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Character_Multiplier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] strings = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            int result = CharacterMultiplier(strings[0], strings[1]);

            Console.WriteLine(result);
        }

        static int CharacterMultiplier(string firstString, string secondString)
        {
            int sum = 0;

            List<char> firstChars = firstString.ToCharArray().ToList();
            List<char> secondChars = secondString.ToCharArray().ToList();

            while (firstChars.Count > 0 && secondChars.Count > 0)
            {
                sum += firstChars[0] * secondChars[0];
                firstChars.RemoveAt(0);
                secondChars.RemoveAt(0);
            }

            if (firstChars.Count > 0)
            {
                foreach (char ch in firstChars)
                {
                    sum += ch;
                }
            }
            else
            {
                foreach (char ch in secondChars)
                {
                    sum += ch;
                }
            }

            return sum;
        }
    }
}
