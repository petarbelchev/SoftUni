namespace SumOfCoins
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<int> coins = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int targetSum = int.Parse(Console.ReadLine());

            var countOfCoins = ChooseCoins(coins, targetSum);

            Console.WriteLine($"Number of coins to take: {countOfCoins.Values.Sum()}");

            foreach (var coin in countOfCoins)
            {
                Console.WriteLine($"{coin.Value} coin(s) with value {coin.Key}");
            }
        }

        public static Dictionary<int, int> ChooseCoins(List<int> coins, int targetSum)
        {
            var takedCoins = new Dictionary<int, int>();

            coins = coins.OrderByDescending(x => x).ToList();

            foreach (var coin in coins)
            {
                int coinsToTake = targetSum / coin;

                if (coinsToTake > 0)
                {
                    takedCoins[coin] = coinsToTake;
                    targetSum -= coin * coinsToTake;

                    if (targetSum == 0)
                    {
                        break;
                    }
                }
            }

            if (targetSum == 0)
            {
                return takedCoins;
            }
            else
            {
                throw new InvalidOperationException("Error");
            }
        }
    }
}