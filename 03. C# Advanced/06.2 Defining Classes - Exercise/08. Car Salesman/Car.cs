using System;
using System.Text;

namespace _08._Car_Salesman
{
    public class Car
    {
        public Car(string model, Engine engine)
        {
            Model = model;
            Engine = engine;
        }
        public Car(string model, Engine engine, int weight, string color)
            : this(model, engine)
        {
            Weight = weight;
            Color = color;
        }

        public Car(string model, Engine engine, string color)
            : this(model, engine)
        {
            Color = color;
        }

        public Car(string model, Engine engine, int weight)
            : this(model, engine)
        {
            Weight = weight;
        }

        public string Model { get; set; }

        public Engine Engine { get; set; }

        public int Weight { get; set; }

        public string Color { get; set; } = "n/a";

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{Model}:");
            sb.AppendLine($"  {Engine.Model}:");
            sb.AppendLine($"    Power: {Engine.Power}");
            
            if (Engine.Displacement != 0)
                sb.AppendLine($"    Displacement: {Engine.Displacement}");
            else
                sb.AppendLine($"    Displacement: n/a");

            sb.AppendLine($"    Efficiency: {Engine.Efficiency}");

            if (Weight != 0)
                sb.AppendLine($"  Weight: {Weight}");
            else
                sb.AppendLine($"  Weight: n/a");

            sb.AppendLine($"  Color: {Color}");

            return sb.ToString().TrimEnd();
        }
    }
}
