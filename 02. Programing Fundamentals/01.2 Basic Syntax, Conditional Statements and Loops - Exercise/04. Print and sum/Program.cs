using System;

namespace _04._Print_and_sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int startSequence = int.Parse(Console.ReadLine());
            int endSequence = int.Parse(Console.ReadLine());
            int sumSequenceOfNumbers = 0;

            for (int i = startSequence; i <= endSequence; i++)
            {
                Console.Write(i + " ");
                sumSequenceOfNumbers += i;
            }

            Console.WriteLine();
            Console.WriteLine($"Sum: {sumSequenceOfNumbers}");
        }
    }
}
