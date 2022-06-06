using System;
using System.Linq;

namespace _10._Multiply_Evens_by_Odds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int number = Math.Abs(int.Parse(input));
            int[] evenDigits = new int[input.Length];
            int[] oddDigits = new int[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                int digit = number % 10;
                if (digit % 2 == 0)
                {
                    evenDigits[i] = digit;
                }
                else
                {
                    oddDigits[i] = digit;
                }

                number /= 10;
            }

            int result = GetMultipleOfEvenAndOdds(evenDigits, oddDigits);

            Console.WriteLine(result);
        }

        static int GetMultipleOfEvenAndOdds(int[] evenDigits, int[] oddDigits)
        {
            return GetSumOfEvenDigits(evenDigits) * GetSumOfOddDigits(oddDigits);
        }

        static int GetSumOfEvenDigits(int[] digits)
        {
            int sum = 0;

            foreach (int digit in digits)
            {
                sum += digit;
            }

            return sum;
        }

        static int GetSumOfOddDigits(int[] digits)
        {
            int sum = 0;

            foreach (int digit in digits)
            {
                sum += digit;
            }

            return sum;
        }
    }
}
