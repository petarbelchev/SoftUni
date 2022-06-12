using System;

namespace _05._Multiplication_Sign
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[3];

            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine(CheckProduct(nums));
        }

        static string CheckProduct(int[] nums)
        {
            foreach (int num in nums)
            {
                if (num == 0)
                {
                    return "zero";
                }
            }

            int counter = 0;

            foreach (int num in nums)
            {
                if (num < 0)
                {
                    counter++;
                }
            }

            if (counter % 2 != 0)
            {
                return "negative";
            }

            return "positive";
        }
    }
}
