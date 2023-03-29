namespace Theatre.DataProcessor
{
	using Newtonsoft.Json;
	using System.Text;
	using System.Xml.Serialization;
	using Theatre.Data;
	using Theatre.DataProcessor.ExportDto;

	public class Serializer
	{
        public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
        {
			var theatres = context.Theatres
				.ToArray()
				.Where(t => t.NumberOfHalls >= numbersOfHalls && t.Tickets.Count >= 20)
				.Select(t => new
				{
					t.Name,
					Halls = t.NumberOfHalls,
					TotalIncome = t.Tickets
						.Where(ti => ti.RowNumber >= 1 && ti.RowNumber <= 5)
						.Sum(ti => ti.Price),
					Tickets = t.Tickets
						.Where(ti => ti.RowNumber >= 1 && ti.RowNumber <= 5)
						.Select(ti => new
						{
							ti.Price,
							ti.RowNumber
						})
						.OrderByDescending(ti => ti.Price)
				})
				.OrderByDescending(t => t.Halls)
				.ThenBy(t => t.Name)
				.ToArray();

			return JsonConvert.SerializeObject(theatres, Formatting.Indented);
        }

        public static string ExportPlays(TheatreContext context, double raiting)
        {
			ExportPlayDTO[] playDTOs = context.Plays
				.ToArray()
				.Where(p => p.Rating <= raiting)
				.Select(p => new ExportPlayDTO
				{
					Title = p.Title,
					Duration = p.Duration.ToString("c"),
					Rating = p.Rating == 0 ? "Premier" : p.Rating.ToString(),
					Genre = p.Genre.ToString(),
					Actors = p.Casts
						.Where(a => a.IsMainCharacter)
						.Select(a => new ExportActorDTO
						{
							FullName = a.FullName,
							MainCharacter = $"Plays main character in '{p.Title}'."
						})
						.OrderByDescending(a => a.FullName)
						.ToArray()
				})
				.OrderBy(p => p.Title)
				.ThenByDescending(p => p.Genre)
				.ToArray();

			return Serialize(playDTOs, "Plays");
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
