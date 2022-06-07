using System;

namespace _04._Password_Validator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            if (CheckCharsCount(password)
                && CheckDigitsCount(password)
                && CheckLettersAndDigits(password))
            {
                Console.WriteLine("Password is valid");
            }
            else
            {
                if (!CheckCharsCount(password))
                {
                    Console.WriteLine("Password must be between 6 and 10 characters");
                }

                if (!CheckLettersAndDigits(password))
                {
                    Console.WriteLine("Password must consist only of letters and digits");
                }

                if (!CheckDigitsCount(password))
                {
                    Console.WriteLine("Password must have at least 2 digits");
                }
            }
        }

        static bool CheckCharsCount(string password)
        {
            if (password.Length >= 6 && password.Length <= 10)
            {
                return true;
            }

            return false;
        }

        static bool CheckLettersAndDigits(string password)
        {
            char[] chars = password.ToCharArray();

            foreach (char ch in chars)
            {
                if (!(ch >= 65 && ch <= 90)
                    && !(ch >= 97 && ch <= 122)
                    && !(ch >= 48 && ch <= 57))
                {
                    return false;
                }
            }

            return true;
        }

        static bool CheckDigitsCount(string password)
        {
            char[] chars = password.ToCharArray();

            int digitsCount = 0;

            foreach (char ch in chars)
            {
                if (ch >= 48 && ch <= 57)
                {
                    digitsCount++;
                }
            }

            if (digitsCount >= 2)
            {
                return true;
            }

            return false;
        }
    }
}
