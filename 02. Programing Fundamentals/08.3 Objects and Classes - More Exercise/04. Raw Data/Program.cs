using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Raw_Data
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            int numberOfCars = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCars; i++)
            {
                string[] carDetails = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Engine engine = new Engine(int.Parse(carDetails[1]), int.Parse(carDetails[2]));
                Cargo cargo = new Cargo(int.Parse(carDetails[3]), carDetails[4]);
                Car car = new Car(carDetails[0], engine, cargo);
                cars.Add(car);
            }

            List<Car> filteredCars = new List<Car>();

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                filteredCars = cars.Where(c => c.Cargo.CargoType == command && c.Cargo.CargoWeight < 1000).ToList();
            }
            else if (command == "flamable")
            {
                filteredCars = cars.Where(c => c.Cargo.CargoType == command && c.Engine.EnginePower > 250).ToList();
            }

            foreach (var car in filteredCars)
            {
                Console.WriteLine(car);
            }
        }
    }

    class Car
    {
        public Car(string model, Engine engine, Cargo cargo)
        {
            Model = model;
            Engine = engine;
            Cargo = cargo;
        }

        public string Model { get; set; }
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }
        public override string ToString()
        {
            return $"{Model}";
        }
    }

    class Engine
    {
        public Engine(int engineSpeed, int enginePower)
        {
            EngineSpeed = engineSpeed;
            EnginePower = enginePower;
        }

        public int EngineSpeed { get; set; }
        public int EnginePower { get; set; }
    }

    class Cargo
    {
        public Cargo(int cargoWeight, string cargoType)
        {
            CargoWeight = cargoWeight;
            CargoType = cargoType;
        }

        public int CargoWeight { get; set; }
        public string CargoType { get; set; }
    }
}
