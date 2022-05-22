using System;

namespace _05._Challenge_the_Wedding
{
    class Program
    {
        static void Main(string[] args)
        {
            int mans = int.Parse(Console.ReadLine());
            int womans = int.Parse(Console.ReadLine());
            int tables = int.Parse(Console.ReadLine());
            bool isTablesOver = false;

            for (int currentMan = 1; currentMan <= mans; currentMan++)
            {
                for (int currentWoman = 1; currentWoman <= womans; currentWoman++)
                {
                    Console.Write($"({currentMan} <-> {currentWoman}) ");
                    tables--;

                    if (tables == 0)
                    {
                        isTablesOver = true;
                        break;
                    }
                }

                if (isTablesOver)
                {
                    break;
                }
            }
        }
    }
}
