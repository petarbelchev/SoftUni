namespace _07._Raw_Data
{
    public class Car
    {
        public Car(string carInfo)
        {
            string[] carData = carInfo.Split();
            string model = carData[0];
            int engineSpeed = int.Parse(carData[1]);
            int enginePower = int.Parse(carData[2]);
            int cargoWeight = int.Parse(carData[3]);
            string cargoType = carData[4];
            double tire1Pressure = double.Parse(carData[5]);
            int tire1Age = int.Parse(carData[6]);
            double tire2Pressure = double.Parse(carData[7]);
            int tire2Age = int.Parse(carData[8]);
            double tire3Pressure = double.Parse(carData[9]);
            int tire3Age = int.Parse(carData[10]);
            double tire4Pressure = double.Parse(carData[11]);
            int tire4Age = int.Parse(carData[12]);

            Model = model;
            Engine = new Engine(engineSpeed, enginePower);
            Cargo = new Cargo(cargoType, cargoWeight);

            Tires = new Tire[]
            {
                new Tire(tire1Age, tire1Pressure),
                new Tire(tire2Age, tire2Pressure),
                new Tire(tire3Age, tire3Pressure),
                new Tire(tire4Age, tire4Pressure)
            };
        }

        public string Model { get; set; }

        public Engine Engine { get; set; }

        public Cargo Cargo { get; set; }

        public Tire[] Tires { get; set; }

        public override string ToString()
        {
            return $"{Model}";
        }
    }
}
