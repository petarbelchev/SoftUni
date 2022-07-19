using System;
using System.Collections.Generic;

namespace _3._Simple_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');

            Array.Reverse(input);

            Stack<string> stack = new Stack<string>(input);

            int result = int.Parse(stack.Pop());

            while (stack.Count > 0)
            {
                string @operator = stack.Pop();

                if (@operator == "+")
                {
                    result += int.Parse(stack.Pop());
                }
                else
                {
                    result -= int.Parse(stack.Pop());
                }
            }

            Console.WriteLine(result);
        }
    }
}
