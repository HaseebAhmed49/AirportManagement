using System;
namespace AirportManagement.API.Models
{
	public class PassangersVM
	{
		public string FirstName { get; set; }

		public string LastName { get; set; }

		public DateTime DateOfBirth { get; set; }

		public string CountryOfCitizenship { get; set; }

		public string CountryOfResidence { get; set; }

		public string PassportNumber { get; set; }

		public DateTime CreatedAt { get; set; }

		public DateTime UpdatedAt { get; set; }

		public ICollection<SecurityCheck>? SecurityChecks { get; set; }

		public ICollection<Booking>? Bookings { get; set; }

		public ICollection<NoFlyList>? NoFlyLists { get; set; }
    }

        public class PassangersWithDetailsVM
        {
            public string FirstName { get; set; }

            public string LastName { get; set; }

            public DateTime DateOfBirth { get; set; }

            public string CountryOfCitizenship { get; set; }

            public string CountryOfResidence { get; set; }

            public string PassportNumber { get; set; }

            public DateTime CreatedAt { get; set; }

            public DateTime UpdatedAt { get; set; }

            public ICollection<SecurityCheckForPassangersVM>? SecurityChecks { get; set; }

            public ICollection<BookingForPassangerVM>? Bookings { get; set; }

            public ICollection<NoFlyListForPassangerVM>? NoFlyLists { get; set; }
        }

    public class PassangersForBaggageVM
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string CountryOfCitizenship { get; set; }

        public string CountryOfResidence { get; set; }

        public string PassportNumber { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public ICollection<SecurityCheckForPassangersVM>? SecurityChecks { get; set; }

        public ICollection<NoFlyListForPassangerVM>? NoFlyLists { get; set; }
    }

}