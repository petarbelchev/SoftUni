using System;
using System.Linq;

namespace _05._Sum_Even_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arrayOfNums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int sumOfEvens = 0;
            
            foreach (int currNum in arrayOfNums)
            {
                if (currNum % 2 == 0)
                {
                    sumOfEvens += currNum;
                }
            }

            Console.WriteLine(sumOfEvens);
        }
    }
}
