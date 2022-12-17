using System;
namespace AirportManagement.API.Models
{
	public class BaggageCheckWithDetailsVM
	{
		public string CheckResult { get; set; }

		public DateTime CreatedAt { get; set; }

		public DateTime UpdatedAt { get; set; }

		public BookingForBaggagesCheckVM? Booking { get; set; }

		public PassangersForBaggageVM? Passanger { get; set; }
	}

    public class BaggageCheckVM
    {
        public string CheckResult { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public int BookingId { get; set; }

        public int PassangerId { get; set; }
    }


    public class BaggageCheckForPassangerVM
    {
        public string CheckResult { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }

    public class BaggageCheckForBookingVM
    {
        public string CheckResult { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public Passangers? Passangers { get; set; }
    }

}