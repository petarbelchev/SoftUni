using System;

namespace _02._Vowels_Count
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();

            Console.WriteLine(GetVowelsCount(word));
        }

        static int GetVowelsCount(string word)
        {
            char[] chars = word.ToCharArray();
            int sumVowels = 0;

            foreach (char ch in chars)
            {
                switch (ch)
                {
                    case 'A':
                    case 'a':
                    case 'E':
                    case 'e':
                    case 'I':
                    case 'i':
                    case 'O':
                    case 'o':
                    case 'U':
                    case 'u':
                        sumVowels++;
                        break;
                }
            }

            return sumVowels;
        }
    }
}
