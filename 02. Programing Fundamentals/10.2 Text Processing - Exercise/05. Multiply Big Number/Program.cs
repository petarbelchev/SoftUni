using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Multiply_Big_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Select(ch => int.Parse(ch.ToString()))
                .ToList();

            int multiplier = int.Parse(Console.ReadLine());

            if (multiplier != 0)
            {
                int additionalDigit = 0;

                for (int i = numbers.Count - 1; i >= 0; i--)
                {
                    numbers[i] = (numbers[i] * multiplier) + additionalDigit;

                    additionalDigit = 0;

                    if (numbers[i] > 9)
                    {
                        additionalDigit = numbers[i] / 10;
                        numbers[i] %= 10;
                    }
                }

                if (additionalDigit != 0)
                {
                    numbers.Insert(0, additionalDigit);
                }

                Console.WriteLine(string.Join("", numbers));
            }
            else
            {
                Console.Write(multiplier);
            }
        }
    }
}
