using System;
namespace AirportManagement.API.Models
{
	public class BaggageVM
	{
		public double WeightInKG { get; set; }

		public DateTime CreatedDate { get; set; }

		public DateTime UpdatedDate { get; set; }

		public Booking? Booking { get; set; }
	}

    public class BaggageForPassangerVM
    {
        public double WeightInKG { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }
    }

}

