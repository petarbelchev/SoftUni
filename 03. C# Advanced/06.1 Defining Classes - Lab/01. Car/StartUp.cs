using System;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main()
        {
            var newCar = new Car()
            {
                Make = "VW",
                Model = "Passat",
                Year = 1992
            };

            Console.WriteLine($"Make: {newCar.Make}\nModel: {newCar.Model}\nYear: {newCar.Year}");
        }
    }
}

