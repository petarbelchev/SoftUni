using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Periodic_Table
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> elements = new HashSet<string>();
            int countOfLines = int.Parse(Console.ReadLine());
            for (int i = 0; i < countOfLines; i++)
            {
                string[] line = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                foreach (var item in line)
                    elements.Add(item);
            }
            Console.WriteLine(string.Join(' ', elements.OrderBy(el => el)));
        }
    }
}
