using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Stack_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] initialNums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Stack<int> stack = new Stack<int>(initialNums);

            string cmd = Console.ReadLine().ToLower();

            while (cmd != "end")
            {
                string[] cmdArgs = cmd.Split(' ');
                string mainCmd = cmdArgs[0];

                if (mainCmd == "add")
                {
                    int num1 = int.Parse(cmdArgs[1]);
                    int num2 = int.Parse(cmdArgs[2]);

                    stack.Push(num1);
                    stack.Push(num2);
                }
                else if (mainCmd == "remove")
                {
                    int countOfNumsToRemove = int.Parse(cmdArgs[1]);

                    if (countOfNumsToRemove <= stack.Count)
                    {
                        for (int i = 0; i < countOfNumsToRemove; i++)
                        {
                            stack.Pop();
                        }
                    }
                }

                cmd = Console.ReadLine().ToLower();
            }

            Console.WriteLine($"Sum: {stack.Sum()}");
        }
    }
}
