namespace SoftJail.DataProcessor
{
	using Data;
	using Newtonsoft.Json;
	using SoftJail.DataProcessor.ExportDto;
	using System.Text;
	using System.Xml.Serialization;

	public class Serializer
	{
		public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
		{
			ExportPrisonerDto[] prisonerDtos = context.Prisoners
				.Where(p => ids.Contains(p.Id))
				.Select(p => new ExportPrisonerDto
				{
					Id = p.Id,
					Name = p.FullName,
					CellNumber = p.Cell.CellNumber,
					Officers = p.PrisonerOfficers
						.OrderBy(po => po.Officer.FullName)
						.Select(po => new ExportPrisonerOfficerDto
						{
							Department = po.Officer.Department.Name,
							OfficerName = po.Officer.FullName
						}),
					TotalOfficerSalary = Math.Round(p.PrisonerOfficers.Sum(po => po.Officer.Salary), 2)
				})
				.OrderBy(p => p.Name)
				.ThenBy(p => p.Id)
				.ToArray();

			return JsonConvert.SerializeObject(prisonerDtos, Formatting.Indented);
		}

		public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
		{
			string[] names = prisonersNames.Split(',');

			ExportPrisonerInboxDto[] prisonerInboxDtos = context.Prisoners
				.Where(p => names.Contains(p.FullName))
				.Select(p => new ExportPrisonerInboxDto
				{
					Id = p.Id,
					Name = p.FullName,
					IncarcerationDate = p.IncarcerationDate.ToString("yyyy-MM-dd"),
					EncryptedMessages = p.Mails.Select(m => new ExportMessageDto
					{
						Description = string.Join("", m.Description.Reverse()),
					}).ToArray()
				})
				.OrderBy(p => p.Name)
				.ThenBy(p => p.Id)
				.ToArray();

			XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportPrisonerInboxDto[]), new XmlRootAttribute("Prisoners"));
			StringBuilder result = new StringBuilder();
			var xsn =  new XmlSerializerNamespaces();
			xsn.Add(string.Empty, string.Empty);

			using (StringWriter writer = new StringWriter(result))
			{
				xmlSerializer.Serialize(writer, prisonerInboxDtos, xsn);
			}

			return result.ToString().TrimEnd();
		}
	}
}