using System;

namespace _05._Messages
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = string.Empty;
            int numCount = int.Parse(Console.ReadLine());

            for (int currNum = 1; currNum <= numCount; currNum++)
            {
                string inputNum = Console.ReadLine();

                if (inputNum != "0")
                {
                    int digitCount = inputNum.Length;

                    int mainDigit = int.Parse(inputNum[0].ToString());

                    int offsetOfNum = (mainDigit - 2) * 3;

                    if (mainDigit == 8 || mainDigit == 9)
                    {
                        offsetOfNum += 1;
                    }

                    int letterIndex = 97 + (offsetOfNum + digitCount - 1);

                    char letter = (char)letterIndex;

                    text += letter;
                }
                else
                {
                    text += " ";
                }
            }

            Console.WriteLine(text);
        }
    }
}
