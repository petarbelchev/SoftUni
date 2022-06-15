using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Change_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] commands = input.Split();
                int element = int.Parse(commands[1]);

                if (commands[0] == "Delete")
                {
                    numbers.RemoveAll(x => x == element);
                }
                else if (commands[0] == "Insert")
                {
                    int index = int.Parse(commands[2]);
                    numbers.Insert(index, element);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
