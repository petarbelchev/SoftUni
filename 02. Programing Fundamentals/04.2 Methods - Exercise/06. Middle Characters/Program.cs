using System;

namespace _06._Middle_Characters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            GetMiddleChars(input);
        }

        static void GetMiddleChars(string input)
        {
            char[] chars = input.ToCharArray();
            int middleIndex = (int)chars.Length / 2; ;

            if (chars.Length % 2 == 0)
            {
                int secondMiddleIndex = middleIndex - 1;
                Console.Write(chars[secondMiddleIndex]);
            }

            Console.WriteLine(chars[middleIndex]);
        }
    }
}
