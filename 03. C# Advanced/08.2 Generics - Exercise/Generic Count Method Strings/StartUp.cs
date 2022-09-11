using System;
using System.Collections.Generic;

namespace GenericCountMethodStrings
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var box = new List<Box<string>>();
            for (int i = 0; i < n; i++)
            {
                box.Add(new Box<string>(Console.ReadLine()));
            }
            string strToCompare = Console.ReadLine();

            Console.WriteLine(Compare(box, strToCompare));
        }

        private static int Compare(List<Box<string>> box, string strToCompare)
        {
            int counter = 0;
            for (int i = 0; i < box.Count; i++)
            {
                if (box[i].CompareTo(strToCompare) > 0)
                {
                    counter++;
                }
            }
            return counter;
        }
    }
}
