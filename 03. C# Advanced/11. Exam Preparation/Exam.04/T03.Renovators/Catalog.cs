using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Renovators
{
    public class Catalog
    {
        private List<Renovator> renovators;

        public Catalog(string name, int neededRenovators, string project)
        {
            this.renovators = new List<Renovator>();
            Name = name;
            NeededRenovators = neededRenovators;
            Project = project;
        }

        public string Name { get; set; }
        public int NeededRenovators { get; set; }
        public string Project { get; set; }
        public int Count { get => this.renovators.Count; }

        public string AddRenovator(Renovator renovator)
        {
            if (string.IsNullOrEmpty(renovator.Name) ||
                string.IsNullOrEmpty(renovator.Type))
            {
                return "Invalid renovator's information.";
            }

            if (this.NeededRenovators == 0)
                return "Renovators are no more needed.";

            if (renovator.Rate > 350)
                return "Invalid renovator's rate.";

            this.renovators.Add(renovator);
            this.NeededRenovators--;

            return $"Successfully added {renovator.Name} to the catalog.";
        }

        public bool RemoveRenovator(string name)
        {
            var removedRenovator = this.renovators
                .FirstOrDefault(r => r.Name == name);

            if (removedRenovator != null)
            {
                this.renovators.Remove(removedRenovator);
                return true;
            }

            return false;
        }

        public int RemoveRenovatorBySpecialty(string type)
            => this.renovators.RemoveAll(r => r.Type == type);

        public Renovator HireRenovator(string name)
        {
            var renovator = this.renovators.FirstOrDefault(r => r.Name == name);

            if (renovator != null)
                renovator.Hired = true;

            return renovator;
        }

        public List<Renovator> PayRenovators(int days)
        {
            List<Renovator> renovators = this.renovators
                .Where(r => r.Days >= days)
                .ToList();

            return renovators;
        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Renovators available for Project {this.Project}:");

            foreach (var renovator in this.renovators.Where(r => r.Hired == false))
            {
                sb.AppendLine(renovator.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
