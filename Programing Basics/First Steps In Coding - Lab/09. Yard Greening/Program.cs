using System;

namespace Yard_Greening
{
    class Program
    {
        static void Main(string[] args)
        {
            double squareМeters = double.Parse(Console.ReadLine());
            double price = squareМeters * 7.61;
            double discountPrice = price * 0.18;
            double finalPrice = price - discountPrice;
            
            Console.WriteLine($"The final price is: {finalPrice} lv.");
            Console.WriteLine($"The discount is: {discountPrice} lv.");
        }
    }
}
