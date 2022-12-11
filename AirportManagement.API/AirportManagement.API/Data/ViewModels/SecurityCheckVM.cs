using System;
namespace AirportManagement.API.Models
{
	public class SecurityCheckVM
	{
		public string CheckResult { get; set; }

		public string Comments { get; set; }

		public DateTime CreatedAt { get; set; }

		public DateTime UpdatedAt { get; set; }

		public Passangers? Passanger { get; set; }
	}

    public class SecurityCheckForPassangersVM
    {
        public string CheckResult { get; set; }

        public string Comments { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }

}
