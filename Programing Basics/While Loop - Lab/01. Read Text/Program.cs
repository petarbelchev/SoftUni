using System;

namespace _01._Read_Text
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = null;

            while (name != "Stop")
            {
                name = Console.ReadLine();
                if (name != "Stop")
                {
                    Console.WriteLine(name);
                }
            }
        }
    }
}
