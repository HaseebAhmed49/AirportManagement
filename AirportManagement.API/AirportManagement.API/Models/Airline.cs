using System;
namespace AirportManagement.API.Models
{
	public class Airline
	{
		public int Id { get; set; }

		public int AirlineCode { get; set; }

		public string AirlineName { get; set; }

		public string AirlineCountry { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

		public ICollection<Flights>? Flights { get; set; }
	}
}

