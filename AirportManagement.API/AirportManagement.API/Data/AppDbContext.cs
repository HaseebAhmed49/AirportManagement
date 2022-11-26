using System;
using AirportManagement.API.Models;
using Microsoft.EntityFrameworkCore;

namespace AirportManagement.API.Data
{
	public class AppDbContext: DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options):base(options){}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

		}

		public DbSet<Airline> Airlines { get; set; }

		public DbSet<Airport> Airports { get; set; }

		public DbSet<Baggage> Baggages { get; set; }

		public DbSet<BaggageCheck> BaggageChecks { get; set; }

		public DbSet<BoardingPass> BoardingPasses { get; set; }

		public DbSet<Booking> Bookings { get; set; }

		public DbSet<FlightManifest> FlightManifests { get; set; }

		public DbSet<Flights> Flights { get; set; }

		public DbSet<NoFlyList> NoFlyLists { get; set; }

		public DbSet<Passangers> Passangers { get; set; }

		public DbSet<SecurityCheck> SecurityChecks { get; set; }
	}
}

