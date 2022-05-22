using System;

namespace _05._Game_Of_Intervals
{
    class Program
    {
        static void Main(string[] args)
        {
            double movesQuantity = double.Parse(Console.ReadLine());
            double totalPoints = 0;
            int counter09 = 0;
            int counter1019 = 0;
            int counter2029 = 0;
            int counter3039 = 0;
            int counter4050 = 0;
            int invalidNum = 0;


            for (int i = 1; i <= movesQuantity; i++)
            {
                double inputMoves = int.Parse(Console.ReadLine());

                if (inputMoves >= 0 && inputMoves <= 9)
                {
                    totalPoints += inputMoves * 0.2;
                    counter09++;
                }
                else if (inputMoves >= 10 && inputMoves <= 19)
                {
                    totalPoints += inputMoves * 0.3;
                    counter1019++;
                }
                else if (inputMoves >= 20 && inputMoves <= 29)
                {
                    totalPoints += inputMoves * 0.4;
                    counter2029++;
                }
                else if (inputMoves >= 30 && inputMoves <= 39)
                {
                    totalPoints += 50;
                    counter3039++;
                }
                else if (inputMoves >= 40 && inputMoves <= 50)
                {
                    totalPoints += 100;
                    counter4050++;
                }
                else
                {
                    totalPoints /= 2;
                    invalidNum++;

                }
            }

            Console.WriteLine($"{totalPoints:f2}");
            Console.WriteLine($"From 0 to 9: {(counter09 / movesQuantity) * 100.0:f2}%");
            Console.WriteLine($"From 10 to 19: {(counter1019 / movesQuantity) * 100.0:f2}%");
            Console.WriteLine($"From 20 to 29: {(counter2029 / movesQuantity) * 100.0:f2}%");
            Console.WriteLine($"From 30 to 39: {(counter3039 / movesQuantity) * 100.0:f2}%");
            Console.WriteLine($"From 40 to 50: {(counter4050 / movesQuantity) * 100.0:f2}%");
            Console.WriteLine($"Invalid numbers: {(invalidNum / movesQuantity) * 100.0:f2}%");

        }
    }
}
