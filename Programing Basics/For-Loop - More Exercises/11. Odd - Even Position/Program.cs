using System;

namespace _11._Odd___Even_Position
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double oddSum = 0;
            double oddMin = double.MaxValue;
            double oddMax = double.MinValue;
            double evenSum = 0;
            double evenMin = double.MaxValue;
            double evenMax = double.MinValue;

            bool isHaveOddMin = false;
            bool isHaveOddMax = false;
            bool isHaveEvenMin = false;
            bool isHaveEvenMax = false;

            for (int numbers = 1; numbers <= n; numbers++)
            {
                double currentNum = double.Parse(Console.ReadLine());

                if (numbers % 2 == 0)
                {
                    evenSum += currentNum;

                    if (currentNum > evenMax)
                    {
                        evenMax = currentNum;
                        isHaveEvenMax = true;
                    }

                    if (currentNum < evenMin)
                    {
                        evenMin = currentNum;
                        isHaveEvenMin = true;
                    }
                }
                else
                {
                    oddSum += currentNum;

                    if (currentNum > oddMax)
                    {
                        oddMax = currentNum;
                        isHaveOddMax = true;
                    }

                    if (currentNum < oddMin)
                    {
                        oddMin = currentNum;
                        isHaveOddMin = true;
                    }
                }
            }

            Console.WriteLine($"OddSum={oddSum:f2},");

            if (isHaveOddMin)
            {
                Console.WriteLine($"OddMin={oddMin:f2},");
            }
            else
            {
                Console.WriteLine($"OddMin=No,");
            }

            if (isHaveOddMax)
            {
                Console.WriteLine($"OddMax={oddMax:f2},");
            }
            else
            {
                Console.WriteLine($"OddMax=No,");
            }

            Console.WriteLine($"EvenSum={evenSum:f2},");

            if (isHaveEvenMin)
            {
                Console.WriteLine($"EvenMin={evenMin:f2},");
            }
            else
            {
                Console.WriteLine($"EvenMin=No,");
            }

            if (isHaveEvenMax)
            {
                Console.WriteLine($"EvenMax={evenMax:f2}");
            }
            else
            {
                Console.WriteLine($"EvenMax=No");
            }
        }
    }
}
