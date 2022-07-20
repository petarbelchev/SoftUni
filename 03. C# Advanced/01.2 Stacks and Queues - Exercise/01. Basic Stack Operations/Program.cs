using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Basic_Stack_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] NSX = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            
            int numCountToPush = NSX[0];
            int numCountToPop = NSX[1];
            int numToPeek = NSX[2];

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < numCountToPush; i++)
            {
                stack.Push(numbers[i]);
            }

            if (stack.Count > numCountToPop)
            {
                for (int i = 1; i <= numCountToPop; i++)
                {
                    stack.Pop();
                }
            }
            else
            {
                stack.Clear();
                Console.WriteLine("0");
                return;
            }

            if (stack.Contains(numToPeek))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(stack.Min());
            }
        }
    }
}
