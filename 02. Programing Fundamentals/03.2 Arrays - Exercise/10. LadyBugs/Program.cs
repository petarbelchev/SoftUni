using System;
using System.Linq;

namespace _10._LadyBugs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            int[] field = new int[fieldSize];
            int[] initialIndexes = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            foreach (int index in initialIndexes)
            {
                if (index >= 0 && index < fieldSize)
                {
                    field[index] = 1;
                }
            }
            string input = Console.ReadLine();
            while (input != "end")
            {
                string[] command = input.Split();
                int position = int.Parse(command[0]);
                if (position >= 0 && position < fieldSize)
                {
                    if (field[position] == 1)
                    {
                        field[position] = 0;
                        string direction = command[1];
                        int flyLenght = int.Parse(command[2]);
                        if (direction == "left")
                        {
                            while (position - flyLenght >= 0 && position - flyLenght < fieldSize)
                            {
                                if (field[position - flyLenght] == 0)
                                {
                                    field[position - flyLenght] = 1;
                                    break;
                                }
                                else
                                {
                                    flyLenght += flyLenght;
                                }
                            }
                        }
                        else if (direction == "right")
                        {
                            while (position + flyLenght >= 0 && position + flyLenght < fieldSize)
                            {
                                if (field[position + flyLenght] == 0)
                                {
                                    field[position + flyLenght] = 1;
                                    break;
                                }
                                else
                                {
                                    flyLenght += flyLenght;
                                }
                            }
                        }
                    }
                }
                input = Console.ReadLine();
            }
            foreach (int index in field)
            {
                Console.Write($"{index} ");
            }
        }
    }
}
