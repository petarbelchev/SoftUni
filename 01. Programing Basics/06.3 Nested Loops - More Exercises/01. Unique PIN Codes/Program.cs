using System;

namespace _01._Unique_PIN_Codes
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            for (int firstDigit = 1; firstDigit <= num1; firstDigit++)
            {
                if (firstDigit % 2 == 0)
                {
                    for (int secondDigit = 1; secondDigit <= num2; secondDigit++)
                    {
                        int primeCounter = 0;

                        for (int divideNum = 1; divideNum <= secondDigit; divideNum++)
                        {
                            if (secondDigit % divideNum == 0)
                            {
                                primeCounter++;
                            }
                        }

                        if (primeCounter == 2)
                        {
                            for (int thirdDigit = 1; thirdDigit <= num3; thirdDigit++)
                            {
                                if (thirdDigit % 2 == 0)
                                {
                                    Console.Write(firstDigit + " ");
                                    Console.Write(secondDigit + " ");
                                    Console.WriteLine(thirdDigit);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
