using System;

namespace VehiclesExtension
{
    public class StartUp
    {
        static void Main()
        {
            string[] carData = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Vehicle car = new Car(
                int.Parse(carData[1]), 
                double.Parse(carData[2]), 
                int.Parse(carData[3]));

            string[] truckData = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Vehicle truck = new Truck(
                int.Parse(truckData[1]), 
                double.Parse(truckData[2]), 
                int.Parse(truckData[3]));

            string[] busData = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Vehicle bus = new Bus(
                int.Parse(busData[1]), 
                double.Parse(busData[2]), 
                int.Parse(busData[3]));

            int numOfCmds = int.Parse(Console.ReadLine());

            for (int i = 0; i < numOfCmds; i++)
            {
                string[] cmdArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string mainCmd = cmdArgs[0];
                string typeVehicle = cmdArgs[1];

                if (mainCmd == "Drive")
                {
                    if (typeVehicle == "Car")
                        car.Drive(double.Parse(cmdArgs[2]));

                    else if (typeVehicle == "Truck")
                        truck.Drive(double.Parse(cmdArgs[2]));

                    else if (typeVehicle == "Bus")
                        bus.Drive(double.Parse(cmdArgs[2]));
                }
                else if (mainCmd == "Refuel")
                {
                    if (typeVehicle == "Car")
                        car.Refuel(double.Parse(cmdArgs[2]));

                    else if (typeVehicle == "Truck")
                        truck.Refuel(double.Parse(cmdArgs[2]));

                    else if (typeVehicle == "Bus")
                        bus.Refuel(double.Parse(cmdArgs[2]));
                }
                else if (mainCmd == "DriveEmpty")
                {
                    (bus as Bus)?.DriveEmpty(double.Parse(cmdArgs[2]));
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }
    }
}
