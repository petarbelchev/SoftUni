using System;
using System.Linq;

namespace Froggy
{
    internal class StartUp
    {
        static void Main()
        {
            int[] stones = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var lake = new Lake(stones);

            Console.WriteLine(string.Join(", ", lake));
        }
    }
}
