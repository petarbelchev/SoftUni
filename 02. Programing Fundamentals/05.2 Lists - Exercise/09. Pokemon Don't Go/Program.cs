using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._Pokemon_Don_t_Go
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> distance = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            int sumRemovedElem = 0;

            while (distance.Count != 0)
            {
                int index = int.Parse(Console.ReadLine());

                if (index >= 0 && index < distance.Count)
                {
                    int valueOfIndex = distance[index];
                    distance.RemoveAt(index);
                    sumRemovedElem += valueOfIndex;

                    GetIncrDecr(distance, valueOfIndex);
                }
                else if (index < 0)
                {
                    int valueOfIndex = distance[0];
                    sumRemovedElem += valueOfIndex;
                    distance.RemoveAt(0);
                    distance.Insert(0, distance[distance.Count - 1]);

                    GetIncrDecr(distance, valueOfIndex);
                }
                else if (index >= distance.Count)
                {
                    int valueOfIndex = distance[distance.Count - 1];
                    sumRemovedElem += valueOfIndex;
                    distance.RemoveAt(distance.Count - 1);
                    distance.Add(distance[0]);

                    GetIncrDecr(distance, valueOfIndex);
                }
            }

            Console.WriteLine(sumRemovedElem);
        }

        static List<int> GetIncrDecr(List<int> distance, int valueOfIndex)
        {
            for (int i = 0; i < distance.Count; i++)
            {
                if (distance[i] <= valueOfIndex)
                {
                    distance[i] += valueOfIndex;
                }
                else
                {
                    distance[i] -= valueOfIndex;
                }
            }

            return distance;
        }
    }
}
