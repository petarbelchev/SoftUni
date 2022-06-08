using System;

namespace _09._Palindrome_Integers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = string.Empty;

            while ((command = Console.ReadLine()) != "END")
            {
                string reversedNumber = GetReversedNumber(command);

                if (command == reversedNumber)
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }
            }
        }

        static string GetReversedNumber(string number)
        {
            char[] arrOfNumber = number.ToCharArray();

            Array.Reverse(arrOfNumber);

            return new string(arrOfNumber);
        }
    }
}
