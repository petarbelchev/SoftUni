using System;
using System.Linq;

namespace _07._Equal_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arrayOfNums1 = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] arrayOfNums2 = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int sumOfNums = 0;
            bool isNotIdentical = false;

            for (int i = 0; i < arrayOfNums1.Length; i++)
            {
                if (arrayOfNums1[i] == arrayOfNums2[i])
                {
                    sumOfNums += arrayOfNums1[i];
                }
                else
                {
                    Console.WriteLine($"Arrays are not identical. Found difference at {i} index");
                    isNotIdentical = true;
                    break;
                }
            }

            if (!isNotIdentical)
            {
                Console.WriteLine($"Arrays are identical. Sum: {sumOfNums}");
            }
        }
    }
}
