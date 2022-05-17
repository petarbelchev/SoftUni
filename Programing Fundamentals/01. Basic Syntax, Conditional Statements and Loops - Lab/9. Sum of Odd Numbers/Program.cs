using System;

namespace _9._Sum_of_Odd_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int oddNumbersCount = int.Parse(Console.ReadLine());
            int oddNumbersSum = 0;
            int currOddNumber = 1;

            for (int i = 1; i <= oddNumbersCount; i++)
            {
                Console.WriteLine(currOddNumber);
                oddNumbersSum += currOddNumber;
                currOddNumber += 2;
            }

            Console.WriteLine($"Sum: {oddNumbersSum}");
        }
    }
}
