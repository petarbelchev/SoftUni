using System;

namespace _05._Add_and_Subtract
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int thirdNum = int.Parse(Console.ReadLine());

            int sum = GetAddNums(firstNum, secondNum);
            int subtract = GetSubtract(sum, thirdNum);

            Console.WriteLine(subtract);
        }

        static int GetAddNums(int num1, int num2)
        {
            return num1 + num2;
        }

        static int GetSubtract(int num1, int num2)
        {
            return num1 - num2;
        }
    }
}
