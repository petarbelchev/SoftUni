namespace VaporStore.DataProcessor
{
	using Data;
	using Newtonsoft.Json;
	using System.ComponentModel.DataAnnotations;
	using System.Globalization;
	using System.Text;
	using System.Xml.Serialization;
	using VaporStore.Data.Models;
	using VaporStore.Data.Models.Enums;
	using VaporStore.DataProcessor.ImportDto;

	public static class Deserializer
	{
		public const string ErrorMessage = "Invalid Data";

		public const string SuccessfullyImportedGame = "Added {0} ({1}) with {2} tags";

		public const string SuccessfullyImportedUser = "Imported {0} with {1} cards";

		public const string SuccessfullyImportedPurchase = "Imported {0} for {1}";

		public static string ImportGames(VaporStoreDbContext context, string jsonString)
		{
			ImportGameDTO[]? gamesDTOs = JsonConvert.DeserializeObject<ImportGameDTO[]>(jsonString);
			StringBuilder result = new StringBuilder();

			if (gamesDTOs == null)
				return ErrorMessage;

			foreach (var gameDTO in gamesDTOs)
			{
				if (!IsValid(gameDTO) || !gameDTO.Tags.Any())
				{
					result.AppendLine(ErrorMessage);
					continue;
				}

				Game gameEntity = new Game
				{
					Name = gameDTO.Name,
					Price = gameDTO.Price,
					ReleaseDate = DateTime.ParseExact(gameDTO.ReleaseDate, "yyyy-MM-dd", CultureInfo.InvariantCulture)
				};

				Developer? developer = context.Developers.FirstOrDefault(d => d.Name == gameDTO.Developer);

				if (developer == null)
					developer = new Developer { Name = gameDTO.Developer };

				gameEntity.Developer = developer;

				Genre? genre = context.Genres.FirstOrDefault(g => g.Name == gameDTO.Genre);

				if (genre == null)
					genre = new Genre { Name = gameDTO.Genre };

				gameEntity.Genre = genre;

				foreach (var tagDTO in gameDTO.Tags)
				{
					Tag? tag = context.Tags.FirstOrDefault(t => t.Name == tagDTO);

					if (tag == null)
						tag = new Tag { Name = tagDTO };

					gameEntity.GameTags.Add(new GameTag { Tag = tag });
				}

				context.Add(gameEntity);
				context.SaveChanges();
				result.AppendLine(string.Format(SuccessfullyImportedGame, gameEntity.Name, gameEntity.Genre.Name, gameEntity.GameTags.Count));
			}

			return result.ToString().TrimEnd();
		}

		public static string ImportUsers(VaporStoreDbContext context, string jsonString)
		{
			ImportUserDTO[]? userDTOs = JsonConvert.DeserializeObject<ImportUserDTO[]>(jsonString);
			StringBuilder result = new StringBuilder();

			if (userDTOs == null)
				return ErrorMessage;

			foreach (var userDTO in userDTOs)
			{
				if (!IsValid(userDTO))
				{
					result.AppendLine(ErrorMessage);
					continue;
				}

				User userEntity = new User
				{
					FullName = userDTO.FullName,
					Age = userDTO.Age,
					Username = userDTO.Username,
					Email = userDTO.Email,
					Cards = userDTO.Cards.Select(c => new Card
					{
						Number = c.Number,
						Cvc = c.Cvc,
						Type = Enum.Parse<CardType>(c.Type)
					})
					.ToList()
				};

				context.Users.Add(userEntity);
				result.AppendLine(string.Format(SuccessfullyImportedUser, userEntity.Username, userEntity.Cards.Count));
			}

			context.SaveChanges();

			return result.ToString().TrimEnd();
		}

		public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
		{
			StringBuilder result = new StringBuilder();
			XmlSerializer xmlSerializer =
				new XmlSerializer(typeof(ImportPurchaseDTO[]), new XmlRootAttribute("Purchases"));

			ImportPurchaseDTO[]? purchaseDTOs =
				(ImportPurchaseDTO[]?)xmlSerializer.Deserialize(new StringReader(xmlString));

			if (purchaseDTOs == null)
				return ErrorMessage;

			foreach (var purchaseDTO in purchaseDTOs)
			{
				if (!IsValid(purchaseDTO))
					result.AppendLine(ErrorMessage);

				Purchase purchaseEntity = new Purchase
				{
					Type = Enum.Parse<PurchaseType>(purchaseDTO.Type),
					ProductKey = purchaseDTO.ProductKey,
					Date = DateTime.ParseExact(purchaseDTO.Date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture),
					Card = context.Cards.First(c => c.Number == purchaseDTO.Card),
					Game = context.Games.First(g => g.Name == purchaseDTO.Game)
				};

				string username = context.Users
					.First(u => u.Cards.Any(c => c.Number == purchaseEntity.Card.Number))
					.Username;

				context.Purchases.Add(purchaseEntity);
				result.AppendLine(string.Format(SuccessfullyImportedPurchase, purchaseEntity.Game.Name, username));
			}

			context.SaveChanges();
			return result.ToString().TrimEnd();
		}

		private static bool IsValid(object dto)
		{
			var validationContext = new ValidationContext(dto);
			var validationResult = new List<ValidationResult>();

			return Validator.TryValidateObject(dto, validationContext, validationResult, true);
		}
	}
}