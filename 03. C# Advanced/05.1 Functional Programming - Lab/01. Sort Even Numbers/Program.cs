using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] nums = Console.ReadLine()
            .Split(", ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .Where(n => n % 2 == 0)
            .OrderBy(n => n)
            .ToArray();

        Console.WriteLine(string.Join(", ", nums));
    }
}
