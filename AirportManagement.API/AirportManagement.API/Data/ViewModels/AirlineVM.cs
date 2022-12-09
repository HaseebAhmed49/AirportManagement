using System;
namespace AirportManagement.API.Models
{
	public class AirlineForFlightsVM
	{
		public int AirlineCode { get; set; }

		public string AirlineName { get; set; }

		public string AirlineCountry { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

		public List<FlightsForAirlineVM>? Flights { get; set; }
	}

    public class AirlineVM
    {
        public int AirlineCode { get; set; }

        public string AirlineName { get; set; }

        public string AirlineCountry { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }

}

