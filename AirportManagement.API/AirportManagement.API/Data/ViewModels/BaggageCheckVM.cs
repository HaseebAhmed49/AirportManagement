using System;
namespace AirportManagement.API.Models
{
	public class BaggageCheckVM
	{
		public string CheckResult { get; set; }

		public DateTime CreatedAt { get; set; }

		public DateTime UpdatedAt { get; set; }

		public Booking? Booking { get; set; }

		public Passangers? Passanger { get; set; }
	}

    public class BaggageCheckForPassangerVM
    {
        public string CheckResult { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }

}