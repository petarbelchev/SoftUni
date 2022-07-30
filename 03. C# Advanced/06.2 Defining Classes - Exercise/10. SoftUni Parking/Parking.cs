using System.Collections.Generic;
using System.Linq;
using System;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> cars = new List<Car>();
        private int capacity;

        public Parking(int capacity)
        {
            this.capacity = capacity;
        }

        public int Count 
        {
            get { return cars.Count; }
        }

        public string AddCar(Car newCar)
        {
            if (cars.Any(car => car.RegistrationNumber == newCar.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }
            else if (capacity <= cars.Count)
            {
                return "Parking is full!";
            }
            else
            {
                cars.Add(newCar);
                return $"Successfully added new car {newCar.Make} {newCar.RegistrationNumber}";
            }
        }

        public string RemoveCar(string RegistrationNumber)
        {
            var currCar = cars.FirstOrDefault(car => car.RegistrationNumber == RegistrationNumber);

            if (currCar == null)
            {
                return "Car with that registration number, doesn't exist!";
            }
            else
            {
                cars.Remove(currCar);

                return $"Successfully removed {currCar.RegistrationNumber}";
            }
        }

        public Car GetCar(string registrationNumber)
        {
            Car currCar = cars
                .First(car => car.RegistrationNumber == registrationNumber);

            return currCar;
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (var currNumber in registrationNumbers)
            {
                RemoveCar(currNumber);
            }
        }
    }
}
