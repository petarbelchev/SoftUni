namespace Boardgames.DataProcessor
{
    using Boardgames.Data;
	using Boardgames.DataProcessor.ExportDto;
	using Newtonsoft.Json;
	using System.Text;
	using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportCreatorsWithTheirBoardgames(BoardgamesContext context)
        {
			var creators = context.Creators
				.Where(c => c.Boardgames.Any())
				.ToArray()
				.Select(c => new ExportCreatorDTO
				{
					CreatorName = $"{c.FirstName} {c.LastName}",
					BoardgamesCount = c.Boardgames.Count(),
					Boardgames = c.Boardgames.Select(b => new ExportBoardgameDTO
					{
						BoardgameName = b.Name,
						BoardgameYearPublished = b.YearPublished
					})
					.OrderBy(b => b.BoardgameName)
					.ToArray()
				})
				.OrderByDescending(b => b.BoardgamesCount)
				.ThenBy(b => b.CreatorName)
				.ToList();

			return Serialize(creators, "Creators");
        }

        public static string ExportSellersWithMostBoardgames(BoardgamesContext context, int year, double rating)
        {
			var sellers = context.Sellers
				.Where(s => s.BoardgamesSellers.Any(bs => bs.Boardgame.YearPublished >= year && bs.Boardgame.Rating <= rating))
				.ToArray()
				.Select(s => new
				{
					s.Name,
					s.Website,
					Boardgames = s.BoardgamesSellers
						.Where(bs => bs.Boardgame.YearPublished >= year && bs.Boardgame.Rating <= rating)
						.Select(bs => new
						{
							bs.Boardgame.Name,
							bs.Boardgame.Rating,
							bs.Boardgame.Mechanics,
							Category = bs.Boardgame.CategoryType.ToString(),
						})
						.OrderByDescending(b => b.Rating)
						.ThenBy(b => b.Name)
				})
				.OrderByDescending(s => s.Boardgames.Count())
				.ThenBy(s => s.Name)
				.Take(5)
				.ToArray();

			return JsonConvert.SerializeObject(sellers, Formatting.Indented);
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