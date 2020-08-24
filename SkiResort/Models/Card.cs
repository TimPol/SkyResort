using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SkiResort.Models
{
	public class Card
	{
		[Key]
		[Column(TypeName = "int")]
		public int Id { get; set; }

		[Column(TypeName = "int")]
		public int UserId { get; set; }
		[Column(TypeName = "datetimeoffset(7)")]
		public DateTimeOffset DateBegin { get; set; }

		[Column(TypeName = "datetimeoffset(7)")]
		public DateTimeOffset DateEnd { get; set; }
	}
}
