using System;

namespace T02.TheBattleOfTheFiveArmies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int armyArmor = int.Parse(Console.ReadLine());
            int mapRows = int.Parse(Console.ReadLine());
            char[][] map = new char[mapRows][];
            int startRow = 0;
            int startCol = 0;
            int rowsLength = 0;
            

            for (int row = 0; row < mapRows; row++)
            {
                char[] rowData = Console.ReadLine()
                    .ToCharArray();
                rowsLength = rowData.Length;
                map[row] = new char[rowsLength];

                for (int col = 0; col < rowsLength; col++)
                {
                    map[row][col] = rowData[col];

                    if (rowData[col] == 'A')
                    {
                        startRow = row;
                        startCol = col;
                    }
                }
            }

            while (true)
            {
                string[] cmdArgs = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                int enemyRow = int.Parse(cmdArgs[1]);
                int enemyCol = int.Parse(cmdArgs[2]);
                string move = cmdArgs[0];

                map[enemyRow][enemyCol] = 'O';

                if (move == "up" && startRow - 1 >= 0)
                {
                    map[startRow][startCol] = '-';
                    startRow--;
                }
                else if (move == "down" && startRow + 1 < mapRows)
                {
                    map[startRow][startCol] = '-';
                    startRow++;
                }
                else if (move == "left" && startCol - 1 >= 0)
                {
                    map[startRow][startCol] = '-';
                    startCol--;
                }
                else if (move == "right" && startCol + 1 < rowsLength)
                {
                    map[startRow][startCol] = '-';
                    startCol++;
                }

                armyArmor--;

                if (armyArmor <= 0)
                {
                    map[startRow][startCol] = 'X';
                    Console.WriteLine($"The army was defeated at {startRow};{startCol}.");

                    break;
                }

                if (map[startRow][startCol] == 'O')
                {
                    armyArmor -= 2;

                    if (armyArmor <= 0)
                    {
                        map[startRow][startCol] = 'X';
                        Console.WriteLine($"The army was defeated at {startRow};{startCol}.");

                        break;
                    }
                    else
                        map[startRow][startCol] = 'A';
                }
                else if (map[startRow][startCol] == 'M')
                {
                    map[startRow][startCol] = '-';
                    Console.WriteLine($"The army managed to free the Middle World! Armor left: {armyArmor}");

                    break;
                }
                else if (map[startRow][startCol] == '-')
                    map[startRow][startCol] = 'A';
            }

            for (int row = 0; row < mapRows; row++)
            {
                for (int col = 0; col < rowsLength; col++)
                    Console.Write(map[row][col]);

                Console.WriteLine();
            }
        }
    }
}
