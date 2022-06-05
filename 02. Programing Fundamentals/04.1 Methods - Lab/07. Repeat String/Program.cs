using System;
using System.Text;

namespace _07._Repeat_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            int repeatCount = int.Parse(Console.ReadLine());

            string repeatedWord = GetRepeatedWord(word, repeatCount);

            Console.WriteLine(repeatedWord);
        }

        static string GetRepeatedWord(string word, int repeatCount)
        {
            StringBuilder repeatedWord = new StringBuilder();

            for (int i = 0; i < repeatCount; i++)
            {
                repeatedWord.Append(word);
            }

            return repeatedWord.ToString();
        }
    }
}
