using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Snake_Moves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] rowsCols = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            char[,] stairs = new char[rowsCols[0], rowsCols[1]];

            Queue<char> snake = new Queue<char>(Console.ReadLine().ToCharArray());

            for (int row = 0; row < stairs.GetLength(0); row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < stairs.GetLength(1); col++)
                    {
                        stairs[row, col] = snake.Peek();
                        snake.Enqueue(snake.Dequeue());
                    }
                }
                else
                {
                    for (int col = stairs.GetLength(1) - 1; col >= 0; col--)
                    {
                        stairs[row, col] = snake.Peek();
                        snake.Enqueue(snake.Dequeue());
                    }
                }
            }

            for (int row = 0; row < stairs.GetLength(0); row++)
            {
                for (int col = 0; col < stairs.GetLength(1); col++)
                {
                    Console.Write(stairs[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
