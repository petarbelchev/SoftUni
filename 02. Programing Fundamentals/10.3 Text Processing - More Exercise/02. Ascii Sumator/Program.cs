using System;
using System.Linq;

namespace _02._Ascii_Sumator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char firstChar = char.Parse(Console.ReadLine());
            char secondChar = char.Parse(Console.ReadLine());
            string stringInput = Console.ReadLine();
            int sum = 0;

            foreach (char ch in stringInput)
            {
                if (ch > firstChar && ch < secondChar)
                {
                    sum += ch;
                }
            }

            Console.WriteLine(sum);
        }
    }
}
