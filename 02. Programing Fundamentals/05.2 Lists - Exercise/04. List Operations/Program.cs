using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._List_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] commands = input.Split();
                string mainCommand = commands[0];

                switch (mainCommand)
                {
                    case "Add":
                        int number = int.Parse(commands[1]);
                        numbers.Add(number);
                        break;

                    case "Insert":
                        number = int.Parse(commands[1]);
                        int index = int.Parse(commands[2]);

                        if (index < 0 || index >= numbers.Count)
                        {
                            Console.WriteLine("Invalid index");
                            input = Console.ReadLine();
                            continue;
                        }

                        numbers.Insert(index, number);
                        break;

                    case "Remove":
                        index = int.Parse(commands[1]);

                        if (index < 0 || index >= numbers.Count)
                        {
                            Console.WriteLine("Invalid index");
                            input = Console.ReadLine();
                            continue;
                        }

                        numbers.RemoveAt(index);
                        break;

                    case "Shift":
                        string adCommand = commands[1];
                        int shiftingCount = int.Parse(commands[2]);

                        for (int i = 1; i <= shiftingCount; i++)
                        {
                            if (adCommand == "left")
                            {
                                int firstNum = numbers[0];
                                numbers.RemoveAt(0);
                                numbers.Add(firstNum);
                            }
                            else if (adCommand == "right")
                            {
                                int lastNum = numbers[numbers.Count - 1];
                                numbers.RemoveAt(numbers.Count - 1);
                                numbers.Insert(0, lastNum);
                            }
                        }

                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
