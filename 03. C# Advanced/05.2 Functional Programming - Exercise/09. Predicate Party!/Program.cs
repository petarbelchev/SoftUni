using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<string> guests = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .ToList();

        string cmd;

        while ((cmd = Console.ReadLine()) != "Party!")
        {
            string[] cmdArgs = cmd
            .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string mainCmd = cmdArgs[0];
            string firstArg = cmdArgs[1];
            string secondArg = cmdArgs[2];

            Predicate<string> predicate = null;

            if (firstArg == "StartsWith")
                predicate = name => name.StartsWith(secondArg);

            else if (firstArg == "EndsWith")
                predicate = name => name.EndsWith(secondArg);

            else if (firstArg == "Length")
                predicate = name => name.Length == int.Parse(secondArg);

            if (mainCmd == "Remove")
                guests.RemoveAll(predicate);
            else if (mainCmd == "Double")
            {
                for (int i = 0; i < guests.Count; i++)
                {
                    if (predicate(guests[i]))
                    {
                        guests.Insert(i, guests[i]);
                        i++;
                    }
                }
            }
        }

        if (guests.Count > 0)
        {
            Console.Write(string.Join(", ", guests));
            Console.WriteLine($" are going to the party!");
        }
        else
            Console.WriteLine("Nobody is going to the party!");
    }
}
