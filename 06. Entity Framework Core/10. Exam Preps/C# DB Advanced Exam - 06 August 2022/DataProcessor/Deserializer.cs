namespace Footballers.DataProcessor
{
	using Footballers.Data;
	using Footballers.Data.Models;
	using Footballers.Data.Models.Enums;
	using Footballers.DataProcessor.ImportDto;
	using Newtonsoft.Json;
	using System.ComponentModel.DataAnnotations;
	using System.Globalization;
	using System.Text;
	using System.Xml.Serialization;

	public class Deserializer
	{
		private const string ErrorMessage = "Invalid data!";

		private const string SuccessfullyImportedCoach
			= "Successfully imported coach - {0} with {1} footballers.";

		private const string SuccessfullyImportedTeam
			= "Successfully imported team - {0} with {1} footballers.";

		public static string ImportCoaches(FootballersContext context, string xmlString)
		{
			var output = new StringBuilder();
			ImportCoachDTO[]? coachDTOs = Deserialize<ImportCoachDTO[]>("Coaches", xmlString);

			if (coachDTOs == null)
				return ErrorMessage;

			List<Coach> coachList = new List<Coach>();

			foreach (var cDto in coachDTOs)
			{
				if (!IsValid(cDto) || string.IsNullOrEmpty(cDto.Nationality))
				{
					output.AppendLine(ErrorMessage);
					continue;
				}

				Coach coach = new Coach
				{
					Name = cDto.Name,
					Nationality = cDto.Nationality
				};

				foreach (var fDto in cDto.Footballers)
				{
					bool isStartDateValid = DateTime.TryParseExact(
						fDto.ContractStartDate, "dd/MM/yyyy",
						CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime startDate);

					bool isEndDateValid = DateTime.TryParseExact(
						fDto.ContractEndDate, "dd/MM/yyyy",
						CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime endDate);

					if (!IsValid(fDto) || !isStartDateValid || !isEndDateValid
						|| startDate > endDate)
					{
						output.AppendLine(ErrorMessage);
						continue;
					}

					Footballer footballer = new Footballer
					{
						Name = fDto.Name,
						ContractStartDate = startDate,
						ContractEndDate = endDate,
						PositionType = Enum.Parse<PositionType>(fDto.PositionType),
						BestSkillType = Enum.Parse<BestSkillType>(fDto.BestSkillType)
					};

					coach.Footballers.Add(footballer);
				}

				coachList.Add(coach);
				output.AppendLine(string.Format(SuccessfullyImportedCoach, coach.Name, coach.Footballers.Count));
			}
			context.Coaches.AddRange(coachList);
			context.SaveChanges();

			return output.ToString().TrimEnd();
		}

		public static string ImportTeams(FootballersContext context, string jsonString)
		{
			var output = new StringBuilder();

			ImportTeamDTO[]? teamDTOs = JsonConvert.DeserializeObject<ImportTeamDTO[]>(jsonString);

			if (teamDTOs == null)
				return ErrorMessage;

			List<Team> teamList = new List<Team>();

			foreach (var tDto in teamDTOs)
			{
				if (!IsValid(tDto))
				{
					output.AppendLine(ErrorMessage);
					continue;
				}

				Team team = new Team
				{
					Name = tDto.Name,
					Nationality = tDto.Nationality,
					Trophies = tDto.Trophies
				};

				teamList.Add(team);
				int[] footballersIds = context.Footballers.Select(f => f.Id).ToArray();

				foreach (var fId in tDto.Footballers.Distinct())
				{
					if (!footballersIds.Contains(fId))
					{
						output.AppendLine(ErrorMessage);
						continue;
					}

					team.TeamsFootballers.Add(new TeamFootballer { FootballerId = fId });
				}

				output.AppendLine(string.Format(SuccessfullyImportedTeam, team.Name, team.TeamsFootballers.Count));
			}
			context.Teams.AddRange(teamList);
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
