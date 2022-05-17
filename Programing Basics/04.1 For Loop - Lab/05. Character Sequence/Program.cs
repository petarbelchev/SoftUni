using System;

namespace _05._Character_Sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int lengthText = text.Length;
            for (int i = 0; i < lengthText; i++)
            {
                Console.WriteLine(text[i]);
            }
        }
    }
}
