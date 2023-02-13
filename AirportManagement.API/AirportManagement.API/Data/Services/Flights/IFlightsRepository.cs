using System;
using AirportManagement.API.Data.Helpers;
using AirportManagement.API.Models;

namespace AirportManagement.API.Data.Services
{
	public interface IFlightsRepository
	{
        public Task<PagedList<Flights>> GetAllFlights(UserParams userParams);

        public Task<Flights> GetFlightById(int id);

        public Task<FlightsWithDetailsVM> GetFlightsWithDetailsById(int id);

        public Task<Flights> AddFlight(FlightsVM flightsVM);

        public Task<Flights> UpdateFlightById(int id, FlightsVM flightsVM);

        public Task<Flights> DeleteFlightById(int id);
    }
}

