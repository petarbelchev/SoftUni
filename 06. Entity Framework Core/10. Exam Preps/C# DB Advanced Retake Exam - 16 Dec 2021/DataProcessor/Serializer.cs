namespace Artillery.DataProcessor
{
    using Artillery.Data;
	using Artillery.Data.Models.Enums;
	using Artillery.DataProcessor.ExportDto;
	using Microsoft.EntityFrameworkCore;
	using Newtonsoft.Json;
	using System.Text;
	using System.Xml.Serialization;

	public class Serializer
    {
        public static string ExportShells(ArtilleryContext context, double shellWeight)
        {
            var shells = context.Shells
                .Include(s => s.Guns)
                .ToArray()
                .Where(s => s.ShellWeight > shellWeight)
                .Select(s => new
                {
                    s.ShellWeight,
                    s.Caliber,
                    Guns = s.Guns
                        .ToArray()
                        .Where(g => g.GunType == GunType.AntiAircraftGun)
                        .Select(g => new
                        {
                            GunType = g.GunType.ToString(),
                            g.GunWeight,
                            g.BarrelLength,
                            Range = g.Range > 3000 ? "Long-range" : "Regular range"
                        })
                        .OrderByDescending(g => g.GunWeight)
                        .ToArray()
                })
                .OrderBy(s => s.ShellWeight)
                .ToArray();

            return JsonConvert.SerializeObject(shells, Formatting.Indented);
        }

        public static string ExportGuns(ArtilleryContext context, string manufacturer)
        {
            ExportGunDTO[] gunDTOs = context.Guns
                .Where(g => g.Manufacturer.ManufacturerName == manufacturer)
                .OrderBy(g => g.BarrelLength)
                .Select(g => new ExportGunDTO
                {
                    Manufacturer = g.Manufacturer.ManufacturerName,
                    GunType = g.GunType.ToString(),
                    GunWeight = g.GunWeight.ToString(),
                    BarrelLength = g.BarrelLength.ToString(),
                    Range = g.Range.ToString(),
                    Countries = g.CountriesGuns
                        .Where(cg => cg.Country.ArmySize > 4_500_000)
                        .OrderBy(cg => cg.Country.ArmySize)
                        .Select(cg => new ExportCountryDTO
                        {
                            Country = cg.Country.CountryName,
                            ArmySize = cg.Country.ArmySize.ToString()
                        })
                        .ToArray()
                })
                .ToArray();

            return Serialize(gunDTOs, "Guns");
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
