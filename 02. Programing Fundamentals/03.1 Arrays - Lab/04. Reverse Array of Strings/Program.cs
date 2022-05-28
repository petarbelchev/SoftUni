using System;
using System.Linq;

namespace _04._Reverse_Array_of_Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] arrayOfChars = Console.ReadLine().Split().ToArray();

            Array.Reverse(arrayOfChars);
            
            foreach (string currChar in arrayOfChars)
            {
                Console.Write($"{currChar} ");
            }
        }
    }
}
