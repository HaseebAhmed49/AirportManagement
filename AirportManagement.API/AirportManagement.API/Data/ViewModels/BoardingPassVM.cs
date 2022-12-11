using System;
namespace AirportManagement.API.Models
{
	public class BoardingPassVM
	{
		public string QRCode { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

		public Booking? Booking { get; set; }
	}

    public class BoardingPassForPassangerVM
    {
        public string QRCode { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }

}

