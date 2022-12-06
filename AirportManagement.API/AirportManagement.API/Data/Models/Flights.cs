using System;
namespace AirportManagement.API.Models
{
	public class Flights
	{
		public int Id { get; set; }

		public string DepartingGate { get; set; }

		public string ArrivingGate { get; set; }

		public DateTime CreatedAt { get; set; }

		public DateTime UpdatedAt { get; set; }

		public int ArrivingAirportId { get; set; }

		public Airport? ArrivingAirport { get; set; }

		public int DepartingAirportId { get; set; }

        public Airport? DepartureAirport { get; set; }

        public int AirlineId { get; set; }

		public Airline? Airline { get; set; }

		public ICollection<FlightManifest>? FlightManifests { get; set; }
	}
}

