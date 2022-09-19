using System;
using System.Linq;

namespace T05.PlayCatch
{
    class Program
    {
        static void Main()
        {
            int[] intArr = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int exCount = 0;

            while (exCount < 3)
            {
                string[] cmdArs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    switch (cmdArs[0])
                    {
                        case "Replace": Replace(intArr, int.Parse(cmdArs[1]), int.Parse(cmdArs[2])); break;
                        case "Print": Print(intArr, int.Parse(cmdArs[1]), int.Parse(cmdArs[2])); break;
                        case "Show": Show(intArr, int.Parse(cmdArs[1])); break;
                    }
                }
                catch (FormatException)
                {
                    exCount++;
                    Console.WriteLine("The variable is not in the correct format!");
                }
                catch (ArgumentOutOfRangeException)
                {
                    exCount++;
                    Console.WriteLine("The index does not exist!");
                }
            }

            Console.WriteLine(string.Join(", ", intArr));
        }

        static void Replace(int[] intArr, int index, int element)
        {
            if (index < 0 || index >= intArr.Length)
            {
                throw new ArgumentOutOfRangeException();
            }

            intArr[index] = element;
        }

        static void Print(int[] intArr, int startIndex, int endIndex)
        {
            if (startIndex < 0 || 
                startIndex >= intArr.Length || 
                endIndex < 0 || 
                endIndex >= intArr.Length)
            {
                throw new ArgumentOutOfRangeException();
            }

            int[] elForPrint = intArr.Skip(startIndex).Take(endIndex - startIndex + 1).ToArray();

            Console.WriteLine(string.Join(", ", elForPrint));
        }

        static void Show(int[] intArr, int index)
        {
            if (index < 0 || index >= intArr.Length)
            {
                throw new ArgumentOutOfRangeException();
            }

            Console.WriteLine(intArr[index]);
        }
    }
}
