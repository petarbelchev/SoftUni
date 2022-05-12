using System;

namespace _06._Tournament_of_Christmas
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int daysWinner = 0;
            int daysLoser = 0;
            double totalMoney = 0;

            for (int currentDay = 1; currentDay <= days; currentDay++)
            {
                int currentDayWins = 0;
                int currentDayLoses = 0;
                int currentDayMoney = 0;

                while (true)
                {
                    string sport = Console.ReadLine();

                    if (sport == "Finish")
                    {
                        break;
                    }

                    string winOrLose = Console.ReadLine();

                    if (winOrLose == "win")
                    {
                        currentDayMoney += 20;
                        currentDayWins++;
                    }
                    else
                    {
                        currentDayLoses++;
                    }

                }

                if (currentDayWins >= currentDayLoses)
                {
                    currentDayMoney += currentDayMoney / 10;
                    daysWinner++;
                }
                else
                {
                    daysLoser++;
                }

                totalMoney += currentDayMoney;
            }

            if (daysWinner >= daysLoser)
            {
                totalMoney += totalMoney * 0.2;
                Console.WriteLine($"You won the tournament! Total raised money: {totalMoney:f2}");
            }
            else
            {
                Console.WriteLine($"You lost the tournament! Total raised money: {totalMoney:f2}");
            }
        }
    }
}
