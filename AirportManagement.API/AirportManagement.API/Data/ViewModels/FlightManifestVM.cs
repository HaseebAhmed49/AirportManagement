﻿using System;
namespace AirportManagement.API.Models
{
	public class FlightManifestVM
	{
		public DateTime CreatedAt { get; set; }

		public DateTime UpdatedAt { get; set; }

		public int FlightId { get; set; }

		public int BookingId { get; set; }
	}
}
