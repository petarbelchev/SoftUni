using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomComparator
{
    internal class StartUp
    {
        static void Main()
        {
            int[] nums = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).OrderBy(n => n).ToArray();

            Array.Sort(nums, new Comparator());

            Console.WriteLine(string.Join(' ', nums));
        }
    }

    public class Comparator : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            if (x % 2 != 0 && y % 2 == 0)
            {
                return 1;
            }
            else if (x % 2 == 0 && y % 2 != 0)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
