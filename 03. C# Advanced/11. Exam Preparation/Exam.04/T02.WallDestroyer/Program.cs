using System;

namespace T02.WallDestroyer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var wall = new char[n, n];
            int startRow = 0;
            int startCol = 0;

            for (int row = 0; row < n; row++)
            {
                var rowData = Console.ReadLine().ToCharArray();

                for (int col = 0; col < n; col++)
                {
                    wall[row, col] = rowData[col];

                    if (rowData[col] == 'V')
                    {
                        startRow = row;
                        startCol = col;
                    }
                }
            }

            int holesCount = 1;
            int rodsCount = 0;

            while (true)
            {
                string cmd = Console.ReadLine();

                if (cmd == "End")
                {
                    Console.WriteLine($"Vanko managed to make {holesCount} hole(s) and he hit only {rodsCount} rod(s).");

                    break;
                }

                int initRow = startRow;
                int initCol = startCol;

                if (cmd == "up" && startRow - 1 >= 0)
                {
                    wall[startRow, startCol] = '*';
                    startRow--;
                }
                else if (cmd == "down" && startRow + 1 < n)
                {
                    wall[startRow, startCol] = '*';
                    startRow++;
                }
                else if (cmd == "left" && startCol - 1 >= 0)
                {
                    wall[startRow, startCol] = '*';
                    startCol--;
                }
                else if (cmd == "right" && startCol + 1 < n)
                {
                    wall[startRow, startCol] = '*';
                    startCol++;
                }

                if (wall[startRow, startCol] == 'R')
                {
                    startRow = initRow;
                    startCol = initCol;

                    wall[startRow, startCol] = 'V';
                    rodsCount++;

                    Console.WriteLine("Vanko hit a rod!");
                }
                else if (wall[startRow, startCol] == '*')
                {
                    Console.WriteLine($"The wall is already destroyed at position [{startRow}, {startCol}]!");
                    wall[startRow, startCol] = 'V';
                }
                else if (wall[startRow, startCol] == 'C')
                {
                    wall[startRow, startCol] = 'E';
                    holesCount++;
                    Console.WriteLine($"Vanko got electrocuted, but he managed to make {holesCount} hole(s).");

                    break;
                }
                else if (wall[startRow, startCol] == '-')
                {
                    holesCount++;
                    wall[startRow, startCol] = 'V';
                }
            }

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                    Console.Write(wall[row, col]);

                Console.WriteLine();
            }
        }
    }
}
