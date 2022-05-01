using System;

namespace _02._Hospital
{
    class Program
    {
        static void Main(string[] args)
        {
            int period = int.Parse(Console.ReadLine());
            int patientsCounter = 0;
            int forOtherHospital = 0;
            int doctorsQuantity = 7;
            int day3Counter = 1;

            for (int i = 1; i <= period; i++)
            {
                int patientsPerDay = int.Parse(Console.ReadLine());

                if (day3Counter == 3 && forOtherHospital > patientsCounter)
                {
                    doctorsQuantity++;
                    day3Counter = 0;
                }
                else if (day3Counter == 3)
                {
                    day3Counter = 0;
                }

                day3Counter++;

                if (patientsPerDay <= doctorsQuantity)
                {
                    patientsCounter += patientsPerDay;
                }
                else
                {
                    patientsCounter += doctorsQuantity;
                    forOtherHospital += patientsPerDay - doctorsQuantity;
                }
            }

            Console.WriteLine($"Treated patients: {patientsCounter}.");
            Console.WriteLine($"Untreated patients: {forOtherHospital}.");
        }
    }
}
