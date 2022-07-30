using System;
using System.Linq;

namespace _06._Speed_Racing
{
    internal class Program
    {
        static void Main()
        {
            int carsCount = int.Parse(Console.ReadLine());
            Car[] cars = new Car[carsCount];
            for (int i = 0; i < carsCount; i++)
            {
                string[] currCarData = Console.ReadLine().Split();
                string model = currCarData[0];
                double fuelAmount = double.Parse(currCarData[1]);
                double fuelConsumptionFor1km = double.Parse(currCarData[2]);

                cars[i] = new Car(model, fuelAmount, fuelConsumptionFor1km);
            }

            string cmd;
            while ((cmd = Console.ReadLine()) != "End")
            {
                string[] carInfo = cmd.Split();
                string model = carInfo[1];
                double amountOfKm = double.Parse(carInfo[2]);
                Car currCar = cars.First(car => car.Model == model);
                currCar.Drive(amountOfKm);
            }

            Action<Car> print = car => Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");

            Array.ForEach(cars, print);
        }
    }
}
