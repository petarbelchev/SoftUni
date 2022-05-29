using System;
using System.Linq;

namespace _06._Equal_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arrayOfNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            bool isHaveEqualsSum = false;

            for (int currElement = 0; currElement < arrayOfNumbers.Length; currElement++)
            {
                int leftSum = 0;
                int rightSum = 0;

                for (int leftSide = currElement - 1; leftSide >= 0; leftSide--)
                {
                    leftSum += arrayOfNumbers[leftSide];
                }

                for (int rightSide = currElement + 1; rightSide < arrayOfNumbers.Length; rightSide++)
                {
                    rightSum += arrayOfNumbers[rightSide];
                }

                if (leftSum == rightSum)
                {
                    Console.WriteLine(currElement);
                    isHaveEqualsSum = true;
                }
            }

            if (!isHaveEqualsSum)
            {
                Console.WriteLine("no");
            }
        }
    }
}
