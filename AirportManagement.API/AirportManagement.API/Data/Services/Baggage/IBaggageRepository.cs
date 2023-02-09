using System;
using AirportManagement.API.Data.Helpers;
using AirportManagement.API.Models;

namespace AirportManagement.API.Data.Services
{
	public interface IBaggageRepository
    {
        public Task<PagedList<Baggage>> GetAllBaggages(UserParams userParams);

        public Task<Baggage> GetBaggageById(int id);

        public Task<BaggageWithDetailsVM> GetBaggageWithBookingDetailsById(int id);

        public Task<Baggage> AddBaggage(BaggageVM baggageVM);

        public Task<Baggage> UpdateBaggageById(int id, BaggageVM baggageVM);

        public Task<Baggage> DeleteBaggageById(int id);
    }
}

