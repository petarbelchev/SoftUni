using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Bomb_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int[] bombAndPower = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int specialNum = bombAndPower[0];
            int power = bombAndPower[1];

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] == specialNum)
                {
                    int startIndex = i - power;
                    if (startIndex < 0)
                    {
                        startIndex = 0;
                    }

                    int endIndex = i + power;
                    if (endIndex > numbers.Count - 1)
                    {
                        endIndex = numbers.Count - 1;
                    }

                    for (int j = startIndex; j <= endIndex; j++)
                    {
                        numbers.Remove(numbers[startIndex]);
                    }

                    i = -1;
                }
            }

            Console.WriteLine(numbers.Sum());
        }
    }
}
