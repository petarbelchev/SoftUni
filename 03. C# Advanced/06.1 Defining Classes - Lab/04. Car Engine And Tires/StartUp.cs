using System;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main()
        {
            var tires = new Tire[4]
            {
                new Tire(1, 2.4),
                new Tire(1, 2.4),
                new Tire(2, 2.5),
                new Tire(2, 2.5)
            };

            var engine = new Engine(500, 5600);

            var car = new Car("Ferrari", "Enzo", 1999, 80, 20, engine, tires);

            Console.WriteLine(car.WhoAmI());
        }
    }
}
