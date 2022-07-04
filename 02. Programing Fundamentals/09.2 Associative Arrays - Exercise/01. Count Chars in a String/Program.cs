using System;
using System.Collections.Generic;

namespace _01._Count_Chars_in_a_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<char, int> charsCounter = new Dictionary<char, int>();
            foreach (char ch in input)
            {
                if (ch != ' ')
                {
                    if (charsCounter.ContainsKey(ch))
                    {
                        charsCounter[ch]++;
                    }
                    else
                    {
                        charsCounter.Add(ch, 1);
                    }
                }
            }
            foreach (var ch in charsCounter)
            {
                Console.WriteLine($"{ch.Key} -> {ch.Value}");
            }
        }
    }
}
