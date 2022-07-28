using System;

class Program
{
    static void Main()
    {
        string[] names = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

        Action<string> printFormat = dataForPrint => Console.WriteLine($"Sir {dataForPrint}");

        Array.ForEach(names, printFormat);
    }
}
