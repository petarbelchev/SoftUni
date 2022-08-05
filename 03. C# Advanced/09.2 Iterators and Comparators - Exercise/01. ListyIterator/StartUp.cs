using System;
using System.Collections.Generic;

namespace ListyIterator
{
    internal class StartUp
    {
        static void Main()
        {
            string[] firstCmd = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var elements = new List<string>();

            if (firstCmd.Length > 1)
            {
                for (int i = 1; i < firstCmd.Length; i++)
                {
                    elements.Add(firstCmd[i]);
                }
            }

            var listIterator = new ListyIterator<string>();
            listIterator.Create(elements.ToArray());

            string cmd;
            while ((cmd = Console.ReadLine()) != "END")
            {
                if (cmd == "Move")
                {
                    Console.WriteLine(listIterator.Move());
                }
                else if (cmd == "Print")
                {
                    listIterator.Print();
                }
                else if (cmd == "HasNext")
                {
                    Console.WriteLine(listIterator.HasNext());
                }
            }
        }
    }
}
