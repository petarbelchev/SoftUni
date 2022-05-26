using System;

namespace _02._FromLeftToTheRight
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int comparesCount = int.Parse(Console.ReadLine());

            for (int currCompare = 1; currCompare <= comparesCount; currCompare++)
            {
                string numbersForCompare = Console.ReadLine();

                string leftNumber = string.Empty;
                string rightNumber = string.Empty;
                bool isLeftNumber = true;

                for (int currDigit = 0; currDigit < numbersForCompare.Length; currDigit++)
                {
                    if (numbersForCompare[currDigit] == ' ')
                    {
                        isLeftNumber = false;
                    }

                    if (isLeftNumber && numbersForCompare[currDigit] != ' ')
                    {
                        leftNumber += numbersForCompare[currDigit];
                    }
                    else if (!isLeftNumber && numbersForCompare[currDigit] != ' ')
                    {
                        rightNumber += numbersForCompare[currDigit];
                    }
                }

                long leftNumberToInt = long.Parse(leftNumber);
                long rightNumberToInt = long.Parse(rightNumber);

                long biggerNumber = Math.Max(rightNumberToInt, leftNumberToInt);

                long sumDigitsBiggerNumber = 0;

                while (biggerNumber != 0)
                {
                    long currDigitBiggerNumber = biggerNumber % 10;
                    sumDigitsBiggerNumber += currDigitBiggerNumber;
                    biggerNumber /= 10;
                }

                Console.WriteLine(Math.Abs(sumDigitsBiggerNumber));
            }
        }
    }
}
