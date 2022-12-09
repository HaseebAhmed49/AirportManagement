using System;
using AirportManagement.API.Models;

namespace AirportManagement.API.Data.Services
{
	public interface IAirportRepository
	{
        public Task<List<Airport>> GetAllAirports();

        public Task<AirportVM> GetAirportById(int id);

        public Task<AirlineForFlightsVM> GetAirportWithFlightsById(int id);

        public Task<Airport> AddAirport(AirportVM airportVM);

        public Task<Airport> UpdateAirportById(int id, AirportVM airportVM);

        public Task<Airport> DeleteAirportById(int id);
    }
}

