using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SkiResort.Models
{
	public class Platform
	{
		[Key]
		[Column(TypeName = "int")]
		public int Id { get; set; }

		[Column(TypeName ="nvarchar(255)")]
		public string Name { get; set; }
	}
}
