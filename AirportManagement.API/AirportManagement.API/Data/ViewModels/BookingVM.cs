using System;
namespace AirportManagement.API.Models
{
	public class BookingVM
	{
		public string Status { get; set; }

		public string BookingPlatform { get; set; }

		public DateTime CreatedAt { get; set; }

		public DateTime UpdatedAt { get; set; }

		public ICollection<BaggageCheck>? BaggageChecks { get; set; }

		public ICollection<FlightManifest>? FlightManifests { get; set; }

		public ICollection<BoardingPass>? BoardingPasses { get; set; }

		public ICollection<Baggage>? Baggages { get; set; }

		public Passangers Passanger { get; set; }
    }

    public class BookingForPassangerVM
    {
        public string Status { get; set; }

        public string BookingPlatform { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public ICollection<BaggageCheckForPassangerVM>? BaggageChecks { get; set; }

        public ICollection<FlightManifestForPassangersVM>? FlightManifests { get; set; }

        public ICollection<BoardingPassForPassangerVM>? BoardingPasses { get; set; }

        public ICollection<BaggageForPassangerVM>? Baggages { get; set; }
    }

    public class BookingForBaggagesVM
    {
        public string Status { get; set; }

        public string BookingPlatform { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public ICollection<BaggageCheckForPassangerVM>? BaggageChecks { get; set; }

        public ICollection<FlightManifestForPassangersVM>? FlightManifests { get; set; }

        public ICollection<BoardingPassForPassangerVM>? BoardingPasses { get; set; }

        public PassangersForBaggageVM? Passangers { get; set; }
    }

    public class BookingForBaggagesCheckVM
    {
        public string Status { get; set; }

        public string BookingPlatform { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public ICollection<FlightManifestForPassangersVM>? FlightManifests { get; set; }

        public ICollection<BoardingPassForPassangerVM>? BoardingPasses { get; set; }

        public ICollection<BaggageForPassangerVM>? Baggages { get; set; }
    }

    public class BookingForBoardingPassVM
    {
        public string Status { get; set; }

        public string BookingPlatform { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public ICollection<BaggageCheckForBookingVM>? BaggageChecks { get; set; }

        public ICollection<FlightManifestForBoardingPassVM>? FlightManifests { get; set; }

        public ICollection<BaggageForPassangerVM>? Baggages { get; set; }

        public PassangersForBaggageVM? Passangers { get; set; }
    }
}
