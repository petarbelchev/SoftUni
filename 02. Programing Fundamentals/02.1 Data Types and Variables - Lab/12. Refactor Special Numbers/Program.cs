using System;

namespace _12._Refactor_Special_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int endOfRange = int.Parse(Console.ReadLine());
            bool isSpecialNumber = false;

            for (int currNum = 1; currNum <= endOfRange; currNum++)
            {
                int sum = 0;
                int i = currNum;

                while (i > 0)
                {
                    sum += i % 10;
                    i /= 10;
                }

                isSpecialNumber = (sum == 5) || (sum == 7) || (sum == 11);

                Console.WriteLine("{0} -> {1}", currNum, isSpecialNumber);
            }
        }
    }
}