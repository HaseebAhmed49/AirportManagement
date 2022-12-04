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

		public int PassangerId { get; set; }
	}
}