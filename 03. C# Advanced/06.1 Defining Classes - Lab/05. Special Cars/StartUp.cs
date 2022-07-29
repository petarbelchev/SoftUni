using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main()
        {
            string input;
            var tires = new List<Tire[]>();

            while ((input = Console.ReadLine()) != "No more tires")
            {
                string[] tiresData = input.Split();
                var currTires = new Tire[4];
                int index = 0;
                for (int i = 0; i < tiresData.Length - 1; i += 2)
                {
                    int currYear = int.Parse(tiresData[i]);
                    double currPressure = double.Parse(tiresData[i + 1]);
                    currTires[index++] = new Tire(currYear, currPressure);
                }
                tires.Add(currTires);
            }

            var engines = new List<Engine>();

            while ((input = Console.ReadLine()) != "Engines done")
            {
                string[] engineData = input.Split();
                int horsePower = int.Parse(engineData[0]);
                double cubicCapacity = double.Parse(engineData[1]);
                engines.Add(new Engine(horsePower, cubicCapacity));
            }

            var cars = new List<Car>();

            while ((input = Console.ReadLine()) != "Show special")
            {
                string[] carData = input.Split();
                string make = carData[0];
                string model = carData[1];
                int year = int.Parse(carData[2]);
                double fuelQuantity = double.Parse(carData[3]);
                double fuelConsumption = double.Parse(carData[4]);
                int engineIndex = int.Parse(carData[5]);
                int tiresIndex = int.Parse(carData[6]);

                cars.Add(new Car(make, model, year, fuelQuantity, fuelConsumption, engines[engineIndex], tires[tiresIndex]));
            }

            Func<Tire[], double> sumOfTiresPressure = tires =>
            {
                double sum = 0;
                foreach (var tire in tires)
                {
                    sum += tire.Pressure;
                }
                return sum;
            };

            foreach (var car in cars.Where(car => car.Year >= 2017
                                                && car.Engine.HorsePower > 330
                                                  && sumOfTiresPressure(car.Tires) >= 9
                                                     && sumOfTiresPressure(car.Tires) <= 10))
            {
                car.Drive(20);
                Console.WriteLine(car.WhoAmI());
            }
        }
    }
}
