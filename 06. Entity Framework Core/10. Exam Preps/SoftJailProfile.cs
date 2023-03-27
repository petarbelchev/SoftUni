namespace SoftJail
{
	using AutoMapper;
	using SoftJail.Data.Models;
	using SoftJail.DataProcessor.ExportDto;
	using SoftJail.DataProcessor.ImportDto;
	using System.Globalization;

	public class SoftJailProfile : Profile
	{
		// Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE THIS CLASS
		public SoftJailProfile()
		{
			CreateMap<ImportCellDto, Cell>();
			CreateMap<ImportDepartmentsDto, Department>();

			CreateMap<ImportMailDto, Mail>();
			CreateMap<ImportPrisonerDto, Prisoner>()
				.ForMember(m => m.IncarcerationDate, mf => mf
					.MapFrom(s => DateTime.ParseExact(s.IncarcerationDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)))
				.ForMember(m => m.ReleaseDate, mf => mf
					.MapFrom(s => DateTime.ParseExact(s.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)));

			CreateMap<ImportPrisonerIdDto, OfficerPrisoner>();

			CreateMap<ImportOfficerDto, Officer>();

			//CreateMap<OfficerPrisoner, ExportPrisonerOfficerDto>()
			//	.ForMember(m => m.OfficerName, mf => mf.MapFrom(s => s.Officer.FullName))
			//	.ForMember(m => m.Department, mf => mf.MapFrom(s => s.Officer.Department.Name));

			//CreateMap<Prisoner, ExportPrisonerDto>()
			//	.ForMember(m => m.Name, mf => mf.MapFrom(s => s.FullName))
			//	.ForMember(m => m.CellNumber, mf => mf.MapFrom(s => s.Cell.CellNumber))
			//	.ForMember(m => m.TotalOfficerSalary, mf => mf.MapFrom(s => Math.Round(s.PrisonerOfficers.Sum(o => o.Officer.Salary), 2)));
		}
	}
}
