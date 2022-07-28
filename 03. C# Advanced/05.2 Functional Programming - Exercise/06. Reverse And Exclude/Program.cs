using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] nums = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        int n = int.Parse(Console.ReadLine());

        Func<int, bool> isNotDivisible = num => num % n != 0;

        Console.WriteLine(string.Join(' ', nums.Where(isNotDivisible).Reverse()));
    }
}
