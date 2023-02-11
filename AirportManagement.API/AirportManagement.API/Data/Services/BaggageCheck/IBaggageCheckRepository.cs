using System;
using AirportManagement.API.Data.Helpers;
using AirportManagement.API.Models;

namespace AirportManagement.API.Data.Services
{
	public interface IBaggageCheckRepository
    {
        public Task<PagedList<BaggageCheck>> GetAllBaggageChecks(UserParams userParams);

        public Task<BaggageCheck> GetBaggageCheckById(int id);

        public Task<BaggageCheckWithDetailsVM> GetBaggageChecksWithDetailsById(int id);

        public Task<BaggageCheck> AddBaggageCheck(BaggageCheckVM baggageCheckVM);

        public Task<BaggageCheck> UpdateBaggageCheckById(int id, BaggageCheckVM baggageCheckVM);

        public Task<BaggageCheck> DeleteBaggageCheckById(int id);
    }
}

