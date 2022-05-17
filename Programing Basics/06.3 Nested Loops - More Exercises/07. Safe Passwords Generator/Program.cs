using System;

namespace _07._Safe_Passwords_Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int maxPasswords = int.Parse(Console.ReadLine());
            int passwordsCounter = 0;
            char letter1 = '#';
            char letter2 = '@';
            bool isMaxPass = false;

            for (int x = 1; x <= a; x++)
            {
                for (int y = 1; y <= b; y++)
                {
                    Console.Write($"{letter1}{letter2}{x}{y}{letter2}{letter1}|");

                    passwordsCounter++;
                    letter1++;
                    letter2++;

                    if (letter1 > 55)
                    {
                        letter1 = '#';
                    }

                    if (letter2 > 96)
                    {
                        letter2 = '@';
                    }

                    if (passwordsCounter == maxPasswords)
                    {
                        isMaxPass = true;
                        break;
                    }
                }

                if (isMaxPass)
                {
                    break;
                }
            }
        }
    }
}
