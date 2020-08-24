using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SkiResort.Models
{
	//Модель для хранения данных пользователя
	public class User
	{
		[Key]
		[Column(TypeName = "int")]
		public int Id { get; set; }
		[Column(TypeName = "nvarchar(255)")]
		public string Email { get; set; }
		[Column(TypeName = "nvarchar(30)")]
		public string Password { get; set; }
		[Column(TypeName = "nvarchar(20)")]
		public string Name { get; set; }
	}
}
