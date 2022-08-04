using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericSwapMethodString
{
    internal class StartUp
    {
        static void Main()
        {
            var list = new List<string>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
                list.Add(Console.ReadLine());
            int[] indexes = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            Swap(list, indexes[0], indexes[1]);
        }

        static void Swap<T>(List<T> list, int firstIndex, int secondIndex)
        {
            var firstItem = list[firstIndex];
            list[firstIndex] = list[secondIndex];
            list[secondIndex] = firstItem;
            foreach (var item in list)
                Console.WriteLine($"{typeof(T)}: {item}");
        }
    }
}
