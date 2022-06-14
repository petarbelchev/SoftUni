using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Merging_Lists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> firstList = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> secondList = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int shorterListCount = Math.Min(firstList.Count, secondList.Count);

            List<int> mergedList = new List<int>();

            for (int i = 0; i < shorterListCount; i++)
            {
                mergedList.Add(firstList[i]);
                mergedList.Add(secondList[i]);
            }

            if (firstList.Count > secondList.Count)
            {
                for (int i = shorterListCount; i < firstList.Count; i++)
                {
                    mergedList.Add(firstList[i]);
                }
            }
            else
            {
                for (int i = shorterListCount; i < secondList.Count; i++)
                {
                    mergedList.Add(secondList[i]);
                }
            }

            Console.WriteLine(String.Join(" ", mergedList));
        }
    }
}
