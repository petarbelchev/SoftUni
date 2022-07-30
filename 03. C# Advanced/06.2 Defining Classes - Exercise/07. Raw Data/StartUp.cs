using System;
using System.Linq;

namespace _07._Raw_Data
{
    internal class StartUp
    {
        static void Main()
        {
            int carsCount = int.Parse(Console.ReadLine());
            
            Car[] cars = new Car[carsCount];

            for (int i = 0; i < carsCount; i++)
            {
                string currCarInfo = Console.ReadLine();
                cars[i] = new Car(currCarInfo);
            }

            string carsTypeForPrint = Console.ReadLine();

            Predicate<Tire[]> predicate = tires =>
            {
                foreach (var tire in tires)
                {
                    if (tire.Pressure < 1)
                    {
                        return true;
                    }
                }
                return false;
            };

            if (carsTypeForPrint == "fragile")
            {
                Console.WriteLine(string.Join(Environment.NewLine, cars.Where(car => car.Cargo.Type == "fragile" && predicate(car.Tires))));
            }
            else if (carsTypeForPrint == "flammable")
            {
                Console.WriteLine(string.Join(Environment.NewLine, cars.Where(car => car.Cargo.Type == "flammable" && car.Engine.Power > 250)));
            }
        }
    }
}
