using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkiResort.Models
{
	public class SkiResortContext : DbContext
	{
	public DbSet<Card> Cards { get; set; }
	public DbSet<CardPlatform> CardPlatforms { get; set; }
	public DbSet<Equipment> Equipments { get; set; }
	public DbSet<EventLog> EventLogs { get; set; }
	public DbSet<Platform> Platforms { get; set; }
	public DbSet<User> Users { get; set; }
	public DbSet<UserEquipment> UserEquipments { get; set; }
	public SkiResortContext(DbContextOptions<SkiResortContext> options)
	: base(options)
		{
			Database.EnsureCreated();
		}
	}
}
