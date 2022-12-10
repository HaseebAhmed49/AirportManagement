using System;
using AirportManagement.API.Models;

namespace AirportManagement.API.Data.Services
{
	public interface IAirLineRepository
	{
        public Task<List<Airline>> GetAllAirlines();

        public Task<Airline> GetAirLineById(int id);

        public Task<AirlineForFlightsVM> GetAirlineWithFlightsById(int id);

        public Task<Airline> AddAirline(AirlineVM airlineVM);

        public Task<Airline> UpdateAirlineById(int id, AirlineVM airlineVM);

        public Task<Airline> DeleteAirlineById(int id);
    }
}

