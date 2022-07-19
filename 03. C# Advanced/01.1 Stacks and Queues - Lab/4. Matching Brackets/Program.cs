using System;
using System.Collections.Generic;

namespace _4._Matching_Brackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] expression = Console.ReadLine().ToCharArray();

            Stack<int> stackOfIndexes = new Stack<int>();

            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(')
                {
                    stackOfIndexes.Push(i);
                }
                else if (expression[i] == ')')
                {
                    for (int j = stackOfIndexes.Pop(); j <= i; j++)
                    {
                        Console.Write(expression[j]);
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
