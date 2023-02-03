using System;
using AirportManagement.API.Data.Helpers;
using AirportManagement.API.Models;

namespace AirportManagement.API.Data.Services
{
	public interface IAirportRepository
	{
        public Task<PagedList<Airport>> GetAllAirports(UserParams userParams);

        public Task<AirportVM> GetAirportById(int id);

        public Task<AirportForFlightsVM> GetAirportWithFlightsById(int id);

        public Task<Airport> AddAirport(AirportVM airportVM);

        public Task<Airport> UpdateAirportById(int id, AirportVM airportVM);

        public Task<Airport> DeleteAirportById(int id);
    }
}