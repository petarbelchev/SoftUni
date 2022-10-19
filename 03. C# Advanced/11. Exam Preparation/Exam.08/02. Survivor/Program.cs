using System;

namespace _02._Survivor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numOfRows = int.Parse(Console.ReadLine());
            char[][] beach = new char[numOfRows][];

            for (int row = 0; row < numOfRows; row++)
            {
                beach[row] = string.Join("", Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries))
                    .ToCharArray();
            }

            int collectedTokens = 0;
            int opponentsTokens = 0;

            while (true)
            {
                string cmd = Console.ReadLine();

                if (cmd == "Gong")
                    break;

                string[] cmdArgs = cmd
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                int row = int.Parse(cmdArgs[1]);
                int col = int.Parse(cmdArgs[2]);

                if (row < 0 || row >= numOfRows ||
                    col < 0 || col >= beach[row].Length)
                    continue;

                if (cmdArgs[0] == "Find")
                {
                    if (beach[row][col] == 'T')
                    {
                        collectedTokens++;
                        beach[row][col] = '-';
                    }
                }
                else if (cmdArgs[0] == "Opponent")
                {
                    if (beach[row][col] == 'T')
                    {
                        opponentsTokens++;
                        beach[row][col] = '-';
                    }

                    string direction = cmdArgs[3];

                    if (direction == "up")
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            if (row - 1 >= 0 && col < beach[row - 1].Length)
                            {
                                row--;

                                if (beach[row][col] == 'T')
                                    opponentsTokens++;

                                beach[row][col] = '-';
                            }
                        }
                    }
                    else if (direction == "down")
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            if (row + 1 < numOfRows && col < beach[row + 1].Length)
                            {
                                row++;

                                if (beach[row][col] == 'T')
                                    opponentsTokens++;

                                beach[row][col] = '-';
                            }
                        }
                    }
                    else if (direction == "left")
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            if (col - 1 >= 0)
                            {
                                col--;

                                if (beach[row][col] == 'T')
                                    opponentsTokens++;

                                beach[row][col] = '-';
                            }
                        }
                    }
                    else if (direction == "right")
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            if (col + 1 < beach[row].Length)
                            {
                                col++;

                                if (beach[row][col] == 'T')
                                    opponentsTokens++;

                                beach[row][col] = '-';
                            }
                        }
                    }
                }
            }

            for (int row = 0; row < numOfRows; row++)
                Console.WriteLine(string.Join(" ", beach[row]));

            Console.WriteLine($"Collected tokens: {collectedTokens}");
            Console.WriteLine($"Opponent's tokens: {opponentsTokens}");
        }
    }
}
