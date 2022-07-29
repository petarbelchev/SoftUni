using System;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main()
        {
            var myCar = new Car()
            {
                Make = "VW",
                Model = "Passat",
                Year = 1999,
                FuelConsumption = 5,
                FuelQuantity = 50
            };

            myCar.Drive(200);
            Console.WriteLine(myCar.WhoAmI());
        }
    }
}
