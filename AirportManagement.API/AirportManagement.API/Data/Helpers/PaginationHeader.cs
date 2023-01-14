﻿using System;
namespace AirportManagement.API.Data.Helpers
{
	public class PaginationHeader
	{
		public int CurrentPage { get; set; }

		public int ItemsPerPage { get; set; }

		public int TotalItems { get; set; }

		public int TotalPages { get; set; }
	}
}

