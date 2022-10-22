using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerArchitecture
{
    public class Computer
    {
        public Computer(string model, int capacity)
        {
            Model = model;
            Capacity = capacity;
            Multiprocessor = new List<CPU>();
        }

        public string Model { get; set; }
        public int Capacity { get; set; }
        public List<CPU> Multiprocessor { get; set; }
        public int Count { get => Multiprocessor.Count; }

        public void Add(CPU cpu)
        {
            if (Capacity > Multiprocessor.Count)
                Multiprocessor.Add(cpu);
        }

        public bool Remove(string brand)
        {
            var cpu = Multiprocessor.FirstOrDefault(c => c.Brand == brand);

            if (cpu != null)
            {
                Multiprocessor.Remove(cpu);
                return true;
            }

            return false;
        }

        public CPU MostPowerful()
            => Multiprocessor.OrderByDescending(c => c.Frequency).FirstOrDefault();

        public CPU GetCPU(string brand)
            => Multiprocessor.FirstOrDefault(c => c.Brand == brand);

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"CPUs in the Computer {Model}:");

            foreach (var cpu in Multiprocessor)
                sb.AppendLine(cpu.ToString());

            return sb.ToString().TrimEnd();
        }
    }
}
