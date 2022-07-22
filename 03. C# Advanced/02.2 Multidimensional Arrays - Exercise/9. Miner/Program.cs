using System;

namespace _9._Miner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());

            string[] cmdToMove = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            char[,] field = new char[fieldSize, fieldSize];
            int startRow = 0;
            int startCol = 0;
            int coalsCount = 0;

            ReadTheField(field, ref startRow, ref startCol, ref coalsCount);

            int collectedCoals = 0;
            bool isGameOver = false;

            foreach (string cmd in cmdToMove)
            {
                MakeAMove(field, cmd, ref startRow, ref startCol, ref collectedCoals, ref isGameOver);

                if (isGameOver)
                {
                    return;
                }

                if (collectedCoals == coalsCount)
                {
                    Console.WriteLine($"You collected all coals! ({startRow}, {startCol})");
                    return;
                }
            }

            Console.WriteLine($"{coalsCount - collectedCoals} coals left. ({startRow}, {startCol})");
        }

        static void ReadTheField(char[,] field, ref int startRow, ref int startCol, ref int coalsCount)
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                string[] currRowValues = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < field.GetLength(1); col++)
                {
                    field[row, col] = char.Parse(currRowValues[col]);

                    if (field[row, col] == 's')
                    {
                        startRow = row;
                        startCol = col;
                    }
                    else if (field[row, col] == 'c')
                    {
                        coalsCount++;
                    }
                }
            }
        }

        static void MakeAMove(char[,] field, string cmd, ref int startRow, ref int startCol, ref int collectedCoals,ref bool isGameOver)
        {
            field[startRow, startCol] = '*';

            if (cmd == "up" && startRow - 1 >= 0)
            {
                startRow--; 
            }
            else if (cmd == "left" && startCol - 1 >= 0)
            {
                startCol--;
            }
            else if (cmd == "right" && startCol + 1 < field.GetLength(1))
            {
                startCol++;
            }
            else if (cmd == "down" && startRow + 1 < field.GetLength(0))
            {
                startRow++;
            }

            if (field[startRow, startCol] == 'e')
            {
                Console.WriteLine($"Game over! ({startRow}, {startCol})");
                isGameOver = true;
                return;
            }
            else if (field[startRow, startCol] == 'c')
            {
                collectedCoals++;
            }

            field[startRow, startCol] = 's';
        }
    }
}
