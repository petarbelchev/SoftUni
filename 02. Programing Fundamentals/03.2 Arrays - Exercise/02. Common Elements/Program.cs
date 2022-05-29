using System;

namespace _02._Common_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] firstArray = Console.ReadLine().Split();
            string[] secondArray = Console.ReadLine().Split();

            foreach (string itemSecondArray in secondArray)
            {
                foreach (string itemFirstArray in firstArray)
                {
                    if (itemSecondArray == itemFirstArray)
                    {
                        Console.Write($"{itemSecondArray} ");
                    }
                }
            }
        }
    }
}
