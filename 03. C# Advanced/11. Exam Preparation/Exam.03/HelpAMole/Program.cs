using System;
using System.Collections.Generic;

namespace HelpAMole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] field = new char[n, n];
            int startRow = 0;
            int startCol = 0;
            List<int> specialLocations = new List<int>();


            for (int row = 0; row < n; row++)
            {
                char[] rowValues = Console.ReadLine()
                    .ToCharArray();

                for (int col = 0; col < n; col++)
                {
                    field[row, col] = rowValues[col];

                    if (rowValues[col] == 'M')
                    {
                        startRow = row;
                        startCol = col;
                    }
                    else if (rowValues[col] == 'S')
                    {
                        specialLocations.Add(row);
                        specialLocations.Add(col);
                    }
                }
            }

            int collectedPoints = 0;

            while (true)
            {
                string cmd = Console.ReadLine();

                if (cmd == "End")
                    break;

                if (cmd == "up")
                {
                    if (startRow - 1 < 0)
                    {
                        Console.WriteLine("Don't try to escape the playing field!");
                        continue;
                    }
                    field[startRow, startCol] = '-';
                    startRow--;
                }
                else if (cmd == "down")
                {
                    if (startRow + 1 == n)
                    {
                        Console.WriteLine("Don't try to escape the playing field!");
                        continue;
                    }
                    field[startRow, startCol] = '-';
                    startRow++;
                }
                else if (cmd == "left")
                {
                    if (startCol - 1 < 0)
                    {
                        Console.WriteLine("Don't try to escape the playing field!");
                        continue;
                    }
                    field[startRow, startCol] = '-';
                    startCol--;
                }
                else if (cmd == "right")
                {
                    if (startCol + 1 == n)
                    {
                        Console.WriteLine("Don't try to escape the playing field!");
                        continue;
                    }
                    field[startRow, startCol] = '-';
                    startCol++;
                }

                if (field[startRow, startCol] == 'S')
                {
                    field[startRow, startCol] = '-';

                    if (startRow == specialLocations[0] && startCol == specialLocations[1])
                    {
                        startRow = specialLocations[2];
                        startCol = specialLocations[3];
                    }
                    else
                    {
                        startRow = specialLocations[0];
                        startCol = specialLocations[1];
                    }

                    collectedPoints -= 3;
                }
                else if (field[startRow, startCol] != '-')
                {
                    collectedPoints += int.Parse(field[startRow, startCol].ToString());
                }

                field[startRow, startCol] = 'M';

                if (collectedPoints >= 25)
                    break;
            }

            if (collectedPoints >= 25)
            {
                Console.WriteLine("Yay! The Mole survived another game!");
                Console.WriteLine($"The Mole managed to survive with a total of {collectedPoints} points.");
            }
            else
            {
                Console.WriteLine("Too bad! The Mole lost this battle!");
                Console.WriteLine($"The Mole lost the game with a total of {collectedPoints} points.");
            }

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(field[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
