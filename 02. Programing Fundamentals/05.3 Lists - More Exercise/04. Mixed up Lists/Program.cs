using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Mixed_up_Lists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> firstList = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<int> secondList = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<int> thirdList = new List<int>();

            int indexFirstList = 0;
            int indexSecondList = secondList.Count - 1;
            int shortestList = Math.Min(firstList.Count, secondList.Count);

            for (int i = 0; i < shortestList; i++)
            {
                thirdList.Add(firstList[indexFirstList]);
                indexFirstList++;
                thirdList.Add(secondList[indexSecondList]);
                indexSecondList--;
            }

            int firstBorder;
            int secondBorder;

            if (firstList.Count > secondList.Count)
            {
                firstBorder = Math.Min(firstList[firstList.Count - 2], firstList[firstList.Count - 1]);
                secondBorder = Math.Max(firstList[firstList.Count - 2], firstList[firstList.Count - 1]);
            }
            else
            {
                firstBorder = Math.Min(secondList[0], secondList[1]);
                secondBorder = Math.Max(secondList[0], secondList[1]);
            }

            thirdList.Sort();

            foreach (var num in thirdList)
            {
                if (num > firstBorder && num < secondBorder)
                {
                    Console.Write(num + " ");
                }
            }
        }
    }
}
