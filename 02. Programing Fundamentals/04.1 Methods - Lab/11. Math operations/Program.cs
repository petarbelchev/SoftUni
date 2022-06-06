using System;

namespace _11._Math_operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double firstNum = double.Parse(Console.ReadLine());
            char @operator = char.Parse(Console.ReadLine());
            double secondNum = double.Parse(Console.ReadLine());

            double result = GetCalculate(firstNum, secondNum, @operator);

            Console.WriteLine(result);
        }

        static double GetCalculate(double num, double num2, char operation)
        {
            double result = 0;

            switch (operation)
            {
                case '/':
                    result = num / num2;
                    break;

                case '*':
                    result = num * num2;
                    break;

                case '+':
                    result = num + num2;
                    break;

                case '-':
                    result = num - num2;
                    break;
            }

            return result;
        }
    }
}
