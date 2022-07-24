using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Sets_of_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> set1 = new HashSet<int>();
            HashSet<int> set2 = new HashSet<int>();
            int[] length = Console.ReadLine()
                .Split(' ',StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            for (int i = 0; i < length[0]; i++)
                set1.Add(int.Parse(Console.ReadLine()));
            for (int i = 0; i < length[1]; i++)
                set2.Add(int.Parse(Console.ReadLine()));
            foreach (var elem in set1)
                if (set2.Contains(elem))
                    Console.Write(elem + " ");
        }
    }
}
