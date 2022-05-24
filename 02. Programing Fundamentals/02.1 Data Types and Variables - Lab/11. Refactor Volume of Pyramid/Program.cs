using System;

namespace _11._Refactor_Volume_of_Pyramid
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal length, width, height = 0;
            Console.Write("Length: ");
            length = decimal.Parse(Console.ReadLine());
            Console.Write("Width: ");
            width = decimal.Parse(Console.ReadLine());
            Console.Write("Height: ");
            height = decimal.Parse(Console.ReadLine());
            decimal volume = (length * width * height) / 3;
            Console.Write($"Pyramid Volume: {volume:f2}");

        }
    }
}
