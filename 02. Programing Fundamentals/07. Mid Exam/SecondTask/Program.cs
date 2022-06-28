using System;
using System.Collections.Generic;
using System.Linq;

namespace SecondTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();

            string cmd = Console.ReadLine();

            while (cmd != "Finish")
            {
                string[] cmdArgs = cmd.Split(" ",StringSplitOptions.RemoveEmptyEntries);
                string mainCmd = cmdArgs[0];
                int value = int.Parse(cmdArgs[1]);
                switch (mainCmd)
                {
                    case "Add":
                        numbers.Add(value);
                        break;

                    case "Remove":
                        if (numbers.Contains(value))
                        {
                            numbers.Remove(value);
                        }
                        break;

                    case "Replace":
                        if (numbers.Contains(value))
                        {
                            int replacement = int.Parse(cmdArgs[2]);
                            int indexValue = numbers.IndexOf(value);
                            numbers.Remove(value);
                            numbers.Insert(indexValue, replacement);                            
                        }
                        break;

                    case "Collapse":
                        numbers.RemoveAll(num => num < value);
                        break;
                }

                cmd = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
