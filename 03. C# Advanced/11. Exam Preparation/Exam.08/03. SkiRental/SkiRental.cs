using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkiRental
{
    public class SkiRental
    {
        private List<Ski> data;

        public SkiRental(string name, int capacity)
        {
            this.data = new List<Ski>();
            Name = name;
            Capacity = capacity;
        }

        public string Name { get; set; }
        public int Capacity { get; set; }

        public void Add(Ski ski)
        {
            if (Capacity > data.Count)
                data.Add(ski);
        }

        public bool Remove(string manufacturer, string model)
        {
            var ski = data.FirstOrDefault(s =>
                    s.Manufacturer == manufacturer &&
                    s.Model == model);

            if (ski != null)
            {
                data.Remove(ski);
                return true;
            }

            return false;
        }

        public Ski GetNewestSki()
         => data.OrderByDescending(s => s.Year).FirstOrDefault();

        public Ski GetSki(string manufacturer, string model)
         => data.FirstOrDefault(s => s.Manufacturer == manufacturer && s.Model == model);

        public int Count => data.Count;

        public string GetStatistics()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"The skis stored in {Name}:");
            data.ForEach(s => sb.AppendLine(s.ToString()));
            return sb.ToString().TrimEnd();
        }
    }
}
