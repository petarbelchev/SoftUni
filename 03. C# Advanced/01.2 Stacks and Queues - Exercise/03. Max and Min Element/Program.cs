using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Max_and_Min_Element
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>();

            for (int i = 1; i <= n; i++)
            {
                int[] currQuery = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                if (currQuery[0] == 1)
                {
                    stack.Push(currQuery[1]);
                }
                else if (stack.Count > 0)
                {
                    if (currQuery[0] == 2)
                    {
                        stack.Pop();
                    }
                    else if (currQuery[0] == 3)
                    {
                        Console.WriteLine(stack.Max());
                    }
                    else if (currQuery[0] == 4)
                    {
                        Console.WriteLine(stack.Min());
                    }
                }
            }

            Console.Write(string.Join(", ", stack));
        }
    }
}
