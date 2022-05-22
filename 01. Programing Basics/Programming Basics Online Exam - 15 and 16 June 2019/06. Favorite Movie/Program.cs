using System;

namespace _06._Favorite_Movie
{
    class Program
    {
        static void Main(string[] args)
        {
            int higherPoints = int.MinValue;
            string nameHigherPointsMovie = null;

            for (int numCurrentMovie = 1; numCurrentMovie <= 7; numCurrentMovie++)
            {
                string nameCurrentMovie = Console.ReadLine();

                if (nameCurrentMovie == "STOP")
                {
                    break;
                }

                int pointsCurrentMovie = 0;
                int smallLettersCount = 0;
                int bigLettersCount = 0;

                for (int currentLetter = 0; currentLetter < nameCurrentMovie.Length; currentLetter++)
                {
                    pointsCurrentMovie += nameCurrentMovie[currentLetter];

                    if (nameCurrentMovie[currentLetter] >= 'a' && nameCurrentMovie[currentLetter] <= 'z')
                    {
                        smallLettersCount++;
                    }
                    else if (nameCurrentMovie[currentLetter] >= 'A' && nameCurrentMovie[currentLetter] <= 'Z')
                    {
                        bigLettersCount++;
                    }
                }

                int smallLettersPoints = smallLettersCount * (nameCurrentMovie.Length * 2);
                int bigLettersPoints = bigLettersCount * nameCurrentMovie.Length;
                pointsCurrentMovie -= smallLettersPoints + bigLettersPoints;

                if (pointsCurrentMovie > higherPoints)
                {
                    higherPoints = pointsCurrentMovie;
                    nameHigherPointsMovie = nameCurrentMovie;
                }

                if (numCurrentMovie == 7)
                {
                    Console.WriteLine("The limit is reached.");
                    break;
                }
            }

            Console.WriteLine($"The best movie for you is {nameHigherPointsMovie} with {higherPoints} ASCII sum.");
        }
    }
}
