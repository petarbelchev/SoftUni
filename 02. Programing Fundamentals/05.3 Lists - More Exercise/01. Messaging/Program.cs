using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01._Messaging
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<char> words = Console.ReadLine().ToList();

            StringBuilder output = new StringBuilder();

            for (int i = 0; i < numbers.Count; i++)
            {
                int element = numbers.ElementAt(i);

                int sumElement = 0;

                while (element != 0)
                {
                    sumElement += element % 10;
                    element /= 10;
                }

                int textLength = words.Count;

                int index = sumElement - ((sumElement / textLength) * textLength);


                output.Append(words.ElementAt(index));

                words.RemoveAt(index);
            }

            Console.WriteLine(output);
        }
    }
}
