using System;

namespace _05._Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int magicCounter = 0;

            for (int i = 1111; i <= 9999; i++)
            {
                string currentNum = i.ToString();

                for (int j = 0; j < currentNum.Length; j++)
                {
                    int currentDiget = int.Parse(currentNum[j].ToString());

                    if (currentDiget != 0 && n % currentDiget == 0)
                    {
                        magicCounter++;
                    }
                }

                if (magicCounter == 4)
                {
                    Console.Write(i + " ");
                }

                magicCounter = 0;
            }
        }
    }
}
