using System;
namespace AirportManagement.API.Models
{
	public class Baggage
	{
		public int Id { get; set; }

		public double WeightInKG { get; set; }

		public DateTime CreatedDate { get; set; }

		public DateTime UpdatedDate { get; set; }

		public int BookingId { get; set; }

		public Booking Booking { get; set; }
	}
}

