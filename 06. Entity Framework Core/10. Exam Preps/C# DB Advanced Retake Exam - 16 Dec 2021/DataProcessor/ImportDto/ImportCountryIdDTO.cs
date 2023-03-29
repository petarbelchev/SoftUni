using System.ComponentModel.DataAnnotations;

namespace Artillery.DataProcessor.ImportDto
{
	public class ImportCountryIdDTO
	{
		[Required]
        public int Id { get; set; }
    }
}
