using System;

namespace _10._Top_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int endValue = int.Parse(Console.ReadLine());

            for (int currNum = 1; currNum <= endValue; currNum++)
            {
                if (CheckIsDivisible(currNum) && CheckForOddDigit(currNum))
                {
                    Console.WriteLine(currNum);
                }
            }
        }

        static bool CheckForOddDigit(int currNum)
        {
            while (currNum != 0)
            {
                int digit = currNum % 10;

                if (digit % 2 != 0)
                {
                    return true;
                }

                currNum /= 10;
            }

            return false;
        }

        static bool CheckIsDivisible(int currNum)
        {
            int sum = 0;

            while (currNum != 0)
            {
                int digit = currNum % 10;
                sum += digit;
                currNum /= 10;
            }

            if (sum % 8 == 0)
            {
                return true;
            }

            return false;
        }
    }
}
