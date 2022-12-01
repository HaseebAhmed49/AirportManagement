using System;
namespace AirportManagement.API.Models
{
	public class BoardingPass
	{
		public int Id { get; set; }

		public string QRCode { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

		public int BookingId { get; set; }

		public Booking Booking { get; set; }

	}
}

