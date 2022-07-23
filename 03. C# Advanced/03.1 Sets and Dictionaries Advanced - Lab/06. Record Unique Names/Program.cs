using System;
using System.Collections.Generic;

namespace _06._ReUnNam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfNames = int.Parse(Console.ReadLine());
            HashSet<string> names = new HashSet<string>();

            for (int i = 0; i < countOfNames; i++)
            {
                string name = Console.ReadLine();
                names.Add(name);
            }

            Console.WriteLine(string.Join(Environment.NewLine, names));
        }
    }
}
