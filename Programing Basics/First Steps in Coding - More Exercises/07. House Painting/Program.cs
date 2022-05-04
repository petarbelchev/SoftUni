using System;

namespace _07._House_Painting
{
    class Program
    {
        static void Main(string[] args)
        {
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());

            double gnPntPrM2 = 1 / 3.4;
            double rdPntPrM2 = 1 / 4.3;

            double frontWallM2 = x * x - 1.2 * 2;
            double backWallM2 = x * x;
            double sideWallsM2 = (x * y - 1.5 * 1.5) * 2;
            double roofSideWallsM2 = x * y * 2;
            double roofTrianglesM2 = ((x * h) / 2) * 2;

            double neededGrPnt = (frontWallM2 + backWallM2 + sideWallsM2) * gnPntPrM2;
            double neededRdPnt = (roofSideWallsM2 + roofTrianglesM2) * rdPntPrM2;

            Console.WriteLine($"{neededGrPnt:f2}");
            Console.WriteLine($"{neededRdPnt:f2}");
        }
    }
}
