namespace SoftJail.DataProcessor
{
	using AutoMapper;
	using Data;
	using Newtonsoft.Json;
	using SoftJail.Data.Models;
	using SoftJail.DataProcessor.ImportDto;
	using System.ComponentModel.DataAnnotations;
	using System.Text;
	using System.Xml.Serialization;

	public class Deserializer
	{
		private const string ErrorMessage = "Invalid Data";

		private const string SuccessfullyImportedDepartment = "Imported {0} with {1} cells";

		private const string SuccessfullyImportedPrisoner = "Imported {0} {1} years old";

		private const string SuccessfullyImportedOfficer = "Imported {0} ({1} prisoners)";

		public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
		{
			StringBuilder result = new StringBuilder();
			var departments = JsonConvert.DeserializeObject<ImportDepartmentsDto[]>(jsonString);
			var validDepartments = new List<ImportDepartmentsDto>();

			if (departments != null)
			{
				foreach (var d in departments)
				{
					if (!IsValid(d) || !d.Cells.Any())
					{
						result.AppendLine(ErrorMessage);
						continue;
					}

					if (d.Cells.Any(c => !IsValid(c)))
					{
						result.AppendLine(ErrorMessage);
						continue;
					}

					validDepartments.Add(d);
					result.AppendLine(string.Format(SuccessfullyImportedDepartment, d.Name, d.Cells.Count()));
				}

				IMapper mapper = new MapperConfiguration(cfg => cfg.AddProfile<SoftJailProfile>()).CreateMapper();
				Department[] departmentsEntities = validDepartments.Select(d => mapper.Map<Department>(d)).ToArray();

				context.AddRange(departmentsEntities);
				context.SaveChanges();
			}
			else
			{
				return ErrorMessage;
			}

			return result.ToString().TrimEnd();
		}

		public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
		{
			StringBuilder result = new StringBuilder();
			var prisoners = JsonConvert.DeserializeObject<ImportPrisonerDto[]>(jsonString);
			List<ImportPrisonerDto> validPrisoners = new List<ImportPrisonerDto>();

			if (prisoners != null)
			{
				foreach (var prisoner in prisoners)
				{
					if (!IsValid(prisoner))
					{
						result.AppendLine(ErrorMessage);
						continue;
					}

					if (prisoner.Mails.Any(m => !IsValid(m)))
					{
						result.AppendLine(ErrorMessage);
						continue;
					}

					validPrisoners.Add(prisoner);
					result.AppendLine(string.Format(SuccessfullyImportedPrisoner, prisoner.FullName, prisoner.Age));
				}

				IMapper mapper = new MapperConfiguration(cfg => cfg.AddProfile<SoftJailProfile>()).CreateMapper();
				var prisonerEntities = validPrisoners.Select(p => mapper.Map<Prisoner>(p)).ToArray();

				context.AddRange(prisonerEntities);
				context.SaveChanges();
			}
			else
			{
				result.AppendLine(ErrorMessage);
			}

			return result.ToString().TrimEnd();
		}

		public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
		{
			StringBuilder result = new StringBuilder();
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportOfficerDto[]), new XmlRootAttribute("Officers"));
			ImportOfficerDto[]? officerDtos = (ImportOfficerDto[]?)xmlSerializer.Deserialize(new StringReader(xmlString));

			if (officerDtos != null)
			{
				IMapper mapper = new MapperConfiguration(cfg => cfg.AddProfile<SoftJailProfile>()).CreateMapper();
				List<Officer> officerEntities = new List<Officer>();

				foreach (var officerDto in officerDtos)
				{
					try
					{
						Officer officerEntity = mapper.Map<Officer>(officerDto);
						officerEntities.Add(officerEntity);
						result.AppendLine(string.Format(SuccessfullyImportedOfficer, 
														officerEntity.FullName, 
														officerEntity.OfficerPrisoners.Count()));
					}
					catch (Exception)
					{
						result.AppendLine(ErrorMessage);
						continue;
					}
				}

				context.AddRange(officerEntities);
				context.SaveChanges();
				return result.ToString().TrimEnd();
			}
			else
			{
				return ErrorMessage;
			}
		}

		private static bool IsValid(object obj)
		{
			var validationContext = new ValidationContext(obj);
			var validationResult = new List<ValidationResult>();

			bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
			return isValid;
		}
	}
}