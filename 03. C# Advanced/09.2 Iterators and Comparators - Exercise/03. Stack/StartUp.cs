using System;
using System.Linq;

namespace Stack
{
    internal class StartUp
    {
        static void Main()
        {
            var myStack = new MyStack<int>();

            string cmd;

            while ((cmd = Console.ReadLine()) != "END")
            {
                if (cmd.StartsWith("Push"))
                {
                    int[] elements = cmd
                        .Split("Push ", StringSplitOptions.RemoveEmptyEntries)[0]
                        .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();
                    myStack.Push(elements);
                }
                else if (cmd.StartsWith("Pop"))
                {
                    myStack.Pop();
                }
            }

            for (int i = 0; i < 2; i++)
            {
                foreach (var el in myStack)
                {
                    Console.WriteLine(el);
                }
            }
        }
    }
}
