using System;
using System.Linq;

namespace _01._Reverse_Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();

            while (word != "end")
            {
                char[] wordCharArr = word.ToCharArray();
                Array.Reverse(wordCharArr);
                string reversedWord = new string(wordCharArr);
                Console.WriteLine($"{word} = {reversedWord}");

                word = Console.ReadLine();
            }
        }
    }
}
