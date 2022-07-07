using System;
using System.Linq;

namespace _05._Digits__Letters_and_Other
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string allDigits = new string(input
                .Where(ch => char.IsDigit(ch) == true)
                .ToArray());
            
            string allLetters = new string(input
                .Where(ch => char.IsLetter(ch) == true)
                .ToArray());
           
            string otherChars = new string(input
                .Where(ch => char.IsLetterOrDigit(ch) == false)
                .ToArray());

            Console.WriteLine(allDigits);
            Console.WriteLine(allLetters);
            Console.WriteLine(otherChars);
        }
    }
}
