using System;
using System.Collections.Generic;

namespace _02._Armory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] armoryField = new char[n, n];
            var mirrorsCoordinates = new List<int>();
            int startRow = -1;
            int startCol = -1;

            for (int row = 0; row < n; row++)
            {
                char[] rowData = Console.ReadLine().ToCharArray();

                for (int col = 0; col < n; col++)
                {
                    armoryField[row, col] = rowData[col];

                    if (rowData[col] == 'A')
                    {
                        startRow = row;
                        startCol = col;
                    }
                    else if (rowData[col] == 'M')
                    {
                        mirrorsCoordinates.Add(row);
                        mirrorsCoordinates.Add(col);
                    }
                }
            }

            int coins = 0;
            bool isHeLeaves = false;

            while (true)
            {
                string cmd = Console.ReadLine();

                armoryField[startRow, startCol] = '-';

                if (cmd == "up")
                    startRow--;
                else if (cmd == "down")
                    startRow++;
                else if (cmd == "left")
                    startCol--;
                else if (cmd == "right")
                    startCol++;

                if (startRow < 0 || startRow == n || startCol < 0 || startCol == n)
                {
                    isHeLeaves = true;
                    break;
                }

                if (armoryField[startRow, startCol] == 'M')
                {
                    armoryField[startRow, startCol] = '-';

                    if (startRow == mirrorsCoordinates[0])
                    {
                        startRow = mirrorsCoordinates[2];
                        startCol = mirrorsCoordinates[3];
                    }
                    else
                    {
                        startRow = mirrorsCoordinates[0];
                        startCol = mirrorsCoordinates[1];
                    }
                }
                else if (armoryField[startRow, startCol] != '-')
                {
                    coins += int.Parse(armoryField[startRow, startCol].ToString());
                }

                armoryField[startRow, startCol] = 'A';

                if (coins >= 65)
                    break;
            }

            if (isHeLeaves)
                Console.WriteLine("I do not need more swords!");
            else
                Console.WriteLine("Very nice swords, I will come back for more!");

            Console.WriteLine($"The king paid {coins} gold coins.");

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(armoryField[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
