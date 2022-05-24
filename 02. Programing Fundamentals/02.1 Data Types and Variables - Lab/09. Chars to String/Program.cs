using System;

namespace _09._Chars_to_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string char1 = Console.ReadLine();
            string char2 = Console.ReadLine();
            string char3 = Console.ReadLine();

            string @string = char1 + char2 + char3;

            Console.WriteLine(@string);
        }
    }
}
