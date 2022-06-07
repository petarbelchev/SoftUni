using System;

namespace _03._Characters_in_Range
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char char1 = char.Parse(Console.ReadLine());
            char char2 = char.Parse(Console.ReadLine());

            PrintCharsBetweenTwo(char1, char2);
        }

        static void PrintCharsBetweenTwo(char ch1, char ch2)
        {
            if (ch1 > ch2)
            {
                for (int i = ch2 + 1; i < ch1; i++)
                {
                    char currChar = (char)i;
                    Console.Write(currChar + " ");
                }
            }
            else
            {
                for (int i = ch1 + 1; i < ch2; i++)
                {
                    char currChar = (char)i;
                    Console.Write(currChar + " ");
                }
            }
        }
    }
}
