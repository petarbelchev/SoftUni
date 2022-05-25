using System;

namespace _04._Sum_of_Chars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int charCount = int.Parse(Console.ReadLine());
            int sumChars = 0;

            for (int charNum = 1; charNum <= charCount; charNum++)
            {
                char currChar = char.Parse(Console.ReadLine());
                sumChars += currChar;
            }

            Console.WriteLine($"The sum equals: {sumChars}");
        }
    }
}
