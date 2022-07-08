using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Replace_Repeating_Chars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<char> chars = Console.ReadLine().ToList();

            int originalCount = chars.Count;

            int index = 0;

            for (int i = 0; i < originalCount - 1; i++)
            {
                if (chars[index] == chars[index + 1])
                {
                    chars.RemoveAt(index);
                }
                else
                {
                    index++;
                }
            }

            Console.WriteLine(string.Join("", chars));
        }
    }
}
