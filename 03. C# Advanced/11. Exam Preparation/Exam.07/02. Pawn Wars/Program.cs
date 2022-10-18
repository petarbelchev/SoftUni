using System;
using System.Collections.Generic;

namespace _02._Pawn_Wars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = 8;
            var fieldRows = new Dictionary<int, int>() { { 0, 8 }, { 1, 7 }, { 2, 6 }, { 3, 5 }, { 4, 4 }, { 5, 3 }, { 6, 2 }, { 7, 1 } };
            var fieldCols = new Dictionary<int, char>() { { 0, 'a' }, { 1, 'b' }, { 2, 'c' }, { 3, 'd' }, { 4, 'e' }, { 5, 'f' }, { 6, 'g' }, { 7, 'h' } };

            var field = new char[fieldSize, fieldSize];

            int wStartRow = -1;
            int wStartCol = -1;
            int bStartRow = -1;
            int bStartCol = -1;

            for (int row = 0; row < fieldSize; row++)
            {
                char[] rowData = Console.ReadLine().ToCharArray();

                for (int col = 0; col < fieldSize; col++)
                {
                    field[row, col] = rowData[col];

                    if (rowData[col] == 'w')
                    {
                        wStartRow = row;
                        wStartCol = col;
                    }
                    else if (rowData[col] == 'b')
                    {
                        bStartRow = row;
                        bStartCol = col;
                    }
                }
            }

            while (true)
            {
                //white moves
                if ((bStartRow == wStartRow - 1) &&
                    (bStartCol == wStartCol - 1 || bStartCol == wStartCol + 1))
                {
                    wStartRow--;

                    if (bStartCol == wStartCol - 1)
                        wStartCol--;
                    else if (bStartCol == wStartCol + 1)
                        wStartCol++;

                    Console.WriteLine($"Game over! White capture on {fieldCols[wStartCol]}{fieldRows[wStartRow]}.");
                    break;
                }
                else
                {
                    wStartRow--;

                    if (wStartRow == 0)
                    {
                        Console.WriteLine($"Game over! White pawn is promoted to a queen at {fieldCols[wStartCol]}{fieldRows[wStartRow]}.");
                        break;
                    }
                }


                //black moves
                if ((wStartRow == bStartRow + 1) &&
                    (wStartCol == bStartCol - 1 || wStartCol == bStartCol + 1))
                {
                    bStartRow++;

                    if (wStartCol == bStartCol - 1)
                        bStartCol--;
                    else if (wStartCol == bStartCol + 1)
                        bStartCol++;

                    Console.WriteLine($"Game over! Black capture on {fieldCols[bStartCol]}{fieldRows[bStartRow]}.");
                    break;
                }
                else
                {
                    bStartRow++;
                    
                    if (bStartRow == fieldSize - 1)
                    {
                        Console.WriteLine($"Game over! Black pawn is promoted to a queen at {fieldCols[bStartCol]}{fieldRows[bStartRow]}.");
                        break;
                    }
                }
            }
        }
    }
}
