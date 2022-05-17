using System;

namespace _03._Lucky_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int startNum = 1111; startNum <= 9999; startNum++)
            {
                int currentNum = startNum;
                int fourthDigit = 0;
                int thirthDigit = 0;
                int secondthDigit = 0;
                int firstDigit = 0;

                for (int i = 4; i >= 1; i--)
                {
                    int currentDigit = currentNum % 10;

                    if (i == 4)
                    {
                        fourthDigit = currentDigit;
                    }
                    else if (i == 3)
                    {
                        thirthDigit = currentDigit;
                    }
                    else if (i == 2)
                    {
                        secondthDigit = currentDigit;
                    }
                    else if (i == 1)
                    {
                        firstDigit = currentDigit;
                    }

                    currentNum /= 10;
                }

                if (firstDigit == 0 || secondthDigit == 0 || thirthDigit == 0 || fourthDigit == 0)
                {
                    continue;
                }

                int firstTwo = firstDigit + secondthDigit;
                int secondTwo = thirthDigit + fourthDigit;

                if (firstTwo == secondTwo && n % firstTwo == 0)
                {
                    Console.Write($"{startNum} ");
                }
            }
        }
    }
}
