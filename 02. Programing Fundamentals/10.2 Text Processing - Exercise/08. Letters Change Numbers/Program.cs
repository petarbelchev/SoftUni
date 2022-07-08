using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace _08._Letters_Change_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, int> uppercaseChars = new Dictionary<char, int>();
            int position = 1;
            for (char @char = 'A'; @char <= 'Z'; @char++)
            {
                uppercaseChars.Add(@char, position);
                position++;
            }

            Dictionary<char, int> lowercaseChars = new Dictionary<char, int>();
            position = 1;
            for (char @char = 'a'; @char <= 'z'; @char++)
            {
                lowercaseChars.Add(@char, position);
                position++;
            }

            string[] strings = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            double sumOfAllNums = 0;

            for (int currString = 0; currString < strings.Length; currString++)
            {
                double currNumber = int.Parse(strings[currString].Substring(1, strings[currString].Length - 2));

                char charBefore = char.Parse(strings[currString].Substring(0, 1));
                char charAfter = char.Parse(strings[currString].Substring(strings[currString].Length - 1, 1));

                if (uppercaseChars.ContainsKey(charBefore))
                {
                    currNumber /= uppercaseChars[charBefore];
                }
                else if (lowercaseChars.ContainsKey(charBefore))
                {
                    currNumber *= lowercaseChars[charBefore];
                }

                if (uppercaseChars.ContainsKey(charAfter))
                {
                    currNumber -= uppercaseChars[charAfter];
                }
                else if (lowercaseChars.ContainsKey(charAfter))
                {
                    currNumber += lowercaseChars[charAfter];
                }

                sumOfAllNums += currNumber;
            }

            Console.WriteLine($"{sumOfAllNums:f2}");
        }
    }
}
