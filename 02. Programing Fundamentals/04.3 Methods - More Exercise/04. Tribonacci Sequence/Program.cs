using System;

namespace _04._Tribonacci_Sequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(" ", TribonacciSequence(int.Parse(Console.ReadLine()))));
        }

        static int[] TribonacciSequence(int length)
        {
            int[] sequence = new int[length];

            sequence[0] = 1;

            if (length < 2)
            {
                return sequence;
            }

            sequence[1] = 1;

            if (length < 3)
            {
                return sequence;
            }

            sequence[2] = 2;

            for (int i = 3; i < length; i++)
            {
                sequence[i] = sequence[i - 1] + sequence[i - 2] + sequence[i - 3];
            }

            return sequence;
        }
    }
}
