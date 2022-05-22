using System;

namespace _05._Movie_Ratings
{
    class Program
    {
        static void Main(string[] args)
        {
            int moviesQuantity = int.Parse(Console.ReadLine());
            string highestName = null;
            string lowestName = null;
            double highestRating = double.MinValue;
            double lowestRating = double.MaxValue;
            double ratingCounter = 0;

            for (int i = 1; i <= moviesQuantity; i++)
            {
                string inputName = Console.ReadLine();
                double inputRating = double.Parse(Console.ReadLine());

                if (inputRating > highestRating)
                {
                    highestRating = inputRating;
                    highestName = inputName;
                    ratingCounter += inputRating;
                }
                else if (inputRating < lowestRating)
                {
                    lowestRating = inputRating;
                    lowestName = inputName;
                    ratingCounter += inputRating;
                }
                else
                {
                    ratingCounter += inputRating;
                }
            }

            Console.WriteLine($"{highestName} is with highest rating: {highestRating:f1}");
            Console.WriteLine($"{lowestName} is with lowest rating: {lowestRating:f1}");
            Console.WriteLine($"Average rating: {ratingCounter / moviesQuantity:f1}");
        }
    }
}
