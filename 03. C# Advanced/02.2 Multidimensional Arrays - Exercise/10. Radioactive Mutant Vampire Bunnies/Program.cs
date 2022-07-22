using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._RAMutVamBun
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] rowsCols = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            char[,] lair = new char[rowsCols[0], rowsCols[1]];

            int startRow = 0;
            int startCol = 0;

            for (int row = 0; row < lair.GetLength(0); row++)
            {
                char[] currRowChars = Console.ReadLine().ToCharArray();

                for (int col = 0; col < lair.GetLength(1); col++)
                {
                    lair[row, col] = currRowChars[col];

                    if (lair[row, col] == 'P')
                    {
                        startRow = row;
                        startCol = col;
                    }
                }
            }

            char[] directions = Console.ReadLine().ToCharArray();

            bool isPlayerWon = false;
            bool isPlayerDead = false;

            foreach (char direction in directions)
            {
                int newStartRow = startRow;
                int newStartCol = startCol;

                lair[startRow, startCol] = '.';

                if (direction == 'U')
                    newStartRow--;

                else if (direction == 'D')
                    newStartRow++;

                else if (direction == 'L')
                    newStartCol--;

                else if (direction == 'R')
                    newStartCol++;

                if (newStartRow < 0 || newStartRow >= lair.GetLength(0) || newStartCol < 0 || newStartCol >= lair.GetLength(1))
                {
                    isPlayerWon = true;
                }
                else
                {
                    startRow = newStartRow;
                    startCol = newStartCol;

                    if (lair[startRow, startCol] == 'B')
                        isPlayerDead = true;
                    else
                        lair[startRow, startCol] = 'P';
                }

                List<Coordinates> coordinates = new List<Coordinates>();

                for (int row = 0; row < lair.GetLength(0); row++)
                {
                    for (int col = 0; col < lair.GetLength(1); col++)
                    {
                        if (lair[row, col] == 'B')
                        {
                            coordinates.Add(new Coordinates(row, col));                            
                        }
                    }
                }

                foreach (var coor in coordinates)
                {
                    int row = coor.Row;
                    int col = coor.Col;

                    if (row - 1 >= 0)
                    {
                        if (lair[row - 1, col] == 'P')
                            isPlayerDead = true;

                        lair[row - 1, col] = 'B';
                    }

                    if (row + 1 < lair.GetLength(0))
                    {
                        if (lair[row + 1, col] == 'P')
                            isPlayerDead |= true;

                        lair[row + 1, col] = 'B';
                    }

                    if (col - 1 >= 0)
                    {
                        if (lair[row, col - 1] == 'P')
                            isPlayerDead = true;

                        lair[row, col - 1] = 'B';
                    }

                    if (col + 1 < lair.GetLength(1))
                    {
                        if (lair[row, col + 1] == 'P')
                            isPlayerDead = true;

                        lair[row, col + 1] = 'B';
                    }
                }

                if (isPlayerWon || isPlayerDead)
                {
                    break;
                }
            }

            for (int row = 0; row < lair.GetLength(0); row++)
            {
                for (int col = 0; col < lair.GetLength(1); col++)
                {
                    Console.Write(lair[row, col]);
                }
                Console.WriteLine();
            }

            if (isPlayerWon)
            {
                Console.WriteLine($"won: {startRow} {startCol}");
            }
            else if (!isPlayerWon && isPlayerDead)
            {
                Console.WriteLine($"dead: {startRow} {startCol}");
            }
        }
    }

    class Coordinates
    {
        public Coordinates(int row, int col)
        {
            Row = row;
            Col = col;
        }

        public int Row { get; set; }
        public int Col { get; set; }
    }
}
