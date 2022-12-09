using System;
using AirportManagement.API.Models;
using Microsoft.EntityFrameworkCore;

namespace AirportManagement.API.Data.Services
{
	public class AirportRepository: IAirportRepository
	{
        private readonly AppDbContext _context;

		public AirportRepository(AppDbContext context)
		{
            _context = context;
		}

        public async Task<Airport> AddAirport(AirportVM airportVM)
        {
            Airport airport = new Airport
            {
                AirportName = airportVM.AirportName,
                City = airportVM.City,
                Country = airportVM.Country,
                State = airportVM.State,
                CreatedAt = airportVM.CreatedAt,
                UpdatedAt = airportVM.UpdatedAt
            };
            await _context.Airports.AddAsync(airport);
            await _context.SaveChangesAsync();
            return airport;

        }

        public async Task<Airport> DeleteAirportById(int id)
        {
            var isAirportExist = await _context.Airports.FirstOrDefaultAsync(a => a.Id == id);
            if (isAirportExist != null)
            {
                _context.Airports.Remove(isAirportExist);
                await _context.SaveChangesAsync();
            }
            return isAirportExist!;
        }

        public async Task<AirportVM> GetAirportById(int id)
        {
            var airport = await _context.Airports.FirstOrDefaultAsync(x => x.Id == id);
            if(airport != null)
            {
                var airportDetails = new AirportVM()
                {
                    AirportName = airport.AirportName,
                    CreatedAt = airport.CreatedAt,
                    UpdatedAt = airport.UpdatedAt,
                    City = airport.City,
                    Country = airport.Country,
                    State = airport.State
                };
                return airportDetails;
            }
            return null!;
        }

        public Task<AirlineForFlightsVM> GetAirportWithFlightsById(int id)
        {
            throw new NotImplementedException();
        }

        //public async Task<AirlineForFlightsVM> GetAirportWithFlightsById(int id)
        //{
        //    //var airport = await _context.Airports.Where(a => a.Id == id).Select(async a => new AirportForFlightsVM()
        //    //{
        //    //    AirportName = a.AirportName,
        //    //    CreatedAt = a.CreatedAt,
        //    //    UpdatedAt = a.UpdatedAt,
        //    //    City = a.City,
        //    //    Country = a.Country,
        //    //    State = a.State,
        //    //    ArrivingFlights = _context.Flights.Where(i => i.Id == a.Id).Select(async fl => new FlightsForAirportVM()
        //    //    {
        //    //        Airline =  _context.Airlines.Where(al => al.Id == fl.AirlineId).FirstOrDefault(),
        //    //        ArrivingGate = fl.ArrivingGate,
        //    //        DepartingGate = fl.DepartingGate,
        //    //        CreatedAt = fl.CreatedAt,
        //    //        UpdatedAt = fl.UpdatedAt,
        //    //        FlightManifests = _context.FlightManifests.Where(i => i.Id == fl.Id).ToList()
        //    //    }).ToList(),
        //    //}).FirstOrDefaultAsync();
        //    //return airport!;

        //}

        public async Task<List<Airport>> GetAllAirports() => await _context.Airports.ToListAsync();

        public async Task<Airport> UpdateAirportById(int id, AirportVM airportVM)
        {
            var isAirportExist = await _context.Airports.FirstOrDefaultAsync(a => a.Id == id);
            if (isAirportExist != null)
            {
                isAirportExist.AirportName = airportVM.AirportName;
                isAirportExist.City = airportVM.City;
                isAirportExist.Country = airportVM.Country;
                isAirportExist.UpdatedAt = airportVM.UpdatedAt;
                isAirportExist.State = airportVM.State;
                await _context.SaveChangesAsync();
            }
            return isAirportExist!;
        }
    }
}

