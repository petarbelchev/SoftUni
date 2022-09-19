using System;

namespace T04.SumOfIntegers
{
    class Program
    {
        static void Main()
        {
            string[] inputs = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            int intSum = 0;

            foreach (var input in inputs)
            {
                try
                {
                    int num = int.Parse(input);
                    intSum += num;
                }
                catch (FormatException)
                {
                    Console.WriteLine($"The element '{input}' is in wrong format!");
                }
                catch (OverflowException)
                {
                    Console.WriteLine($"The element '{input}' is out of range!");
                }
                finally
                {
                    Console.WriteLine($"Element '{input}' processed - current sum: {intSum}");
                }
            }

            Console.WriteLine($"The total sum of all integers is: {intSum}");
        }
    }
}
