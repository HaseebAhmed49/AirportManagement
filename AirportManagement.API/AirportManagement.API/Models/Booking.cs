using System;
namespace AirportManagement.API.Models
{
	public class Booking
	{
		public int Id { get; set; }

		public string Status { get; set; }

		public string BookingPlatform { get; set; }

		public DateTime CreatedAt { get; set; }

		public DateTime UpdatedAt { get; set; }

		public ICollection<BaggageCheck>? BaggageChecks { get; set; }

		public ICollection<FlightManifest>? FlightManifests { get; set; }

		public ICollection<BoardingPass>? BoardingPasses { get; set; }

		public ICollection<Baggage>? Baggages { get; set; }

		public int PassangerId { get; set; }
	}
}
