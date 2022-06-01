using System;

namespace _01._Encrypt__Sort_and_Print_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int stringsCount = int.Parse(Console.ReadLine());
            int[] numbers = new int[stringsCount];
            for (int @string = 0; @string < stringsCount; @string++)
            {
                char[] chars = Console.ReadLine().ToCharArray();
                int vowel = 0;
                int consonant = 0;
                foreach (char @char in chars)
                {
                    switch (@char)
                    {
                        case 'A': case 'E': case 'I': case 'O': case 'U': 
                        case 'a': case 'e': case 'i': case 'o': case 'u':
                            vowel += @char * chars.Length;
                            break;

                        default:
                            consonant += @char / chars.Length;
                            break;
                    }
                }
                int sumLetters = vowel + consonant;
                numbers[@string] = sumLetters;
            }
            Array.Sort(numbers);
            foreach (int number in numbers)
            {
                Console.WriteLine($"{number} ");
            }
        }
    }
}
