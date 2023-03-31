namespace Trucks.DataProcessor
{
	using Data;
	using Newtonsoft.Json;
	using System.Text;
	using System.Xml.Serialization;
	using Trucks.DataProcessor.ExportDto;

	public class Serializer
    {
        public static string ExportDespatchersWithTheirTrucks(TrucksContext context)
        {
            ExportDespatchersDTO[] despatchersDTOs = context.Despatchers
                .Where(d => d.Trucks.Any())
                .Select(d => new ExportDespatchersDTO
                {
                    DespatcherName = d.Name,
                    TrucksCount = d.Trucks.Count.ToString(),
                    Trucks = d.Trucks.Select(t => new ExportTruckDTO
                    {
                        RegistrationNumber = t.RegistrationNumber,
                        Make = t.MakeType.ToString()
                    })
                    .OrderBy(t => t.RegistrationNumber)
                    .ToArray()
                })
                .OrderByDescending(d => d.TrucksCount)
                .ThenBy(d => d.DespatcherName)
                .ToArray();

            return Serialize(despatchersDTOs, "Despatchers");
        }

        public static string ExportClientsWithMostTrucks(TrucksContext context, int capacity)
        {
            var clients = context.Clients
                .Where(c => c.ClientsTrucks.Any(ct => ct.Truck.TankCapacity >= capacity))
                .ToArray()
                .Select(c => new
                {
                    c.Name,
                    Trucks = c.ClientsTrucks.Where(ct => ct.Truck.TankCapacity >= capacity)
                        .Select(ct => new
                        {
                            TruckRegistrationNumber = ct.Truck.RegistrationNumber,
                            ct.Truck.VinNumber,
                            ct.Truck.TankCapacity,
							ct.Truck.CargoCapacity,
                            CategoryType = ct.Truck.CategoryType.ToString(),
                            MakeType = ct.Truck.MakeType.ToString()
                        })
                        .OrderBy(t => t.MakeType)
                        .ThenByDescending(t => t.CargoCapacity)
                })
                .OrderByDescending(c => c.Trucks.Count())
                .ThenBy(c => c.Name)
                .Take(10)
                .ToArray();

            return JsonConvert.SerializeObject(clients, Formatting.Indented);
        }

        private static string Serialize<T>(T @object, string root)
		{
			StringBuilder sb = new StringBuilder();
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), new XmlRootAttribute(root));
			XmlSerializerNamespaces xsn = new XmlSerializerNamespaces();
			xsn.Add(string.Empty, string.Empty);

			using (StringWriter writer = new StringWriter(sb))
			{
				xmlSerializer.Serialize(writer, @object, xsn);
			}

			return sb.ToString().TrimEnd();
		}
    }
}
