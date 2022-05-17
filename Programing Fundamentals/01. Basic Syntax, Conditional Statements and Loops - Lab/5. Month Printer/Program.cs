using System;

namespace _5._Month_Printer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int inputNum = int.Parse(Console.ReadLine());

            if (inputNum == 1)
            {
                Console.WriteLine("January");
            }
            else if (inputNum == 2)
            {
                Console.WriteLine("February");
            }
            else if (inputNum == 3)
            {
                Console.WriteLine("March");
            }
            else if (inputNum == 4)
            {
                Console.WriteLine("April");
            }
            else if (inputNum == 5)
            {
                Console.WriteLine("May");
            }
            else if (inputNum == 6)
            {
                Console.WriteLine("June");
            }
            else if (inputNum == 7)
            {
                Console.WriteLine("July");
            }
            else if (inputNum == 8)
            {
                Console.WriteLine("August");
            }
            else if (inputNum == 9)
            {
                Console.WriteLine("September");
            }
            else if (inputNum == 10)
            {
                Console.WriteLine("October");
            }
            else if (inputNum == 11)
            {
                Console.WriteLine("November");
            }
            else if (inputNum == 12)
            {
                Console.WriteLine("December");
            }
            else
            {
                Console.WriteLine("Error!");
            }
        }
    }
}
