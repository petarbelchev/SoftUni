using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._List_Manipulation_Basics
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            bool isMadedChanges = false;

            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] command = input.Split();

                if (command[0] == "Add")
                {
                    numbers.Add(int.Parse(command[1]));
                    isMadedChanges = true;
                }
                else if (command[0] == "Remove")
                {
                    numbers.Remove(int.Parse(command[1]));
                    isMadedChanges = true;
                }
                else if (command[0] == "RemoveAt")
                {
                    numbers.RemoveAt(int.Parse(command[1]));
                    isMadedChanges = true;
                }
                else if (command[0] == "Insert")
                {
                    numbers.Insert(int.Parse(command[2]), int.Parse(command[1]));
                    isMadedChanges = true;
                }
                else if (command[0] == "Contains")
                {
                    if (numbers.Contains(int.Parse(command[1])))
                    {
                        Console.WriteLine("Yes");
                    }
                    else
                    {
                        Console.WriteLine("No such number");
                    }
                }
                else if (command[0] == "PrintEven")
                {
                    Console.WriteLine(String.Join(" ", numbers.FindAll(x => x % 2 == 0)));
                }
                else if (command[0] == "PrintOdd")
                {
                    Console.WriteLine(String.Join(" ", numbers.FindAll(x => x % 2 != 0)));
                }
                else if (command[0] == "GetSum")
                {
                    Console.WriteLine(numbers.Sum());
                }
                else if (command[0] == "Filter")
                {
                    GetFilter(numbers, command[1], int.Parse(command[2]));
                }

                input = Console.ReadLine();
            }

            if (isMadedChanges)
            {
                Console.WriteLine(string.Join(" ", numbers));
            }
        }

        static void GetFilter(List<int> numbers, string condition, int number)
        {
            if (condition == "<")
            {
                Console.WriteLine(string.Join(" ", numbers.FindAll(x => x < number)));
            }
            else if (condition == ">")
            {
                Console.WriteLine(string.Join(" ", numbers.FindAll(x => x > number)));
            }
            else if (condition == ">=")
            {
                Console.WriteLine(string.Join(" ", numbers.FindAll(x => x >= number)));
            }
            else if (condition == "<=")
            {
                Console.WriteLine(string.Join(" ", numbers.FindAll(x => x <= number)));
            }
        }
    }
}
