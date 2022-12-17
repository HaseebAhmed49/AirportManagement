using System;
namespace AirportManagement.API.Models
{
	public class BaggageVM
	{
		public double WeightInKG { get; set; }

		public DateTime CreatedDate { get; set; }

		public DateTime UpdatedDate { get; set; }

		public int BookingId { get; set; }
	}

    public class BaggageForPassangerVM
    {
        public double WeightInKG { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }
    }

    public class BaggageWithDetailsVM
    {
        public double WeightInKG { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public BookingForBaggagesVM? Booking { get; set; }
    }

}

