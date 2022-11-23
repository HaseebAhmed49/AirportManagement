using System;
namespace AirportManagement.API.Models
{
	public class Passangers
	{
		public int Id { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public DateTime DateOfBirth { get; set; }

		public string CountryOfCitizenship { get; set; }

		public string CountryOfResidence { get; set; }

		public string PassportNumber { get; set; }

		public DateTime CreatedAt { get; set; }

		public DateTime UpdatedAt { get; set; }
	}
}

