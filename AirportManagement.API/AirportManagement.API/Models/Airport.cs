using System;
namespace AirportManagement.API.Models
{
	public class Airport
	{
		public int Id { get; set; }

		public string AirportName{ get; set; }

		public string Country { get; set; }

		public string State { get; set; }

		public string City { get; set; }

		public DateTime CreatedAt { get; set; }

		public DateTime UpdatedAt { get; set; }

		public ICollection<Flights>? ArrivingFlights { get; set; }

        public ICollection<Flights>? DepartureFlights { get; set; }
    }
}