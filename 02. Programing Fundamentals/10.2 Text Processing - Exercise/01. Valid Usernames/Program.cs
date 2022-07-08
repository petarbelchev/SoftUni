using System;
using System.Linq;

namespace _01._Valid_Usernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            foreach (string name in names)
            {
                if (name.Length >= 3 
                    && name.Length <= 16 
                    && !name.Any(ch => char.IsLetterOrDigit(ch) == false && ch != '-' && ch != '_'))
                {
                    Console.WriteLine(name);
                }
            }
        }
    }
}
