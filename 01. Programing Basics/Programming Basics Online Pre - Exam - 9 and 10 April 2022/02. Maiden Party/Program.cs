using System;

namespace _02._Maiden_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            double maidenPartyPrice = double.Parse(Console.ReadLine());
            int loveMessages = int.Parse(Console.ReadLine());
            int roses = int.Parse(Console.ReadLine());
            int keyHolders = int.Parse(Console.ReadLine());
            int cartoons = int.Parse(Console.ReadLine());
            int luckySurprises = int.Parse(Console.ReadLine());

            int purchaseQuantity = loveMessages + roses + keyHolders + cartoons + luckySurprises;

            double loveMessagesPrice = loveMessages * 0.6;
            double rosesPrice = roses * 7.2;
            double keyHoldersPrice = keyHolders * 3.6;
            double cartoonsPrice = cartoons * 18.2;
            double luckySurprisesPrice = luckySurprises * 22;

            double totalPrice = loveMessagesPrice + rosesPrice + keyHoldersPrice + cartoonsPrice + luckySurprisesPrice;

            if (purchaseQuantity >= 25)
            {
                totalPrice -= totalPrice * 0.35;
            }

            totalPrice -= totalPrice * 0.1;

            if (totalPrice >= maidenPartyPrice)
            {
                Console.WriteLine($"Yes! {totalPrice - maidenPartyPrice:f2} lv left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! {maidenPartyPrice - totalPrice:f2} lv needed.");
            }
        }
    }
}
