using System;

namespace _08._Equal_Pairs
{
    class Program
    {
        static void Main(string[] args)
        {
            int equalsQuantity = int.Parse(Console.ReadLine());
            int currentEquals = 0;
            int lastEquals = 0;
            double sumAll = 0;
            int diff = 0;

            for (int i = 1; i <= equalsQuantity; i++)
            {
                int num1 = int.Parse(Console.ReadLine());
                int num2 = int.Parse(Console.ReadLine());

                currentEquals = num1 + num2;
                sumAll += currentEquals;

                if (currentEquals != lastEquals)
                {
                    diff = Math.Abs(lastEquals - currentEquals);
                    lastEquals = currentEquals;
                }
            }

            if (sumAll / equalsQuantity == currentEquals)
            {
                Console.WriteLine($"Yes, value={currentEquals}");
            }
            else
            {
                Console.WriteLine($"No, maxdiff={diff}");
            }
        }
    }
}
