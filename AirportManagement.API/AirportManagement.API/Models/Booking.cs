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
	}
}

