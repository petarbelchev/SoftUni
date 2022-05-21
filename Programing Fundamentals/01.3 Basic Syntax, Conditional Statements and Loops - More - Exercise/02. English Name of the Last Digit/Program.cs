using System;

namespace _02._English_Name_of_the_Last_Digit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int lastDigit = number % 10;

            string spelling = lastDigit == 0 ? "zero" : lastDigit == 1 ? "one" : lastDigit == 2 ? "two" : lastDigit == 3 ? "three" : lastDigit == 4 ? "four" : lastDigit == 5 ? "five" : lastDigit == 6 ? "six" : lastDigit == 7 ? "seven" : lastDigit == 8 ? "eight" : "nine";

            Console.WriteLine(spelling);
        }
    }
}
