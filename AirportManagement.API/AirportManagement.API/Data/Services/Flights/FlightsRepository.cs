using System;
using AirportManagement.API.Models;
using Microsoft.EntityFrameworkCore;

namespace AirportManagement.API.Data.Services
{
    public class FlightsRepository : IFlightsRepository
    {
        private readonly AppDbContext _context;
        
        public FlightsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Flights> AddFlight(FlightsVM flightsVM)
        {
            Flights flight = new Flights()
            {
                AirlineId = flightsVM.AirlineId,
                ArrivingAirportId = flightsVM.ArrivingAirportId,
                ArrivingGate = flightsVM.ArrivingGate,
                CreatedAt = DateTime.Now,
                DepartureAirportId = flightsVM.DepartingAirportId,
                DepartingGate = flightsVM.DepartingGate,
                UpdatedAt = DateTime.Now,
            };
            foreach (var item in flightsVM.FlightManifests)
            {
                var isFound = await _context.FlightManifests.FirstOrDefaultAsync(fm => fm.Id == item);
                flight.FlightManifests.Add(isFound);
            }
            await _context.Flights.AddAsync(flight);
            await _context.SaveChangesAsync();
            return flight; 
        }

        public async Task<Flights> DeleteFlightById(int id)
        {
            var isFlightExist = await _context.Flights.FirstOrDefaultAsync(f => f.Id == id);
            if (isFlightExist != null)
            {
                _context.Flights.Remove(isFlightExist);
                await _context.SaveChangesAsync();
            }
            return isFlightExist!;
        }

        public async Task<List<Flights>> GetAllFlights() => await _context.Flights.ToListAsync();

        public async Task<Flights> GetFlightById(int id)
        {
            return await _context.Flights.FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<FlightsWithDetailsVM> GetFlightsWithDetailsById(int id)
        {
            var flightWithDetails = await _context.Flights.Where(f => f.Id == id).Select(fd => new FlightsWithDetailsVM()
            {
                CreatedAt = fd.CreatedAt,
                ArrivingGate = fd.ArrivingGate,
                DepartingGate = fd.DepartingGate,
                UpdatedAt = fd.UpdatedAt,
                DepartingAirport = _context.Airports.Where(a => a.Id == fd.DepartureAirportId).Select(da => new AirportVM()
                {
                    AirportName = da.AirportName,
                    CreatedAt = da.CreatedAt,
                    UpdatedAt = da.UpdatedAt,
                    City = da.City,
                    Country = da.Country,
                    State = da.State
                }).FirstOrDefault(),
                ArrivingAirport = _context.Airports.Where(a => a.Id == fd.ArrivingAirportId).Select(aa => new AirportVM()
                {
                    AirportName = aa.AirportName,
                    CreatedAt = aa.CreatedAt,
                    UpdatedAt = aa.UpdatedAt,
                    City = aa.City,
                    Country = aa.Country,
                    State = aa.State
                }).FirstOrDefault(),
                Airline = _context.Airlines.Where(al => al.Id == fd.AirlineId).Select(aln => new AirlineVM()
                {
                    AirlineCode = aln.AirlineCode,
                    AirlineCountry = aln.AirlineCountry,
                    AirlineName = aln.AirlineName,
                    CreatedAt = aln.CreatedAt,
                    UpdatedAt = aln.UpdatedAt
                }).FirstOrDefault(),
                FlightManifests = _context.FlightManifests.Where(fm => fm.FlightId == fd.Id).Select(fmn => new FlightManifestForFlightsVM()
                {
                    CreatedAt = fmn.CreatedAt,
                    UpdatedAt = fmn.UpdatedAt,
                    Booking = _context.Bookings.FirstOrDefault(b => b.Id == fmn.BookingId)
                }).ToList(),
            }).FirstOrDefaultAsync();
            return flightWithDetails!;
        }

        public async Task<Flights> UpdateFlightById(int id, FlightsVM flightsVM)
        {
            var isFlightExist = await _context.Flights.FirstOrDefaultAsync(f => f.Id == id);
            if (isFlightExist != null)
            {
                isFlightExist.AirlineId = flightsVM.AirlineId;
                isFlightExist.ArrivingAirportId = flightsVM.ArrivingAirportId;
                isFlightExist.DepartureAirportId = flightsVM.DepartingAirportId;
                isFlightExist.DepartingGate = flightsVM.DepartingGate;
                isFlightExist.ArrivingGate = flightsVM.ArrivingGate;
                isFlightExist.UpdatedAt = DateTime.Now;
                await _context.SaveChangesAsync();
            }
            return isFlightExist!;
        }
    }
}

