using System;
using System.Linq;

namespace _08._Car_Salesman
{
    public class StartUp
    {
        static void Main()
        {
            int countOfEngines = int.Parse(Console.ReadLine());
            var engines = new Engine[countOfEngines];

            for (int i = 0; i < countOfEngines; i++)
            {
                string[] currEngineData = Console.ReadLine()
                    .Split(' ',StringSplitOptions.RemoveEmptyEntries);
                string model = currEngineData[0];
                int power = int.Parse(currEngineData[1]);

                if (currEngineData.Length > 2)
                {
                    if (currEngineData.Length == 3)
                    {
                        int displacement;

                        if (int.TryParse(currEngineData[2], out displacement))
                        {
                            engines[i] = new Engine(model, power, displacement);
                        }
                        else
                        {
                            string efficiency = currEngineData[2];
                            engines[i] = new Engine(model, power, efficiency);
                        }
                    }
                    else
                    {
                        int displacement = int.Parse(currEngineData[2]);
                        string efficiency = currEngineData[3];
                        engines[i] = new Engine(model, power, displacement, efficiency);
                    }
                }
                else
                {
                    engines[i] = new Engine(model, power);
                }
            }

            int countOfCars = int.Parse(Console.ReadLine());
            var cars = new Car[countOfCars];

            for (int i = 0; i < countOfCars; i++)
            {
                string[] currCarData = Console.ReadLine()
                    .Split(' ',StringSplitOptions.RemoveEmptyEntries);
                string model = currCarData[0];
                Engine engine = engines.First(engine => engine.Model == currCarData[1]);

                if (currCarData.Length > 2)
                {
                    if (currCarData.Length == 3)
                    {
                        int weight;

                        if (int.TryParse(currCarData[2], out weight))
                        {
                            cars[i] = new Car(model, engine, weight);
                        }
                        else
                        {
                            string color = currCarData[2];
                            cars[i] = new Car(model, engine, color);
                        }
                    }
                    else
                    {
                        int weight = int.Parse(currCarData[2]);
                        string color = currCarData[3];
                        cars[i] = new Car(model, engine, weight, color);
                    }
                }
                else
                {
                    cars[i] = new Car(model, engine);
                }
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
