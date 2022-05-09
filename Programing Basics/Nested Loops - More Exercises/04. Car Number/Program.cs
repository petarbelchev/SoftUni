using System;

namespace _04._Car_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int startDigit = int.Parse(Console.ReadLine());
            int finishDigit = int.Parse(Console.ReadLine());

            for (int firstDigit = startDigit; firstDigit <= finishDigit; firstDigit++)
            {
                for (int secondDigit = startDigit; secondDigit <= finishDigit; secondDigit++)
                {
                    for (int thirdDigit = startDigit; thirdDigit <= finishDigit; thirdDigit++)
                    {
                        for (int fourthDigit = startDigit; fourthDigit <= finishDigit; fourthDigit++)
                        {
                            bool chek1 = (firstDigit % 2 == 0 && fourthDigit % 2 != 0) || (firstDigit % 2 != 0 && fourthDigit % 2 == 0);
                            bool chek2 = firstDigit > fourthDigit;
                            bool chek3 = (secondDigit+thirdDigit) % 2 == 0;

                            if (chek1 && chek2 && chek3)
                            {
                                Console.Write($"{firstDigit}{secondDigit}{thirdDigit}{fourthDigit} ");
                            }
                        }
                    }
                }
            }
        }
    }
}
