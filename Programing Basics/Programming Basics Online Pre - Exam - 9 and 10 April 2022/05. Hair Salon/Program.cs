using System;

namespace _05._Hair_Salon
{
    class Program
    {
        static void Main(string[] args)
        {
            int dayIncomeGoal = int.Parse(Console.ReadLine());
            int income = 0;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "closed")
                {
                    break;
                }

                string haircutOrColor = input;

                if (haircutOrColor == "haircut")
                {
                    string typeHaircut = Console.ReadLine();

                    switch (typeHaircut)
                    {
                        case "mens":
                            income += 15;
                            break;

                        case "ladies":
                            income += 20;
                            break;

                        case "kids":
                            income += 10;
                            break;
                    }
                }
                else if (haircutOrColor == "color")
                {
                    string typeColor = Console.ReadLine();

                    switch (typeColor)
                    {
                        case "touch up":
                            income += 20;
                            break;

                        case "full color":
                            income += 30;
                            break;
                    }
                }

                if (income >= dayIncomeGoal)
                {
                    break;
                }
            }

            if (income >= dayIncomeGoal)
            {
                Console.WriteLine("You have reached your target for the day!");
                Console.WriteLine($"Earned money: {income}lv.");
            }
            else
            {
                Console.WriteLine($"Target not reached! You need {dayIncomeGoal - income}lv. more.");
                Console.WriteLine($"Earned money: {income}lv.");
            }
        }
    }
}
