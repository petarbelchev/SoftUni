using System;

namespace _03._Histogram
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int p1 = 0;
            int p2 = 0;
            int p3 = 0;
            int p4 = 0;
            int p5 = 0;

            for (int i = 1; i <= n; i += 1)
            {
                int numbers = int.Parse(Console.ReadLine());
                if (numbers < 200)
                {
                    p1 += 1;
                }
                else if (numbers >= 200 && numbers <= 399)
                {
                    p2 += 1;
                }
                else if (numbers >= 400 && numbers <= 599)
                {
                    p3 += 1;
                }
                else if (numbers >= 600 && numbers <= 799)
                {
                    p4 += 1;
                }
                else if (numbers >= 800)
                {
                    p5 += 1;
                }
            }

            Console.WriteLine($"{(p1 / (double)n) * 100:f2}%");
            Console.WriteLine($"{(p2 / (double)n) * 100:f2}%");
            Console.WriteLine($"{(p3 / (double)n) * 100:f2}%");
            Console.WriteLine($"{(p4 / (double)n) * 100:f2}%");
            Console.WriteLine($"{(p5 / (double)n) * 100:f2}%");
        }
    }
}
