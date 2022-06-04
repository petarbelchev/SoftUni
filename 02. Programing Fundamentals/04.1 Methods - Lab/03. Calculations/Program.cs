using System;

namespace _03._Calculations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());

            switch (command)
            {
                case "add":
                    GetAdd(num1, num2);
                    break;

                case "multiply":
                    GetMultiply(num1, num2);
                    break;

                case "subtract":
                    GetSubtract(num1, num2);
                    break;

                case "divide":
                    GetDivide(num1, num2);
                    break;
            }
        }

        static void GetAdd(int firstNum, int secondNum)
        {
            Console.WriteLine(firstNum + secondNum);
        }

        static void GetMultiply(int firstNum, int secondNum)
        {
            Console.WriteLine(firstNum * secondNum);
        }

        static void GetSubtract(int firstNum, int secondNum)
        {
            Console.WriteLine(firstNum - secondNum);
        }

        static void GetDivide(int firstNum, int secondNum)
        {
            Console.WriteLine(firstNum / secondNum);
        }
    }
}
