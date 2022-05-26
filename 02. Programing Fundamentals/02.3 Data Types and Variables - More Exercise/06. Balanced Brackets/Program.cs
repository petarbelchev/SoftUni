using System;

namespace _06._Balanced_Brackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int inputCount = int.Parse(Console.ReadLine());
            int bracketsCounter = 0;
            bool isBalanced = true;

            for (int numInput = 1; numInput <= inputCount; numInput++)
            {
                string input = Console.ReadLine();

                if (input == "(")
                {
                    bracketsCounter++;
                }
                else if (input == ")")
                {
                    bracketsCounter--;
                }

                if ((bracketsCounter < 0 || bracketsCounter > 1) && isBalanced == true)
                {
                    isBalanced = false;
                }
            }

            if (bracketsCounter != 0)
            {
                isBalanced = false;
            }

            if (isBalanced)
            {
                Console.WriteLine("BALANCED");
            }
            else
            {
                Console.WriteLine("UNBALANCED");
            }
        }
    }
}
