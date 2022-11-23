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
	}
}

