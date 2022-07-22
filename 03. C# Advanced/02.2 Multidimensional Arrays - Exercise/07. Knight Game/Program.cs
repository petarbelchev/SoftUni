using System;

namespace _7._Knight_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] table = new char[n, n];

            for (int row = 0; row < table.GetLength(0); row++)
            {
                char[] rowChars = Console.ReadLine().ToCharArray();
                for (int col = 0; col < table.GetLength(1); col++)
                {
                    table[row, col] = rowChars[col];
                }
            }
            int removedCounter = 0;
            int hitCounter = 0;
            int rowForRemove = 0;
            int colForRemove = 0;
            bool isNeededARemove = true;

            while (isNeededARemove)
            {
                isNeededARemove = false;

                for (int row = 0; row < table.GetLength(0); row++)
                {
                    for (int col = 0; col < table.GetLength(1); col++)
                    {
                        if (table[row, col] == '0')
                        {
                            continue;
                        }
                        int currHitCounter = 0;

                        for (int currRow = row - 2; currRow <= row + 2; currRow++)
                        {
                            if (currRow == row || currRow < 0 || currRow >= table.GetLength(0))
                            {
                                continue;
                            }
                            else if (currRow == row - 2 || currRow == row + 2)
                            {
                                for (int currCol = col - 1; currCol <= col + 1; currCol += 2)
                                {
                                    if (currCol < 0 || currCol >= table.GetLength(1))
                                    {
                                        continue;
                                    }
                                    if (table[currRow, currCol] == 'K')
                                    {
                                        currHitCounter++;
                                    }
                                }
                            }
                            else if (currRow == row - 1 || currRow == row + 1)
                            {
                                for (int currCol = col - 2; currCol <= col + 2; currCol += 4)
                                {
                                    if (currCol < 0 || currCol >= table.GetLength(1))
                                    {
                                        continue;
                                    }
                                    if (table[currRow, currCol] == 'K')
                                    {
                                        currHitCounter++;
                                    }
                                }
                            }
                        }
                        if (currHitCounter > hitCounter)
                        {
                            hitCounter = currHitCounter;
                            rowForRemove = row;
                            colForRemove = col;
                            isNeededARemove = true;
                        }
                        currHitCounter = 0;
                    }
                }
                if (isNeededARemove)
                {
                    table[rowForRemove, colForRemove] = '0';
                    removedCounter++;
                    hitCounter = 0;
                }
            }
            Console.WriteLine(removedCounter);
        }
    }
}
