using System;

namespace _11._Fruit_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            string fruit = Console.ReadLine();
            string day = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());

            bool workingDays = day == "Monday" || day == "Tuesday" || day == "Wednesday" ||
                day == "Thursday" || day == "Friday";
            bool weekendDays = day == "Saturday" || day == "Sunday";

            if (workingDays)
            {
                switch (fruit)
                {
                    case "banana":
                        Console.WriteLine($"{quantity * 2.5:f2}");
                        break;
                    case "apple":
                        Console.WriteLine($"{quantity * 1.2:f2}");
                        break;
                    case "orange":
                        Console.WriteLine($"{quantity * 0.85:f2}");
                        break;
                    case "grapefruit":
                        Console.WriteLine($"{quantity * 1.45:f2}");
                        break;
                    case "kiwi":
                        Console.WriteLine($"{quantity * 2.7:f2}");
                        break;
                    case "pineapple":
                        Console.WriteLine($"{quantity * 5.5:f2}");
                        break;
                    case "grapes":
                        Console.WriteLine($"{quantity * 3.85:f2}");
                        break;
                    default:
                        Console.WriteLine("error");
                        break;
                }
            }
            else if (weekendDays)
            {
                switch (fruit)
                {
                    case "banana":
                        Console.WriteLine($"{quantity * 2.7:f2}");
                        break;
                    case "apple":
                        Console.WriteLine($"{quantity * 1.25:f2}");
                        break;
                    case "orange":
                        Console.WriteLine($"{quantity * 0.9:f2}");
                        break;
                    case "grapefruit":
                        Console.WriteLine($"{quantity * 1.6:f2}");
                        break;
                    case "kiwi":
                        Console.WriteLine($"{quantity * 3:f2}");
                        break;
                    case "pineapple":
                        Console.WriteLine($"{quantity * 5.6:f2}");
                        break;
                    case "grapes":
                        Console.WriteLine($"{quantity * 4.2:f2}");
                        break;
                    default:
                        Console.WriteLine("error");
                        break;
                }
            }
            else
            {
                Console.WriteLine("error");
            }
        }
    }
}
