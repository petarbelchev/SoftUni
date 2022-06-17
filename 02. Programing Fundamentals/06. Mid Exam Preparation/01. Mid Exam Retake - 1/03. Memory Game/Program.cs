using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Memory_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> sequence = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string input = Console.ReadLine();

            int movesCounter = 0;

            while (input != "end")
            {
                int[] indexes = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                movesCounter++;

                if (!IsIndexesValid(sequence, indexes))
                {
                    string[] elemToAdd = new string[] {
                        $"-{movesCounter}a",
                        $"-{movesCounter}a"
                    };

                    sequence.InsertRange(sequence.Count / 2, elemToAdd);

                    Console.WriteLine("Invalid input! Adding additional elements to the board");
                }
                else
                {
                    if (IsHitEqualsElements(sequence, indexes))
                    {
                        string elementForRemove = sequence.ElementAt(indexes[0]);

                        sequence.RemoveAll(x => x == elementForRemove);

                        Console.WriteLine($"Congrats! You have found matching elements - {elementForRemove}!");
                    }
                    else
                    {
                        Console.WriteLine("Try again!");
                    }
                }

                if (sequence.Count <= 0)
                {
                    Console.WriteLine($"You have won in {movesCounter} turns!");
                    return;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Sorry you lose :(");
            Console.WriteLine(String.Join(" ", sequence));
        }

        static bool IsIndexesValid(List<string> sequence, int[] indexes)
        {
            if (indexes[0] == indexes[1]
                || indexes[0] < 0
                || indexes[0] >= sequence.Count
                || indexes[1] < 0
                || indexes[1] >= sequence.Count)
            {
                return false;
            }

            return true;
        }

        static bool IsHitEqualsElements(List<string> sequence, int[] indexes)
        {
            string element1 = sequence.ElementAt(indexes[0]);
            string element2 = sequence.ElementAt(indexes[1]);

            if (element1 == element2)
            {
                return true;
            }

            return false;
        }
    }
}
