using System;
using System.Linq;

class Program
{
    static void Main()
    {
        Func<string, bool> isValidWord = word => char.IsUpper(word[0]);

        string[] words = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Where(isValidWord)
            .ToArray();

        Console.WriteLine(string.Join(Environment.NewLine, words));
    }
}
