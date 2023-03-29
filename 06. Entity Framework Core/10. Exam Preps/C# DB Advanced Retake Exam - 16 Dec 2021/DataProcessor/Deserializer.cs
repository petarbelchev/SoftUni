namespace Artillery.DataProcessor
{
    using Artillery.Data;
	using Artillery.Data.Models;
	using Artillery.Data.Models.Enums;
	using Artillery.DataProcessor.ImportDto;
	using Newtonsoft.Json;
	using System.ComponentModel.DataAnnotations;
	using System.Text;
	using System.Xml.Serialization;

	public class Deserializer
    {
        private const string ErrorMessage =
            "Invalid data.";
        private const string SuccessfulImportCountry =
            "Successfully import {0} with {1} army personnel.";
        private const string SuccessfulImportManufacturer =
            "Successfully import manufacturer {0} founded in {1}.";
        private const string SuccessfulImportShell =
            "Successfully import shell caliber #{0} weight {1} kg.";
        private const string SuccessfulImportGun =
            "Successfully import gun {0} with a total weight of {1} kg. and barrel length of {2} m.";

        public static string ImportCountries(ArtilleryContext context, string xmlString)
        {
            var output = new StringBuilder();

            ImportCountryDTO[]? countryDTOs = 
                Deserialize<ImportCountryDTO[]>("Countries", xmlString);
            
            if (countryDTOs == null)
                return ErrorMessage;

            List<Country> countries = new List<Country>();

            foreach (var countryDTO in countryDTOs)
            {
                if (!IsValid(countryDTO))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                Country country = new Country
                {
                    CountryName = countryDTO.CountryName,
                    ArmySize = countryDTO.ArmySize
                };

                countries.Add(country);
                output.AppendLine(string.Format(SuccessfulImportCountry, country.CountryName, country.ArmySize));
            }
            context.Countries.AddRange(countries);
            context.SaveChanges();

            return output.ToString().TrimEnd();
        }

        public static string ImportManufacturers(ArtilleryContext context, string xmlString)
        {
            var output = new StringBuilder();

            ImportManufacturerDTO[]? manufacturerDTOs = 
                Deserialize<ImportManufacturerDTO[]>("Manufacturers", xmlString);

            if (manufacturerDTOs == null)
                return ErrorMessage;

            List<Manufacturer> manufacturers = new List<Manufacturer>();

            foreach (var mDTO in manufacturerDTOs)
            {
                if (!IsValid(mDTO) 
                    || manufacturers.Any(m => m.ManufacturerName == mDTO.ManufacturerName))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                Manufacturer manufacturer = new Manufacturer
                {
                    ManufacturerName = mDTO.ManufacturerName,
                    Founded = mDTO.Founded
                };

                manufacturers.Add(manufacturer);

                string[] splited = manufacturer.Founded.Split(", ");
                string townName = splited[splited.Length - 2];
                string countryName = splited[splited.Length - 1];

                output.AppendLine(string.Format(SuccessfulImportManufacturer, 
                                    manufacturer.ManufacturerName, $"{townName}, {countryName}"));
            }
            context.Manufacturers.AddRange(manufacturers);
            context.SaveChanges();

            return output.ToString().TrimEnd();
        }

        public static string ImportShells(ArtilleryContext context, string xmlString)
        {
            var output = new StringBuilder();

            ImportShellDTO[]? shellDTOs = Deserialize<ImportShellDTO[]>("Shells", xmlString);

            if (shellDTOs == null)
                return ErrorMessage;

            List<Shell> shells = new List<Shell>();

            foreach (var shDTO in shellDTOs)
            {
                if (!IsValid(shDTO))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                Shell shell = new Shell
                {
                    ShellWeight = shDTO.ShellWeight,
                    Caliber = shDTO.Caliber
                };

                shells.Add(shell);
                output.AppendLine(string.Format(SuccessfulImportShell, shell.Caliber, shell.ShellWeight));
            }
            context.Shells.AddRange(shells);
            context.SaveChanges();

            return output.ToString().TrimEnd();
        }

        public static string ImportGuns(ArtilleryContext context, string jsonString)
        {
            var output = new StringBuilder();

            ImportGunDTO[]? gunDTOs = JsonConvert.DeserializeObject<ImportGunDTO[]>(jsonString);

            if (gunDTOs == null) 
                return ErrorMessage;

            List<Gun> guns = new List<Gun>();

            foreach (var gDTO in gunDTOs)
            {
                bool isValidGunType = Enum.TryParse(gDTO.GunType, true , out GunType gunType);

                if (!IsValid(gDTO) || !isValidGunType)
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                Gun gun = new Gun
                {
                    ManufacturerId = gDTO.ManufacturerId,
                    GunWeight = gDTO.GunWeight,
                    BarrelLength = gDTO.BarrelLength,
                    NumberBuild = gDTO.NumberBuild,
                    Range = gDTO.Range,
                    GunType = gunType,
                    ShellId = gDTO.ShellId,
                    CountriesGuns = new HashSet<CountryGun>()
                };

                foreach (var cDTO in gDTO.Countries)
                {
                    gun.CountriesGuns.Add(new CountryGun { CountryId = cDTO.Id });
                }

                guns.Add(gun);
                output.AppendLine(string.Format(SuccessfulImportGun, gun.GunType, gun.GunWeight, gun.BarrelLength));
            }
            context.Guns.AddRange(guns);
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