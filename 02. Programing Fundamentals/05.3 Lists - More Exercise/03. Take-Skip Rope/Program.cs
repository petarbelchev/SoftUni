using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03._Take_Skip_Rope
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<int> nums = new List<int>();
            List<char> nonNums = new List<char>();

            foreach (char item in input)
            {
                if (item >= 48 && item <= 57)
                {
                    nums.Add(int.Parse(item.ToString()));
                }
                else
                {
                    nonNums.Add(item);
                }
            }

            List<int> takeList = new List<int>();
            List<int> skipList = new List<int>();

            for (int i = 0; i < nums.Count; i++)
            {
                if (i % 2 != 0)
                {
                    skipList.Add(nums.ElementAt(i));
                }
                else
                {
                    takeList.Add(nums.ElementAt(i));
                }
            }

            List<char> result = new List<char>();

            for (int i = 0; i < takeList.Count; i++)
            {
                for (int j = 0; j < takeList[i]; j++)
                {
                    if (nonNums.Count > 0)
                    {
                        result.Add(nonNums[0]);
                        nonNums.RemoveAt(0);
                    }
                }

                for (int j = 0; j < skipList[i]; j++)
                {
                    if (nonNums.Count > 0)
                    {
                        nonNums.RemoveAt(0);
                    }
                }
            }

            Console.WriteLine(string.Join("", result));
        }
    }
}
