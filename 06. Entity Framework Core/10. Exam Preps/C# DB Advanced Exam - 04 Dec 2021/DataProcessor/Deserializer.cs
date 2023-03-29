namespace Theatre.DataProcessor
{
	using Newtonsoft.Json;
	using System.ComponentModel.DataAnnotations;
	using System.Globalization;
	using System.Text;
	using System.Xml.Serialization;
	using Theatre.Data;
	using Theatre.Data.Models;
	using Theatre.Data.Models.Enums;
	using Theatre.DataProcessor.ImportDto;

	public class Deserializer
	{
		private const string ErrorMessage = "Invalid data!";

		private const string SuccessfulImportPlay
			= "Successfully imported {0} with genre {1} and a rating of {2}!";

		private const string SuccessfulImportActor
			= "Successfully imported actor {0} as a {1} character!";

		private const string SuccessfulImportTheatre
			= "Successfully imported theatre {0} with #{1} tickets!";



		public static string ImportPlays(TheatreContext context, string xmlString)
		{
			var output = new StringBuilder();

			ImportPlayDTO[]? playDTOs = Deserialize<ImportPlayDTO[]>("Plays", xmlString);

			if (playDTOs == null)
				return ErrorMessage;

			List<Play> playEntities = new List<Play>();

			foreach (var playDTO in playDTOs)
			{
				if (!IsValid(playDTO))
				{
					output.AppendLine(ErrorMessage);
					continue;
				}

				try
				{
					Play playEntity = new Play
					{
						Title = playDTO.Title,
						Duration = TimeSpan.ParseExact(playDTO.Duration, "c", CultureInfo.InvariantCulture),
						Rating = playDTO.Rating, //float.Parse(playDTO.Rating),
						Genre = Enum.Parse<Genre>(playDTO.Genre),
						Description = playDTO.Description,
						Screenwriter = playDTO.Screenwriter
					};

					if (!IsValid(playEntity) || playEntity.Duration.TotalHours < 1)
					{
						output.AppendLine(ErrorMessage);
						continue;
					}

					playEntities.Add(playEntity);
					output.AppendLine(string.Format(SuccessfulImportPlay, playEntity.Title, 
													playEntity.Genre, playEntity.Rating));
				}
				catch (Exception)
				{
					output.AppendLine(ErrorMessage);
					continue;
				}
			}

			context.Plays.AddRange(playEntities);
			context.SaveChanges();

			return output.ToString().TrimEnd();
		}

		public static string ImportCasts(TheatreContext context, string xmlString)
		{
			var output = new StringBuilder();

			ImportCastDTO[]? castDTOs = Deserialize<ImportCastDTO[]>("Casts", xmlString);

			if (castDTOs == null)
				return ErrorMessage;

			List<Cast> castEntities = new List<Cast>();

			foreach (var castDTO in castDTOs)
			{
				if (!IsValid(castDTO))
				{
					output.AppendLine(ErrorMessage);
					continue;
				}

				Cast castEntity = new Cast
				{
					FullName = castDTO.FullName,
					IsMainCharacter = castDTO.IsMainCharacter,
					PhoneNumber = castDTO.PhoneNumber,
					PlayId = castDTO.PlayId
				};

				if (!IsValid(castEntity))
				{
					output.AppendLine(ErrorMessage);
					continue;
				}

				castEntities.Add(castEntity);
				output.AppendLine(string.Format(SuccessfulImportActor, castEntity.FullName, 
												castEntity.IsMainCharacter ? "main" : "lesser"));
			}

			context.AddRange(castEntities);
			context.SaveChanges();

			return output.ToString().TrimEnd();
		}

		public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
		{
			var output = new StringBuilder();

			ImportTheatreDTO[]? theatreDTOs = 
				JsonConvert.DeserializeObject<ImportTheatreDTO[]>(jsonString);

			if (theatreDTOs == null)
				return ErrorMessage;

			List<Theatre> theatreEntities = new List<Theatre>();

            foreach (var theatreDTO in theatreDTOs)
            {
				if (!IsValid(theatreDTO))
				{
					output.AppendLine(ErrorMessage);
					continue;
				}

				Theatre theatreEntity = new Theatre
				{
					Name = theatreDTO.Name,
					NumberOfHalls = theatreDTO.NumberOfHalls,
					Director = theatreDTO.Director,
					Tickets = new List<Ticket>()
				};

				if (!IsValid(theatreEntity))
				{
					output.AppendLine(ErrorMessage);
					continue;
				}

				foreach (var ticketDTO in theatreDTO.Tickets)
				{
					Ticket ticketEntity = new Ticket
					{
						Price = ticketDTO.Price,
						RowNumber = ticketDTO.RowNumber,
						PlayId = ticketDTO.PlayId
					};

					if (!IsValid(ticketEntity))
					{
						output.AppendLine(ErrorMessage);
						continue;
					}

					theatreEntity.Tickets.Add(ticketEntity);
				}

				theatreEntities.Add(theatreEntity);
				output.AppendLine(string.Format(SuccessfulImportTheatre, theatreEntity.Name, theatreEntity.Tickets.Count));
            }

			context.Theatres.AddRange(theatreEntities);
			context.SaveChanges();

			return output.ToString().TrimEnd();
        }


		private static bool IsValid(object obj)
		{
			var validator = new ValidationContext(obj);
			var validationRes = new List<ValidationResult>();

			var result = Validator.TryValidateObject(obj, validator, validationRes, true);
			return result;
		}

		private static T? Deserialize<T>(string root, string xmlString)
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), new XmlRootAttribute(root));

			using StringReader stringReader = new StringReader(xmlString);

			return (T?)xmlSerializer.Deserialize(stringReader);
		}
	}
}
