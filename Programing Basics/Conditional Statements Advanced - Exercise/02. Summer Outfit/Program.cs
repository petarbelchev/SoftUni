using System;

namespace _02._Summer_Outfit
{
    class Program
    {
        static void Main(string[] args)
        {
            int temperature = int.Parse(Console.ReadLine());
            string time = Console.ReadLine();

            switch (time)
            {
                case "Morning":
                    if (10 <= temperature && temperature <= 18)
                    {
                        Console.WriteLine($"It's {temperature} degrees, " +
                            $"get your Sweatshirt and Sneakers.");
                    }
                    else if (18 < temperature && temperature <= 24)
                    {
                        Console.WriteLine($"It's {temperature} degrees, " +
                            $"get your Shirt and Moccasins.");
                    }
                    else if (temperature >= 25)
                    {
                        Console.WriteLine($"It's {temperature} degrees, " +
                            $"get your T-Shirt and Sandals.");
                    }
                    break;


                case "Afternoon":
                    if (10 <= temperature && temperature <= 18)
                    {
                        Console.WriteLine($"It's {temperature} degrees, " +
                            $"get your Shirt and Moccasins.");
                    }
                    else if (18 < temperature && temperature <= 24)
                    {
                        Console.WriteLine($"It's {temperature} degrees, " +
                            $"get your T-Shirt and Sandals.");
                    }
                    else if (temperature >= 25)
                    {
                        Console.WriteLine($"It's {temperature} degrees, " +
                            $"get your Swim Suit and Barefoot.");
                    }
                    break;

                case "Evening":
                    if (10 <= temperature && temperature <= 18)
                    {
                        Console.WriteLine($"It's {temperature} degrees, " +
                            $"get your Shirt and Moccasins.");
                    }
                    else if (18 < temperature && temperature <= 24)
                    {
                        Console.WriteLine($"It's {temperature} degrees, " +
                            $"get your Shirt and Moccasins.");
                    }
                    else if (temperature >= 25)
                    {
                        Console.WriteLine($"It's {temperature} degrees, " +
                            $"get your Shirt and Moccasins.");
                    }
                    break;
            }
        }
    }
}
