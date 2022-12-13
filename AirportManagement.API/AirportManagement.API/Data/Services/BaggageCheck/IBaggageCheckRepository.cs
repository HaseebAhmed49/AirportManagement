using System;
using AirportManagement.API.Models;

namespace AirportManagement.API.Data.Services
{
	public interface IBaggageCheckRepository
    {
        public Task<List<BaggageCheck>> GetAllBaggageChecks();

        public Task<BaggageCheck> GetBaggageCheckById(int id);

        public Task<BaggageCheckWithDetailsVM> GetBaggageChecksWithDetailsById(int id);

        public Task<BaggageCheck> AddBaggageCheck(BaggageCheckVM baggageCheckVM);

        public Task<BaggageCheck> UpdateBaggageCheckById(int id, BaggageCheckVM baggageCheckVM);

        public Task<BaggageCheck> DeleteBaggageCheckById(int id);
    }
}

