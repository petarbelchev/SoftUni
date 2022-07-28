using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] range = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        string command = Console.ReadLine();

        Predicate<int> isWantedNum = null;

        if (command.Contains("even"))
            isWantedNum = num => num % 2 == 0;
        else if (command.Contains("odd"))
            isWantedNum = num => num % 2 != 0;

        int start = range[0];
        int end = range[1];

        List<int> wantedNums = new List<int>();

        for (int i = start; i <= end; i++)
        {
            if (isWantedNum(i))
                wantedNums.Add(i);
        }

        Console.WriteLine(string.Join(' ', wantedNums));
    }
}
