using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] startPoint = new int[2];

        int branchesCount = 0;

        char[,] pond = GetThePond(startPoint, ref branchesCount);

        var collectedBranches = new Stack<char>();

        int lostBranches = 0;

        string cmd;

        while ((cmd = Console.ReadLine()) != "end")
        {
            Move(pond, cmd, startPoint, collectedBranches, ref lostBranches);

            if (collectedBranches.Count + lostBranches == branchesCount)
                break;
        }

        if (collectedBranches.Count + lostBranches == branchesCount)
        {
            Console.WriteLine($"The Beaver successfully collect {collectedBranches.Count} wood branches: " + string.Join(", ", collectedBranches.Reverse()) + ".");
        }
        else
        {
            Console.WriteLine($"The Beaver failed to collect every wood branch. There are {branchesCount - collectedBranches.Count - lostBranches} branches left.");
        }

        for (int row = 0; row < pond.GetLength(0); row++)
        {
            for (int col = 0; col < pond.GetLength(1); col++)
            {
                Console.Write($"{(char)pond[row, col]} ");
            }
            Console.WriteLine();
        }
    }

    static char[,] GetThePond(int[] startPoint, ref int branchesCount)
    {
        int n = int.Parse(Console.ReadLine());
        char[,] pond = new char[n, n];
        for (int row = 0; row < n; row++)
        {
            char[] currCells = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse)
                .ToArray();

            for (int col = 0; col < currCells.Length; col++)
            {
                pond[row, col] = currCells[col];

                if (currCells[col] == 'B')
                {
                    startPoint[0] = row;
                    startPoint[1] = col;
                }
                else if (char.IsLower(currCells[col]))
                {
                    branchesCount++;
                }
            }
        }
        return pond;
    }

    static void Move(char[,] pond, string cmd, int[] startPoint, Stack<char> collectedBranches, ref int lostBranches)
    {
        pond[startPoint[0], startPoint[1]] = '-';

        if (cmd == "up" && startPoint[0] >= 1)
            startPoint[0]--;
        else if (cmd == "down" && startPoint[0] < pond.GetLength(0) - 1)
            startPoint[0]++;
        else if (cmd == "left" && startPoint[1] >= 1)
            startPoint[1]--;
        else if (cmd == "right" && startPoint[1] < pond.GetLength(1) - 1)
            startPoint[1]++;
        else
        {
            pond[startPoint[0], startPoint[1]] = 'B';
            if (collectedBranches.Count > 0)
            {
                collectedBranches.Pop();
                lostBranches++;
            }
            return;
        }

        if (pond[startPoint[0], startPoint[1]] == '-')
        {
            pond[startPoint[0], startPoint[1]] = 'B';
        }
        else if (pond[startPoint[0], startPoint[1]] == 'F')
        {
            pond[startPoint[0], startPoint[1]] = '-';

            if (cmd == "up" && startPoint[0] == 0)
                startPoint[0] = pond.GetLength(0) - 1;
            else if (cmd == "up")
                startPoint[0] = 0;
            else if (cmd == "down" && startPoint[0] == pond.GetLength(0))
                startPoint[0] = 0;
            else if (cmd == "down")
                startPoint[0] = pond.GetLength(0) - 1;
            else if (cmd == "left" && startPoint[1] == 0)
                startPoint[1] = pond.GetLength(1) - 1;
            else if (cmd == "left")
                startPoint[1] = 0;
            else if (cmd == "right" && startPoint[1] == pond.GetLength(1))
                startPoint[1] = 0;
            else if (cmd == "right")
                startPoint[1] = pond.GetLength(1) - 1;

            if (pond[startPoint[0], startPoint[1]] == '-')
                pond[startPoint[0], startPoint[1]] = 'B';
            else if (char.IsLetter(pond[startPoint[0], startPoint[1]]))
            {
                collectedBranches.Push(pond[startPoint[0], startPoint[1]]);
                pond[startPoint[0], startPoint[1]] = 'B';
            }

        }
        else if (char.IsLower(pond[startPoint[0], startPoint[1]]))
        {
            collectedBranches.Push(pond[startPoint[0], startPoint[1]]);
            pond[startPoint[0], startPoint[1]] = 'B';
        }
    }
}