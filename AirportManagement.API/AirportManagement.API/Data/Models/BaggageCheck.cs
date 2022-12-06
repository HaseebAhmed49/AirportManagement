using System;
namespace AirportManagement.API.Models
{
	public class BaggageCheck
	{
		public int Id { get; set; }

		public string CheckResult { get; set; }

		public DateTime CreatedAt { get; set; }

		public DateTime UpdatedAt { get; set; }

		public int BookingId { get; set; }

		public Booking? Booking { get; set; }

		public int PassangerId { get; set; }

		public Passangers? Passangers { get; set; }
	}
}