using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SkiResort.Models
{
	public class EventLog
	{
		[Key]
		[Column(TypeName = "int")]
		public int Id { get; set; }

		[Column(TypeName ="int")]
		public int EventType{ get; set; }

		[Column(TypeName = "int")]
		public int CardId { get; set; }

		[Column(TypeName = "int")]
		public int PlatformId { get; set; }

		[Column(TypeName = "datetimeoffset(7)")]
		public DateTimeOffset Date { get; set; }
	}
}
