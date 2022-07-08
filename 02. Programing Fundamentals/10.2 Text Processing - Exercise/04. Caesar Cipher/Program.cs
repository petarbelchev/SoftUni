using System;

namespace _04._Caesar_Cipher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] chars = Console.ReadLine().ToCharArray();

            for (int i = 0; i < chars.Length; i++)
            {
                int newChar = chars[i] + 3;
                chars[i] = (char)newChar;
            }

            Console.WriteLine(new string (chars));
        }
    }
}
