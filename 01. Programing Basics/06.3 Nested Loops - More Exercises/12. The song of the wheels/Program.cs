using System;

namespace _12._The_song_of_the_wheels
{
    class Program
    {
        static void Main(string[] args)
        {
            int m = int.Parse(Console.ReadLine());
            int counterPasswords = 0;
            string fourthPassword = "";

            for (int a = 1; a <= 9; a++)
            {
                for (int b = 1; b <= 9; b++)
                {
                    for (int c = 1; c <= 9; c++)
                    {
                        for (int d = 1; d <= 9; d++)
                        {
                            if (((a*b) + (c*d) == m) && (a < b && c > d))
                            {
                                Console.Write($"{a}{b}{c}{d} ");
                                counterPasswords++;

                                if (counterPasswords == 4)
                                {
                                    fourthPassword = ($"{a}{b}{c}{d}");
                                }
                            }
                        }
                    }
                }
            }

            if (counterPasswords >= 4)
            {
                Console.WriteLine();
                Console.WriteLine($"Password: {fourthPassword}");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("No!");
            }
        }
    }
}
