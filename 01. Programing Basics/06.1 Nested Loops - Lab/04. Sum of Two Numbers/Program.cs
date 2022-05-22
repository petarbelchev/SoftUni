using System;

namespace _04._Sum_of_Two_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int startNum = int.Parse(Console.ReadLine());
            int finishNum = int.Parse(Console.ReadLine());
            int magicNum = int.Parse(Console.ReadLine());
            int counter = 0;
            bool check = false;

            for (int firstNum = startNum; firstNum <= finishNum; firstNum++)
            {
                for (int secondNum = startNum; secondNum <= finishNum; secondNum++)
                {
                    counter++;

                    if (firstNum+secondNum == magicNum && check == false)
                    {
                        Console.WriteLine($"Combination N:{counter} ({firstNum} + {secondNum} = {magicNum})");
                        check = true;
                    }
                }
            }

            if (check == false)
            {
                Console.WriteLine($"{counter} combinations - neither equals {magicNum}");
            }
        }
    }
}
