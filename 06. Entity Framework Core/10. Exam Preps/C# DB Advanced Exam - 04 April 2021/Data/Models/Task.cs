﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TeisterMask.Data.Models.Enums;

namespace TeisterMask.Data.Models
{
	public class Task
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[StringLength(40, MinimumLength = 2)]
        public string Name { get; set; } = null!;

		[Required]
        public DateTime OpenDate { get; set; }

		[Required]
        public DateTime DueDate { get; set; }

		[Required]
		public ExecutionType ExecutionType { get; set; }

		[Required]
		public LabelType LabelType { get; set; }

		[Required]
		[ForeignKey(nameof(Project))]
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; } = null!;

        public virtual ICollection<EmployeeTask> EmployeesTasks  { get; set; } = null!;
    }
}
