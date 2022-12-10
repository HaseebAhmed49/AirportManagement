using System;
namespace AirportManagement.API.Models
{
	public class AirportVM
	{
		public string AirportName{ get; set; }

		public string Country { get; set; }

		public string State { get; set; }

		public string City { get; set; }

		public DateTime CreatedAt { get; set; }

		public DateTime UpdatedAt { get; set; }
    }

    public class AirportForFlightsVM
    {
        public string AirportName { get; set; }

        public string Country { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public ICollection<FlightsForAirportVM>? ArrivingFlights { get; set; }

        public ICollection<FlightsForAirportVM>? DepartureFlights { get; set; }

    }
}