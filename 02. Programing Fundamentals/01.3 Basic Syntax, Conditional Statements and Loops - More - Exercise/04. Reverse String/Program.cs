using System;

namespace _04._Reverse_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputedWord = Console.ReadLine();
            string reversedWord = string.Empty;

            for (int i = inputedWord.Length - 1; i >= 0; i--)
            {
                reversedWord += inputedWord[i];
            }

            Console.WriteLine(reversedWord);
        }
    }
}
