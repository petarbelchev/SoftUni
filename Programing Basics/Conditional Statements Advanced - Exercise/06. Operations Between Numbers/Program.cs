using System;

namespace _06._Operations_Between_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double num1 = int.Parse(Console.ReadLine());
            double num2 = int.Parse(Console.ReadLine());
            char operation = char.Parse(Console.ReadLine());

            switch (operation)
            {
                case '+':
                    double result = num1 + num2;
                    if (result % 2 == 0)
                    {
                        Console.WriteLine($"{num1} + {num2} = {result} - even");
                    }
                    else
                    {
                        Console.WriteLine($"{num1} + {num2} = {result} - odd");
                    }
                    break;
                case '-':
                    result = num1 - num2;
                    if (result % 2 == 0)
                    {
                        Console.WriteLine($"{num1} - {num2} = {result} - even");
                    }
                    else
                    {
                        Console.WriteLine($"{num1} - {num2} = {result} - odd");
                    }
                    break;
                case '*':
                    result = num1 * num2;
                    if (result % 2 == 0)
                    {
                        Console.WriteLine($"{num1} * {num2} = {result} - even");
                    }
                    else
                    {
                        Console.WriteLine($"{num1} * {num2} = {result} - odd");
                    }
                    break;
                case '/':
                    if (num2 == 0)
                    {
                        Console.WriteLine($"Cannot divide {num1} by zero");
                    }
                    else
                    {
                    result = num1 / num2;
                    Console.WriteLine($"{num1} / {num2} = {result:f2}");
                    }
                    break;
                case '%':
                    if (num2 == 0)
                    {
                        Console.WriteLine($"Cannot divide {num1} by zero");
                    }
                    else
                    {
                        result = num1 % num2;
                        Console.WriteLine($"{num1} % {num2} = {result}");
                    }
                    break;
            }
        }
    }
}
