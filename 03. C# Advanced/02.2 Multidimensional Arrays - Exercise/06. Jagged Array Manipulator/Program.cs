using System;
using System.Linq;

namespace _6._JagArrManipu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numOfRows = int.Parse(Console.ReadLine());
            int[][] jagArr = new int[numOfRows][];
            for (int row = 0; row < numOfRows; row++)
            {
                int[] currRowValues = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                jagArr[row] = currRowValues;
            }
            for (int row = 0; row < jagArr.GetLength(0) - 1; row++)
            {
                if (jagArr[row].Length == jagArr[row + 1].Length)
                {
                    for (int currRow = row; currRow <= row + 1; currRow++)
                    {
                        for (int col = 0; col < jagArr[currRow].Length; col++)
                        {
                            jagArr[currRow][col] *= 2;
                        }
                    }
                }
                else
                {
                    for (int currRow = row; currRow <= row + 1; currRow++)
                    {
                        for (int col = 0; col < jagArr[currRow].Length; col++)
                        {
                            jagArr[currRow][col] /= 2;
                        }
                    }
                }                
            }
            string cmd = Console.ReadLine();
            while (cmd != "End")
            {
                string[] cmdArgs = cmd
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                int row = int.Parse(cmdArgs[1]);
                int col = int.Parse(cmdArgs[2]);
                int value = int.Parse(cmdArgs[3]);
                if (row >= 0 && row < jagArr.GetLength(0)
                    && col >= 0 && col < jagArr[row].Length)
                {
                    if (cmdArgs[0] == "Add")
                    {
                        jagArr[row][col] += value;
                    }
                    else if (cmdArgs[0] == "Subtract")
                    {
                        jagArr[row][col] -= value;
                    }
                }
                cmd = Console.ReadLine();
            }
            foreach (int[] row in jagArr)
            {
                Console.WriteLine(string.Join(' ', row));
            }
        }
    }
}
