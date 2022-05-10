using System;

namespace _13._Prime_Pairs
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstCoupleStart = int.Parse(Console.ReadLine());
            int secondCoupleStart = int.Parse(Console.ReadLine());
            int firstCoupleDifference = int.Parse(Console.ReadLine());
            int secondCoupleDifference = int.Parse(Console.ReadLine());

            for (int firstCouple = firstCoupleStart; firstCouple <= firstCoupleStart + firstCoupleDifference; firstCouple++)
            {
                bool isFirstCouplePrime = true;

                for (int divider = 2; divider < firstCouple; divider++)
                {
                    if (firstCouple % divider == 0)
                    {
                        isFirstCouplePrime = false;
                        break;
                    }
                }

                if (isFirstCouplePrime)
                {
                    for (int secondCouple = secondCoupleStart; secondCouple <= secondCoupleStart + secondCoupleDifference; secondCouple++)
                    {
                        bool isSecondCouplePrime = true;

                        for (int divider = 2; divider < secondCouple; divider++)
                        {
                            if (secondCouple % divider == 0)
                            {
                                isSecondCouplePrime = false;
                                break;
                            }
                        }

                        if (isFirstCouplePrime && isSecondCouplePrime)
                        {
                            Console.WriteLine($"{firstCouple}{secondCouple}");
                        }
                    }
                }
            }
        }
    }
}
