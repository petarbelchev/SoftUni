using System;
using System.Linq;

namespace _02._ArrayModif
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] cmdArgs = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string mainCmd = cmdArgs[0];

                if (mainCmd == "swap")
                {
                    numbers = Swap(numbers, cmdArgs);
                }
                else if (mainCmd == "multiply")
                {
                    numbers = Multiply(numbers, cmdArgs);
                }
                else if (mainCmd == "decrease")
                {
                    numbers = Decrese(numbers);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", numbers));
        }

        private static int[] Decrese(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i]--;
            }

            return numbers;
        }

        private static int[] Multiply(int[] numbers, string[] cmdArgs)
        {
            int index1 = int.Parse(cmdArgs[1]);
            int index2 = int.Parse(cmdArgs[2]);

            numbers[index1] = numbers[index1] * numbers[index2];
            return numbers;
        }

        private static int[] Swap(int[] numbers, string[] cmdArgs)
        {
            int index1 = int.Parse(cmdArgs[1]);
            int index2 = int.Parse(cmdArgs[2]);

            int firstElement = numbers[index1];
            numbers[index1] = numbers[index2];
            numbers[index2] = firstElement;

            return numbers;
        }
    }
}
