using System;
namespace AirportManagement.API.Models
{
	public class NoFlyListVM
	{
		public DateOnly ActiveFrom { get; set; }

		public DateOnly ActiveTo { get; set; }

		public string NoFlyReason { get; set; }

		public DateTime CreatedAt { get; set; }

		public DateTime UpdatedAt { get; set; }

		public Passangers? Passanger { get; set; }
	}

    public class NoFlyListForPassangerVM
    {
        public DateOnly ActiveFrom { get; set; }

        public DateOnly ActiveTo { get; set; }

        public string NoFlyReason { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}