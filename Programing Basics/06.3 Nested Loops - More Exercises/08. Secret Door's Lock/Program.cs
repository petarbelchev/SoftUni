using System;

namespace _08._Secret_Door_s_Lock
{
    class Program
    {
        static void Main(string[] args)
        {
            int fMax = int.Parse(Console.ReadLine());
            int sMax = int.Parse(Console.ReadLine());
            int tMax = int.Parse(Console.ReadLine());

            for (int first = 1; first <= fMax; first++)
            {
                if (first % 2 == 0)
                {
                    for (int second = 1; second <= sMax; second++)
                    {
                        bool isPrime = true;

                        for (int divider = 2; divider < second; divider++)
                        {
                            if (second % divider == 0)
                            {
                                isPrime = false;
                            }
                        }

                        if (isPrime && second >= 2 && second <= 7)
                        {
                            for (int third = 1; third <= tMax; third++)
                            {
                                if (third % 2 == 0)
                                {
                                    Console.WriteLine($"{first} {second} {third}");
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
