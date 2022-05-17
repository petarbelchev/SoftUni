using System;

namespace _02._Half_Sum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            int biggerNumber = 0;

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                sum += num;
                if (num >= biggerNumber)
                {
                    biggerNumber = num;
                }
            }

            if (biggerNumber == sum - biggerNumber)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {biggerNumber}");
            }
            else
            {
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {Math.Abs(biggerNumber - (sum - biggerNumber))}");
            }
        }
    }
}
