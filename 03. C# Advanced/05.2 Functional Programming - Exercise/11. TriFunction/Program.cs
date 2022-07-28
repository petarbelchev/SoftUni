using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int sumChars = int.Parse(Console.ReadLine());

        string[] names = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

        //Func<string, int, bool> checker = (name, neededSum)  =>
        //{
        //    int sumChars = 0;
        //    foreach (char ch in name)
        //    {
        //        sumChars += ch;
        //    }

        //    if(sumChars >= neededSum)
        //        return true;
        //    else
        //        return false;
        //};

        //Console.WriteLine(names.Where(name => checker(name, sumChars)).First());

        Console.WriteLine(names.First(name => name.Select(ch => (int)ch).Sum() >= sumChars));
    }
}
