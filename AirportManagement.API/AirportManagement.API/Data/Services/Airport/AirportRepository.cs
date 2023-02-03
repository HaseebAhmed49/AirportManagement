using System;
using AirportManagement.API.Data.Helpers;
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

        public async Task<AirportForFlightsVM> GetAirportWithFlightsById(int id)
        {
            var airport = await _context.Airports.Where(a => a.Id == id).Select(a => new AirportForFlightsVM()
            {
                AirportName = a.AirportName,
                CreatedAt = a.CreatedAt,
                UpdatedAt = a.UpdatedAt,
                City = a.City,
                Country = a.Country,
                State = a.State,
                ArrivingFlights = _context.Flights.Where(f => f.Id == a.Id).Select(af => new FlightsForAirportVM()
                {
                    CreatedAt = af.CreatedAt,
                    UpdatedAt = af.UpdatedAt,
                    ArrivingGate = af.ArrivingGate,
                    DepartingGate = af.DepartingGate,
                    Airline = _context.Airlines.Where(airline => airline.Id == af.AirlineId).Select(air => new AirlineVM()
                    {
                        AirlineCode = air.AirlineCode,
                        AirlineCountry = air.AirlineCountry,
                        AirlineName = air.AirlineName,
                        CreatedAt = air.CreatedAt,
                        UpdatedAt = air.UpdatedAt
                    }).FirstOrDefault(),
                    FlightManifests = _context.FlightManifests.Where(i => i.Id == af.Id).Select(fm => new FlightManifestForFlightsVM()
                    {
                        CreatedAt = fm.CreatedAt,
                        UpdatedAt = fm.UpdatedAt,
                        Booking = _context.Bookings.Where(b => b.Id == fm.BookingId).FirstOrDefault()
                    }).ToList()
                }).ToList(),
                DepartureFlights = _context.Flights.Where(f => f.Id == a.Id).Select(af => new FlightsForAirportVM()
                {
                    CreatedAt = af.CreatedAt,
                    UpdatedAt = af.UpdatedAt,
                    ArrivingGate = af.ArrivingGate,
                    DepartingGate = af.DepartingGate,
                    Airline = _context.Airlines.Where(airline => airline.Id == af.AirlineId).Select(air => new AirlineVM()
                    {
                        AirlineCode = air.AirlineCode,
                        AirlineCountry = air.AirlineCountry,
                        AirlineName = air.AirlineName,
                        CreatedAt = air.CreatedAt,
                        UpdatedAt = air.UpdatedAt
                    }).FirstOrDefault(),
                    FlightManifests = _context.FlightManifests.Where(i => i.Id == af.Id).Select(fm => new FlightManifestForFlightsVM()
                    {
                        CreatedAt = fm.CreatedAt,
                        UpdatedAt = fm.UpdatedAt,
                        Booking = _context.Bookings.Where(b => b.Id == fm.BookingId).FirstOrDefault()
                    }).ToList()
                }).ToList()
            }).FirstOrDefaultAsync();
            return airport!;
        }

        public async Task<PagedList<Airport>> GetAllAirports(UserParams userParams)
        {
            var airports = _context.Airports;
            return await PagedList<Airport>.CreateAsync(airports, userParams.PageNumber, userParams.pageSize);
        }

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
