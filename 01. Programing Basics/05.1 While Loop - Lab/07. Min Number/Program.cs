using System;

namespace _07._Min_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int smallerNum = int.MaxValue;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Stop")
                {
                    break;
                }

                int number = int.Parse(input);

                if (number < smallerNum)
                {
                    smallerNum = number;
                }

            }

            Console.WriteLine($"{smallerNum}");
        }
    }
}
