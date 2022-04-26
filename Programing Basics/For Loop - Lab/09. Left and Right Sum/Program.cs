using System;

namespace _09._Left_and_Right_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int nNumbers = int.Parse(Console.ReadLine());
            int leftNumber = 0;
            int rightNumber = 0;

            for (int i = 1; i <= nNumbers; i += 1)
            {
                leftNumber += int.Parse(Console.ReadLine());
            }

            for (int i = 1; i <= nNumbers; i += 1)
            {
                rightNumber += int.Parse(Console.ReadLine());
            }

            if (leftNumber == rightNumber)
            {
                Console.WriteLine($"Yes, sum = {leftNumber}");
            }
            else
            {
                Console.WriteLine($"No, diff = {Math.Abs(leftNumber - rightNumber)}");
            }
        }
    }
}
