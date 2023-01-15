﻿using System;
using Newtonsoft.Json;

namespace AirportManagement.API.Data.Helpers
{
	public static class Extensions
	{
		public static void AddPagination(this HttpResponse response,
			int currentPage, int itemsPerPage, int totalItems, int totalPages)
		{
			var paginationHeader = new PaginationHeader(currentPage, itemsPerPage, totalItems, totalPages);
			response.Headers.Add("Pagination", JsonConvert.SerializeObject(paginationHeader));
			response.Headers.Add("Access-Control-Expose-Headers", "Pagination");
		}
	}
}