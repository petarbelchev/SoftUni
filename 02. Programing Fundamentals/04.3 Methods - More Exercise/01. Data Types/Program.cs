using System;

namespace _01._Data_Types
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();

            switch (type)
            {
                case "int":
                    int number = int.Parse(Console.ReadLine());
                    Print(number);
                    break;

                case "real":
                    double realNumber = double.Parse(Console.ReadLine());
                    Print(realNumber);
                    break;

                case "string":
                    string input = Console.ReadLine();
                    Print(input);
                    break;
            }

            
        }

        static void Print(int input)
        {
            Console.WriteLine(input * 2);
        }

        static void Print(double input)
        {
            Console.WriteLine($"{input * 1.5:f2}");
        }

        static void Print(string input)
        {
            Console.WriteLine($"${input}$");
        }
    }
}
