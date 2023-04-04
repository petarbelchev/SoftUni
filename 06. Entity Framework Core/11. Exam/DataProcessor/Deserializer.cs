namespace Boardgames.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
	using System.Text;
	using System.Xml.Serialization;
	using Boardgames.Data;
	using Boardgames.Data.Models;
	using Boardgames.Data.Models.Enums;
	using Boardgames.DataProcessor.ImportDto;
	using Newtonsoft.Json;

	public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCreator
            = "Successfully imported creator – {0} {1} with {2} boardgames.";

        private const string SuccessfullyImportedSeller
            = "Successfully imported seller - {0} with {1} boardgames.";

        public static string ImportCreators(BoardgamesContext context, string xmlString)
        {
            var output = new StringBuilder();

            ImportCreatorDTO[]? creatorDTOs = 
                Deserialize<ImportCreatorDTO[]>("Creators", xmlString);

            if (creatorDTOs == null)
                return ErrorMessage;

            List<Creator> creatorList = new List<Creator>();

            foreach (var creatorDTO in creatorDTOs)
            {
                if (!IsValid(creatorDTO))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                Creator creator = new Creator
                {
                    FirstName = creatorDTO.FirstName,
                    LastName = creatorDTO.LastName
                };

                foreach (var bDto in creatorDTO.Boardgames)
                {
                    if (!IsValid(bDto))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    creator.Boardgames.Add(new Boardgame
                    {
                        Name = bDto.Name,
                        Rating = bDto.Rating,
                        YearPublished = bDto.YearPublished,
                        CategoryType = Enum.Parse<CategoryType>(bDto.CategoryType),
                        Mechanics = bDto.Mechanics
                    });
                }

                creatorList.Add(creator);
                output.AppendLine(string.Format(
                    SuccessfullyImportedCreator, creator.FirstName, creator.LastName, creator.Boardgames.Count));
            }

            context.Creators.AddRange(creatorList);
            context.SaveChanges();

            return output.ToString().TrimEnd();
        }

        public static string ImportSellers(BoardgamesContext context, string jsonString)
        {
            var output = new StringBuilder();

            ImportSellerDTO[]? sellerDTOs = JsonConvert.DeserializeObject<ImportSellerDTO[]>(jsonString);

            if (sellerDTOs == null)
                return ErrorMessage;

            List<Seller> sellerList = new List<Seller>();

            foreach (var sDto in sellerDTOs)
            {
                if (!IsValid(sDto) || string.IsNullOrWhiteSpace(sDto.Country))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                Seller seller = new Seller
                {
                    Name = sDto.Name,
                    Address = sDto.Address,
                    Country = sDto.Country,
                    Website = sDto.Website
                };

                int[] boardgamesIds = context.Boardgames.Select(b => b.Id).ToArray();

                foreach (var bId in sDto.Boardgames.Distinct())
                {
                    if (!boardgamesIds.Contains(bId))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    seller.BoardgamesSellers.Add(new BoardgameSeller { BoardgameId = bId });
                }

                sellerList.Add(seller);
                output.AppendLine(string.Format(
                    SuccessfullyImportedSeller, seller.Name, seller.BoardgamesSellers.Count));
            }

            context.Sellers.AddRange(sellerList);
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
