using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

        Console.WriteLine(Sum(nums));
    }

    static int Sum(int[] array, int index = 0)
    {
        if (index == array.Length - 1)
        {
            return array[index];
        }

        return array[index] + Sum(array, index + 1);
    }
}
