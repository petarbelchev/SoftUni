using System;
using System.Collections.Generic;

namespace GenericCountMethodDoubles
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var box = new List<Box<double>>();
            for (int i = 0; i < n; i++)
            {
                box.Add(new Box<double>(double.Parse(Console.ReadLine())));
            }
            double doubleToCompare = double.Parse(Console.ReadLine());

            Console.WriteLine(Compare(box, doubleToCompare));
        }

        private static int Compare(List<Box<double>> box, double doubleToCompare)
        {
            int counter = 0;
            for (int i = 0; i < box.Count; i++)
            {
                if (box[i].CompareTo(doubleToCompare) > 0)
                {
                    counter++;
                }
            }
            return counter;
        }
    }
}
