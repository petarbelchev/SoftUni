using System;
using System.Collections.Generic;
using System.Linq;

namespace T02.TruffleHunter
{
    internal class Program
    {
        static char[,] field;
        static Dictionary<string, int> collectedTruffles = new Dictionary<string, int>();
        static int eatenByWildBoar = 0;

        static void Main()
        {
            field = GetTheField();

            string cmd;

            while ((cmd = Console.ReadLine()) != "Stop the hunt")
            {
                DoCommand(cmd);
            }

            int countBlack = 0;
            if (collectedTruffles.ContainsKey("Black truffle"))
                countBlack = collectedTruffles["Black truffle"];

            int countSummer = 0;
            if (collectedTruffles.ContainsKey("Summer truffle"))
                countSummer = collectedTruffles["Summer truffle"];

            int countWhite = 0;
            if (collectedTruffles.ContainsKey("White truffle"))
                countWhite = collectedTruffles["White truffle"];


            Console.WriteLine($"Peter manages to harvest {countBlack} black, {countSummer} summer, and {countWhite} white truffles.");

            Console.WriteLine($"The wild boar has eaten {eatenByWildBoar} truffles.");

            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    Console.Write($"{(char)field[row, col]} ");
                }
                Console.WriteLine();
            }
        }

        private static char[,] GetTheField()
        {
            int size = int.Parse(Console.ReadLine());
            char[,] field = new char[size, size];

            for (int row = 0; row < field.GetLength(0); row++)
            {
                char[] currRow = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < field.GetLength(1); col++)
                {
                    field[row, col] = currRow[col];
                }
            }
            return field;
        }

        private static void DoCommand(string command)
        {
            string[] cmdArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int row = int.Parse(cmdArgs[1]);
            int col = int.Parse(cmdArgs[2]);

            if (cmdArgs[0] == "Collect")
            {
                if (row >= 0 && row < field.GetLength(0) &&
                    col >= 0 && col < field.GetLength(1))
                {
                    if (field[row, col] == 'B')
                    {
                        if (collectedTruffles.ContainsKey("Black truffle") == false)
                            collectedTruffles.Add("Black truffle", 0);

                        collectedTruffles["Black truffle"]++;
                    }
                    else if (field[row, col] == 'S')
                    {
                        if (collectedTruffles.ContainsKey("Summer truffle") == false)
                            collectedTruffles.Add("Summer truffle", 0);

                        collectedTruffles["Summer truffle"]++;
                    }
                    else if (field[row, col] == 'W')
                    {
                        if (collectedTruffles.ContainsKey("White truffle") == false)
                            collectedTruffles.Add("White truffle", 0);

                        collectedTruffles["White truffle"]++;
                    }
                    field[row, col] = '-';
                }
            }
            else if (cmdArgs[0] == "Wild_Boar")
            {
                string direction = cmdArgs[3];

                if (direction == "up")
                {
                    for (int currRow = row; currRow >= 0 ; currRow -= 2)
                    {
                        if (field[currRow, col] != '-')
                        {
                            field[currRow, col] = '-';
                            eatenByWildBoar++;
                        }
                    }
                }
                else if (direction == "down")
                {
                    for (int currRow = row; currRow < field.GetLength(0); currRow += 2)
                    {
                        if (field[currRow, col] != '-')
                        {
                            field[currRow, col] = '-';
                            eatenByWildBoar++;
                        }
                    }
                }
                else if (direction == "left")
                {
                    for (int currCol = col; currCol >= 0; currCol -= 2)
                    {
                        if (field[row, currCol] != '-')
                        {
                            field[row, currCol] = '-';
                            eatenByWildBoar++;
                        }
                    }
                }
                else if (direction == "right")
                {
                    for (int currCol = col; currCol < field.GetLength(1); currCol += 2)
                    {
                        if (field[row, currCol] != '-')
                        {
                            field[row, currCol] = '-';
                            eatenByWildBoar++;
                        }
                    }
                }
            }
        }
    }
}
