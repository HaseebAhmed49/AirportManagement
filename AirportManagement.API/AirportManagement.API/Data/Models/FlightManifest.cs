using System;
namespace AirportManagement.API.Models
{
	public class FlightManifest
	{
		public int Id { get; set; }

		public DateTime CreatedAt { get; set; }

		public DateTime UpdatedAt { get; set; }

		public int FlightId { get; set; }

		public Flights? Flights { get; set; }

		public int BookingId { get; set; }

		public Booking? Booking { get; set; }
	}
}

