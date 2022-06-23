using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Inventory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> items = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();

            string command = Console.ReadLine();

            while (command != "Craft!")
            {
                string[] cmdArgs = command.Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                string mainCmd = cmdArgs[0];
                string item = cmdArgs[1];

                if (mainCmd == "Collect")
                {
                    if (!items.Contains(item))
                    {
                        items.Add(item);
                    }
                }
                else if (mainCmd == "Drop")
                {
                    if (items.Contains(item))
                    {
                        items.Remove(item);
                    }
                }
                else if (mainCmd == "Combine Items")
                {
                    string[] oldAndNewItem = item
                        .Split(":", StringSplitOptions.RemoveEmptyEntries);

                    if (items.Contains(oldAndNewItem[0]))
                    {
                        int indexOldItem = items.IndexOf(oldAndNewItem[0]);

                        items.Insert(indexOldItem + 1, oldAndNewItem[1]);
                    }
                }
                else if (mainCmd == "Renew")
                {
                    if (items.Contains(item))
                    {
                        items.Remove(item);
                        items.Add(item);
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", items));
        }
    }
}
