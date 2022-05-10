using System;

namespace _09._Sum_of_Two_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int intervalStart = int.Parse(Console.ReadLine());
            int intervalFinish = int.Parse(Console.ReadLine());
            int magicNumber = int.Parse(Console.ReadLine());

            int combinationCounter = 0;
            bool isComFound = false;

            for (int firstNum = intervalStart; firstNum <= intervalFinish; firstNum++)
            {

                for (int secondNum = intervalStart; secondNum <= intervalFinish; secondNum++)
                {
                    combinationCounter++;

                    if (firstNum + secondNum == magicNumber)
                    {
                        isComFound = true;
                        Console.WriteLine($"Combination N:{combinationCounter} ({firstNum} + {secondNum} = {magicNumber})");
                        break;
                    }
                }

                if (isComFound)
                {
                    break;
                }
            }

            if (!isComFound)
            {
                Console.WriteLine($"{combinationCounter} combinations - neither equals {magicNumber}");
            }
        }
    }
}
