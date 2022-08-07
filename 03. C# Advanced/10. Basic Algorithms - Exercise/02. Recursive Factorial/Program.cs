using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int result = GetFactorial(n);

        Console.WriteLine(result);
    }

    private static int GetFactorial(int n)
    {
        if (n == 1)
        {
            return n;
        }

        return n * GetFactorial(n - 1);
    }
}