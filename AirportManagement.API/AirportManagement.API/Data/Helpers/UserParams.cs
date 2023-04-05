using System;
namespace AirportManagement.API.Data.Helpers
{
	public class UserParams
	{
		private const int MaxPageSize = 50;

		public string searchCriteria { get; set; } = "";

        public string? orderBy { get; set; }

		public int PageNumber { get; set; }

		public int pageSize = 10;

		public int PageSize
		{
			get { return pageSize; }
			set { pageSize = (value > MaxPageSize) ? MaxPageSize : value; }
		}
	}
}

