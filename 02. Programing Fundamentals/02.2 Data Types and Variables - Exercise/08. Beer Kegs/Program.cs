using System;

namespace _08._Beer_Kegs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int kegsCount = int.Parse(Console.ReadLine());
            double volumeBiggestKeg = 0;
            string modelBiggestKeg = string.Empty;

            for (int currKeg = 1; currKeg <= kegsCount; currKeg++)
            {
                string modelOfKeg = Console.ReadLine();
                double radiusOfKeg = double.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());
                double volumeOfKeg = Math.PI * (radiusOfKeg * radiusOfKeg) * height;
                if (volumeOfKeg > volumeBiggestKeg)
                {
                    volumeBiggestKeg = volumeOfKeg;
                    modelBiggestKeg = modelOfKeg;
                }
            }

            Console.WriteLine(modelBiggestKeg);
        }
    }
}
