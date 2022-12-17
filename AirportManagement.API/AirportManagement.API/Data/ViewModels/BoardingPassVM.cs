using System;
namespace AirportManagement.API.Models
{
	public class BoardingPassVM
	{
		public string QRCode { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

		public int BookingId { get; set; }
	}

    public class BoardingPassForPassangerVM
    {
        public string QRCode { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }

    public class BoardingPassWithBookingVM
    {
        public string QRCode { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public BookingForBoardingPassVM? Booking { get; set; }
    }

}

