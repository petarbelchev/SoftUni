using System;
using System.Collections.Generic;

namespace _02._Implement_the_CustomStack_Class
{
    class StartUp
    {
        static void Main()
        {
            var stack = new Stack<int>();

            var myStack = new MyStack();

            myStack.Push(1);
            myStack.Push(2);
            myStack.Push(3);
            myStack.Push(4);

            myStack.Pop();

            myStack.Peek();

            myStack.ForEach(el => Console.WriteLine(el));
        }
    }
}
