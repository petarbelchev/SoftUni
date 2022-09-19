using System;
using System.Collections.Generic;
using System.Linq;

namespace T02.EnterNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            int currNum = 1;

            while (numbers.Count < 10)
            {
                try
                {
                    currNum = ReadNumber(currNum, 100);

                    numbers.Add(currNum);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid Number!");
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine($"Your number is not in range {currNum} - 100!");
                }
            }

            Console.WriteLine(String.Join(", ", numbers));
        }

        static int ReadNumber(int start, int end)
        {
            int number = int.Parse(Console.ReadLine());

            if (number <= start || number >= end)
            {
                throw new ArgumentOutOfRangeException();
            }

            return number;
        }
    }
}
