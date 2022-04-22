using System;

namespace _02._Bonus_Score
{
    class Program
    {
        static void Main(string[] args)
        {
            int pointsCount = int.Parse(Console.ReadLine());
            double bonusPointsCount = 0;
            double adBonusPointsCount = 0;

            if (pointsCount <= 100)
            {
                bonusPointsCount = 5;
            }
            else if (pointsCount > 100 && pointsCount <= 1000)
            {
                bonusPointsCount = pointsCount * 0.2;
            }
            else if (pointsCount > 1000)
            {
                bonusPointsCount = pointsCount * 0.1;
            }

            if (pointsCount % 2 == 0)
            {
                adBonusPointsCount = 1;
            }

            if (pointsCount % 10 == 5)
            {
                adBonusPointsCount = 2;
            }

            Console.WriteLine(bonusPointsCount + adBonusPointsCount);
            Console.WriteLine(pointsCount + bonusPointsCount + adBonusPointsCount);
        }
    }
}
