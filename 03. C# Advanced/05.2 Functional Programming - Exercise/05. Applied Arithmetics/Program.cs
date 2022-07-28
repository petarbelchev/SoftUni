using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] nums = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        string cmd;

        while ((cmd = Console.ReadLine()) != "end")
        {
            if (cmd == "add")
            {
                DoArithmetic add = nums => nums.Select(num => num += 1).ToArray();
                nums = add(nums);
            }
            else if (cmd == "multiply")
            {
                DoArithmetic multiply = nums => nums.Select(num => num *= 2).ToArray();
                nums = multiply(nums);
            }
            else if (cmd == "subtract")
            {
                DoArithmetic subtract = nums => nums.Select(num => num -= 1).ToArray();
                nums = subtract(nums);
            }
            else if (cmd == "print")
            {
                Console.WriteLine(string.Join(' ', nums));
            }
        }
    }
    private delegate int[] DoArithmetic(int[] nums);
}
