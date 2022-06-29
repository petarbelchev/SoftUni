using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Vehicle_Catalogue
{
    internal class Program
    {
        class Truck
        {
            public Truck(string brand, string model, int weight)
            {
                this.Brand = brand;
                this.Model = model;
                this.Weight = weight;
            }
            public string Brand { get; set; }
            public string Model { get; set; }
            public int Weight { get; set; }
        }

        class Car
        {
            public Car(string brand, string model, int horsePower)
            {
                this.Brand = brand;
                this.Model = model;
                this.HorsePower = horsePower;
            }
            public string Brand { get; set; }
            public string Model { get; set; }
            public int HorsePower { get; set; }
        }

        class Catalog
        {
            public Catalog()
            {
                this.Trucks = new List<Truck>();
                this.Cars = new List<Car>();
            }

            public List<Truck> Trucks { get; set; }
            public List<Car> Cars { get; set; }
        }

        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Catalog trucksAndCars = new Catalog();

            while (input != "end")
            {
                string[] vehicleDetails = input.Split('/');
                string type = vehicleDetails[0];
                string brand = vehicleDetails[1];
                string model = vehicleDetails[2];
                if (type == "Truck")
                {
                    int weight = int.Parse(vehicleDetails[3]);

                    Truck newTruck = new Truck(brand, model, weight);

                    trucksAndCars.Trucks.Add(newTruck);
                }
                else if (type == "Car")
                {
                    int horsePower = int.Parse(vehicleDetails[3]);

                    Car newCar = new Car(brand, model, horsePower);

                    trucksAndCars.Cars.Add(newCar);
                }

                input = Console.ReadLine();
            }

            if (trucksAndCars.Cars.Count > 0)
            {
                List<Car> orderedCars = trucksAndCars
                .Cars.OrderBy(vehicle => vehicle.Brand).ToList();

                Console.WriteLine("Cars:");
                
                foreach (Car car in orderedCars)
                {
                    Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
                }
            }

            if (trucksAndCars.Trucks.Count > 0)
            {
                List<Truck> orderedTrucks = trucksAndCars
                .Trucks.OrderBy(vehicle => vehicle.Brand).ToList();

                Console.WriteLine("Trucks:");
                
                foreach (Truck truck in orderedTrucks)
                {
                    Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
                }
            }
        }
    }
}
