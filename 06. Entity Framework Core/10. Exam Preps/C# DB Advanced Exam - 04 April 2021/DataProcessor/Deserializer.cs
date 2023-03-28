// ReSharper disable InconsistentNaming

namespace TeisterMask.DataProcessor
{
	using Data;
	using Newtonsoft.Json;
	using System.ComponentModel.DataAnnotations;
	using System.Globalization;
	using System.Text;
	using System.Xml.Serialization;
	using TeisterMask.Data.Models;
	using TeisterMask.Data.Models.Enums;
	using TeisterMask.DataProcessor.ImportDto;
	using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

	public class Deserializer
	{
		private const string ErrorMessage = "Invalid data!";

		private const string SuccessfullyImportedProject
			= "Successfully imported project - {0} with {1} tasks.";

		private const string SuccessfullyImportedEmployee
			= "Successfully imported employee - {0} with {1} tasks.";

		public static string ImportProjects(TeisterMaskContext context, string xmlString)
		{
			StringBuilder result = new StringBuilder();

			ImportProjectDTO[]? projectDTOs = Deserialize<ImportProjectDTO>("Projects", xmlString);

			if (projectDTOs == null)
				return ErrorMessage;

			List<Project> validProjects = new List<Project>();

			foreach (var projectDTO in projectDTOs)
			{
				if (!IsValid(projectDTO))
				{
					result.AppendLine(ErrorMessage);
					continue;
				}

				if (!DateTime.TryParseExact(
					projectDTO.OpenDate, "dd/MM/yyyy",
					CultureInfo.InvariantCulture,
					DateTimeStyles.None,
					out DateTime projectOpenDate))
				{
					result.AppendLine(ErrorMessage);
					continue;
				}

				bool isProjectDueDateValid = DateTime.TryParseExact(
					projectDTO.DueDate,
					"dd/MM/yyyy",
					CultureInfo.InvariantCulture,
					DateTimeStyles.None,
					out DateTime projectDueDate);

				Project projectEntity = new Project
				{
					Name = projectDTO.Name,
					OpenDate = projectOpenDate,
					DueDate = isProjectDueDateValid ? projectDueDate : null,
					Tasks = new List<Task>()
				};

				foreach (var taskDTO in projectDTO.Tasks)
				{
					bool isTaskOpenDateValid = DateTime.TryParseExact(
						taskDTO.OpenDate, "dd/MM/yyyy",
						CultureInfo.InvariantCulture, DateTimeStyles.None,
						out DateTime taskOpenDate);

					bool isTaskDueDateValid = DateTime.TryParseExact(
						taskDTO.DueDate, "dd/MM/yyyy",
						CultureInfo.InvariantCulture, DateTimeStyles.None,
						out DateTime taskDueDate);

					if (!IsValid(taskDTO) || !isTaskOpenDateValid || !isTaskDueDateValid)
					{
						result.AppendLine(ErrorMessage);
						continue;
					}

					if (projectEntity.OpenDate > taskOpenDate
						|| (projectEntity.DueDate != null && projectEntity.DueDate < taskDueDate))
					{
						result.AppendLine(ErrorMessage);
						continue;
					}

					projectEntity.Tasks.Add(new Task
					{
						Name = taskDTO.Name,
						OpenDate = taskOpenDate,
						DueDate = taskDueDate,
						ExecutionType = (ExecutionType)taskDTO.ExecutionType,
						LabelType = (LabelType)taskDTO.LabelType
					});
				}

				validProjects.Add(projectEntity);
				result.AppendLine(string.Format(SuccessfullyImportedProject, projectEntity.Name, projectEntity.Tasks.Count));
			}

			context.Projects.AddRange(validProjects);
			context.SaveChanges();
			return result.ToString().TrimEnd();
		}

		public static string ImportEmployees(TeisterMaskContext context, string jsonString)
		{
			StringBuilder result = new StringBuilder();
			ImportEmployeeDTO[]? employeeDTOs = JsonConvert.DeserializeObject<ImportEmployeeDTO[]>(jsonString);

			if (employeeDTOs == null)
			{
				return ErrorMessage;
			}

			List<Employee> validEmployees = new List<Employee>();

			foreach (var empDTO in employeeDTOs)
			{
				if (!IsValid(empDTO))
				{
					result.AppendLine(ErrorMessage);
					continue;
				}

				Employee employeeEntity = new Employee
				{
					Username = empDTO.Username,
					Email = empDTO.Email,
					Phone = empDTO.Phone,
					EmployeesTasks = new List<EmployeeTask>()
				};

				foreach (var taskId in empDTO.Tasks.Distinct())
				{
					Task? task = context.Tasks.Find(taskId);

					if (task == null)
					{
						result.AppendLine(ErrorMessage);
						continue;
					}

					employeeEntity.EmployeesTasks.Add(new EmployeeTask { Task = task });
				}

				validEmployees.Add(employeeEntity);
				result.AppendLine(string.Format(SuccessfullyImportedEmployee, employeeEntity.Username, employeeEntity.EmployeesTasks.Count));
			}

			context.Employees.AddRange(validEmployees);
			context.SaveChanges();
			return result.ToString().TrimEnd();
		}

		private static bool IsValid(object dto)
		{
			var validationContext = new ValidationContext(dto);
			var validationResult = new List<ValidationResult>();

			return Validator.TryValidateObject(dto, validationContext, validationResult, true);
		}

		private static T[]? Deserialize<T>(string root, string xmlString)
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(T[]), new XmlRootAttribute(root));

			using StringReader stringReader = new StringReader(xmlString);

			return (T[]?)xmlSerializer.Deserialize(stringReader);
		}
	}
}