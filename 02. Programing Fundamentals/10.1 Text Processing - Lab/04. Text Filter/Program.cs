using System;

namespace _04._Text_Filter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] bannedWords = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            string text = Console.ReadLine();

            char ch = '*';

            foreach (var word in bannedWords)
            {
                text = text.Replace(word, new string(ch, word.Length));
            }

            Console.WriteLine(text);
        }
    }
}
