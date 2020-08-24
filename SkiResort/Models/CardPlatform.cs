using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SkiResort.Models
{
	public class CardPlatform
	{
		[Key]
		[Column(TypeName = "int")]
		public int Id { get; set; }

		[Column(TypeName = "int")]
		public int CardId { get; set; }

		[Column(TypeName = "int")]
		public int PlatformId { get; set; }
	}
}
