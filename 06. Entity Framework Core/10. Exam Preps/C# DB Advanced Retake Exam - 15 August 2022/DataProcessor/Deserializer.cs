namespace Trucks.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
	using System.Text;
	using System.Xml.Serialization;
	using Data;
	using Newtonsoft.Json;
	using Trucks.Data.Models;
	using Trucks.Data.Models.Enums;
	using Trucks.DataProcessor.ImportDto;

	public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedDespatcher
            = "Successfully imported despatcher - {0} with {1} trucks.";

        private const string SuccessfullyImportedClient
            = "Successfully imported client - {0} with {1} trucks.";

        public static string ImportDespatcher(TrucksContext context, string xmlString)
        {
            var output = new StringBuilder();

            ImportDespatcherDTO[]? despatcherDTOs = 
                Deserialize<ImportDespatcherDTO[]>("Despatchers", xmlString);

            if (despatcherDTOs == null)
                return ErrorMessage;

            List<Despatcher> despatchers = new List<Despatcher>();

            foreach (var dDto in despatcherDTOs)
            {
                if (!IsValid(dDto) || string.IsNullOrEmpty(dDto.Position))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                Despatcher despatcher = new Despatcher
                {
                    Name = dDto.Name,
                    Position = dDto.Position
                };

                foreach (var tDto in dDto.Trucks)
                {
                    if (!IsValid(tDto))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    despatcher.Trucks.Add(new Truck
                    {
                        RegistrationNumber = tDto.RegistrationNumber,
                        VinNumber = tDto.VinNumber,
                        TankCapacity = tDto.TankCapacity,
                        CargoCapacity = tDto.CargoCapacity,
                        CategoryType = Enum.Parse<CategoryType>(tDto.CategoryType),
                        MakeType = Enum.Parse<MakeType>(tDto.MakeType)
                    });
                }

                despatchers.Add(despatcher);
                output.AppendLine(string.Format(SuccessfullyImportedDespatcher, despatcher.Name, despatcher.Trucks.Count));
            }

            context.Despatchers.AddRange(despatchers);
            context.SaveChanges();

            return output.ToString().TrimEnd();
        }

        public static string ImportClient(TrucksContext context, string jsonString)
        {
            var output = new StringBuilder();

            ImportClientDTO[]? clientDTOs = 
                JsonConvert.DeserializeObject<ImportClientDTO[]>(jsonString);

            if (clientDTOs == null)
                return ErrorMessage;

            List<Client> clientList = new List<Client>();

            foreach (var clientDTO in clientDTOs)
            {
                if (!IsValid(clientDTO) || clientDTO.Type == "usual")
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                Client client = new Client
                {
                    Name = clientDTO.Name,
                    Nationality = clientDTO.Nationality,
                    Type = clientDTO.Type
                };

                clientList.Add(client);
                int[] trucksIds = context.Trucks.Select(t => t.Id).ToArray();

                foreach (var tId in clientDTO.Trucks.Distinct())
                {
                    if (!trucksIds.Contains(tId))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    client.ClientsTrucks.Add(new ClientTruck { TruckId = tId });
                }

                output.AppendLine(string.Format(
                    SuccessfullyImportedClient, client.Name, client.ClientsTrucks.Count));
            }

            context.Clients.AddRange(clientList);
            context.SaveChanges();

            return output.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }

        private static T? Deserialize<T>(string root, string xmlString)
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), new XmlRootAttribute(root));

			using StringReader stringReader = new StringReader(xmlString);

			return (T?)xmlSerializer.Deserialize(stringReader);
		}
    }
}