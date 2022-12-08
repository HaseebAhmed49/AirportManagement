using System;
using AirportManagement.API.Models;
using Microsoft.EntityFrameworkCore;

namespace AirportManagement.API.Data.Services
{
    public class AirlineRepository : IAirLineRepository
    {
        private readonly AppDbContext _context;
        
        public AirlineRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Airline> AddAirline(AirlineVM airlineVM)
        {
            Airline airline = new Airline
            {
                AirlineName = airlineVM.AirlineName,
                AirlineCode = airlineVM.AirlineCode,
                AirlineCountry = airlineVM.AirlineCountry,
                CreatedAt = airlineVM.CreatedAt,
                UpdatedAt = airlineVM.UpdatedAt
            };
            await _context.Airlines.AddAsync(airline);
            await _context.SaveChangesAsync();
            return airline;
        }

        public async Task<Airline> DeleteAirlineById(int id)
        {
            var isAirlineExist = await _context.Airlines.FirstOrDefaultAsync(a => a.Id == id);
            if(isAirlineExist!=null)
            {
                _context.Airlines.Remove(isAirlineExist);
                await _context.SaveChangesAsync();
            }
            return isAirlineExist!;
        }

        public async Task<AirlineVM> GetAirlineWithFlightsById(int id)
        {
            var airline = await _context.Airlines.Where(al => al.Id == id).Select(a => new AirlineVM()
            {
                AirlineCode = a.AirlineCode,
                AirlineCountry = a.AirlineCountry,
                AirlineName = a.AirlineName,
                CreatedAt = a.CreatedAt,
                UpdatedAt = a.UpdatedAt,
                Flights = _context.Flights.Where(i => i.Id == a.Id).Select(fl => new FlightsForAirlineVM()
                {
                    ArrivingGate = fl.ArrivingGate,
                    CreatedAt = fl.CreatedAt,
                    DepartingGate = fl.DepartingGate,
                    UpdatedAt = fl.UpdatedAt,
                    ArrivingAirport = _context.Airports.Where(ap => ap.Id == fl.Id).FirstOrDefault(),
                    DepartureAirport = _context.Airports.Where(ap => ap.Id == fl.Id).FirstOrDefault(),
                    FlightManifests = _context.FlightManifests.Where(i => i.Id == fl.Id).Select(fm => new FlightManifestForFlightsVM()
                    {
                        CreatedAt = fm.CreatedAt,
                        UpdatedAt = fm.UpdatedAt
                    }).ToList()
                }).ToList()
            }).FirstOrDefaultAsync();
            return airline;
        }

        public async Task<Airline> GetAirLineById(int id)
        {
            return await _context.Airlines.FirstOrDefaultAsync(a=> a.Id == id);
        }

        public async Task<List<Airline>> GetAllAirlines() => await _context.Airlines.ToListAsync();

        public async Task<Airline> UpdateAirlineById(int id, AirlineVM airlineVM)
        {
            var isAirlineExist = await _context.Airlines.FirstOrDefaultAsync(a => a.Id == id);
            if (isAirlineExist != null)
            {
                isAirlineExist.AirlineCode = airlineVM.AirlineCode;
                isAirlineExist.AirlineCountry = airlineVM.AirlineCountry;
                isAirlineExist.AirlineName = airlineVM.AirlineName;
                isAirlineExist.UpdatedAt = airlineVM.UpdatedAt;
                await _context.SaveChangesAsync();
            }
            return isAirlineExist!;
        }
    }
}

