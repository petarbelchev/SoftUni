using System;

namespace _10._Odd_Even_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int nNumbers = int.Parse(Console.ReadLine());
            int odd = 0;
            int even = 0;

            for (int i = 1; i <= nNumbers; i += 1)
            {
                int numbers = int.Parse(Console.ReadLine());
                if (i % 2 != 0)
                {
                    odd += numbers;
                }
                else
                {
                    even += numbers;
                }
            }

            if (odd == even)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {odd}");
            }
            else
            {
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {Math.Abs(odd - even)}");
            }
        }
    }
}
