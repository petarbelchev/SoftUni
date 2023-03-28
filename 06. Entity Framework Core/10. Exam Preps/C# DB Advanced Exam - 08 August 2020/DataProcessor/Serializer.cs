namespace VaporStore.DataProcessor
{
	using Data;
	using Microsoft.EntityFrameworkCore;
	using Newtonsoft.Json;
	using System.Globalization;
	using System.Text;
	using System.Xml.Serialization;
	using VaporStore.Data.Models.Enums;
	using VaporStore.DataProcessor.ExportDto;

	public static class Serializer
	{
		public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
		{
			ExportGamesByGenresDTO[] genreDTOs = context.Genres
				.Where(g => genreNames.Contains(g.Name))
				.Include(g => g.Games)
				.ThenInclude(g => g.Purchases)
				.ToArray()
				.Select(g => new ExportGamesByGenresDTO
				{
					Id = g.Id,
					Genre = g.Name,
					Games = g.Games
						.Where(g => g.Purchases.Any())
						.Select(g => new ExportGameDTO
						{
							Id = g.Id,
							Title = g.Name,
							Developer = g.Developer.Name,
							Players = g.Purchases.Count,
							Tags = string.Join(", ", g.GameTags.Select(gt => gt.Tag.Name))
						})
						.OrderByDescending(g => g.Players)
						.ThenBy(g => g.Id)
						.ToList(),
					TotalPlayers = g.Games
						.Where(g => g.Purchases.Any())
						.Sum(g => g.Purchases.Count())
				})
				.OrderByDescending(g => g.TotalPlayers)
				.ThenBy(g => g.Id)
				.ToArray();

			string output = JsonConvert.SerializeObject(genreDTOs, Formatting.Indented);

			return output;
		}

		public static string ExportUserPurchasesByType(VaporStoreDbContext context, string purchaseType)
		{
			ExportUserPurchasesByType[] userDTOs = context.Users
				.Where(u => u.Cards.Any(c => c.Purchases.Any(p => p.Type == Enum.Parse<PurchaseType>(purchaseType))))
				.Select(u => new ExportUserPurchasesByType
				{
					Username = u.Username,
					Purchases = u.Cards.SelectMany(u => u.Purchases.Where(p => p.Type == Enum.Parse<PurchaseType>(purchaseType)))
						.OrderBy(p => p.Date)
						.Select(p => new ExportPurchaseDTO
						{
							Card = p.Card.Number,
							Cvc = p.Card.Cvc,
							Date = p.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
							Game = new ExportXmlGameDTO
							{
								Title = p.Game.Name,
								Price = p.Game.Price,
								Genre = p.Game.Genre.Name
							}
						})
						.ToArray(),
					TotalSpent = u.Cards.SelectMany(u => u.Purchases.Where(p => p.Type == Enum.Parse<PurchaseType>(purchaseType))).Sum(p => p.Game.Price)
				})
				.OrderByDescending(u => u.TotalSpent)
				.ThenBy(u => u.Username)
				.ToArray();

			StringBuilder sb = new StringBuilder();
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportUserPurchasesByType[]), new XmlRootAttribute("Users"));
			XmlSerializerNamespaces xsn = new XmlSerializerNamespaces();
			xsn.Add(string.Empty, string.Empty);

			using (StringWriter writer = new StringWriter(sb))
			{
				xmlSerializer.Serialize(writer, userDTOs, xsn);
			}

			return sb.ToString().TrimEnd();
		}
	}
}