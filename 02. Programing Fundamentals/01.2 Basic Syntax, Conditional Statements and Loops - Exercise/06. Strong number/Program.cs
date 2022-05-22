using System;

namespace _06._Strong_number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int sumFactorials = 0;
            int currNum = number;

            for (int i = 0; i < number.ToString().Length; i++)
            {
                int currDigit = currNum % 10;
                int currFactorial = currDigit;

                for (int multiplier = currDigit - 1; multiplier > 1; multiplier--)
                {
                    currFactorial *= multiplier;
                }

                if (currFactorial == 0)
                {
                    currFactorial = 1;
                }

                currNum /= 10;
                sumFactorials += currFactorial;
            }

            if (sumFactorials == number)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
