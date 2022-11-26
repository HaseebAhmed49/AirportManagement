using System;
namespace AirportManagement.API.Models
{
	public class SecurityCheck
	{
		public int Id { get; set; }

		public string CheckResult { get; set; }

		public string Comments { get; set; }

		public DateTime CreatedAt { get; set; }

		public DateTime UpdatedAt { get; set; }

		public int PassangerId { get; set; }
	}
}