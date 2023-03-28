﻿using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace TeisterMask.DataProcessor.ImportDto
{
	[XmlType("Project")]
	public class ImportProjectDTO
	{
		[XmlElement("Name")]
		[Required]
		[StringLength(40, MinimumLength = 2)]
        public string Name { get; set; } = null!;
		
		[XmlElement("OpenDate")]
		[Required]
        public string OpenDate { get; set; } = null!;
		
		[XmlElement("DueDate")]
        public string? DueDate { get; set; }

		[XmlArray("Tasks")]
        public virtual ImportTaskDTO[] Tasks { get; set; } = null!;
    }
}
