using System;
using System.Collections.Generic;

namespace _08._Balanced_Parenthesis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string sequence = Console.ReadLine();

            if (sequence.Length == 1 || sequence.Length % 2 != 0)
            {
                Console.WriteLine("NO");
                return;
            }

            Stack<char> stack = new Stack<char>();

            foreach (char ch in sequence)
            {
                if (ch == '(' || ch == '{' || ch == '[')
                {
                    stack.Push(ch);
                }
                else
                {
                    if (ch == ')' && stack.Peek() == '(')
                    {
                        stack.Pop();
                    }
                    else if (ch == '}' && stack.Peek() == '{')
                    {
                        stack.Pop();
                    }
                    else if (ch == ']' && stack.Peek() == '[')
                    {
                        stack.Pop();
                    }
                    else
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }
            }

            Console.WriteLine("YES");
        }
    }
}
