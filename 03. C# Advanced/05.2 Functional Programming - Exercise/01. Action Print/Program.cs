using System;
class Program
{
    static void Main()
    {
        string[] names = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

        Action<string> printFormat = dataForPrint => Console.WriteLine(dataForPrint);

        Array.ForEach(names, printFormat);
    }
}
