using System;
using AirportManagement.API.Models;
using Microsoft.EntityFrameworkCore;

namespace AirportManagement.API.Data.Services
{
    public class PassangerRepository : IPassangerRepository
    {
        private readonly AppDbContext _context;
        
        public PassangerRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Passangers> AddPassanger(PassangersVM passangerVM)
        {
            Passangers passanger = new Passangers
            {
                FirstName = passangerVM.FirstName,
                LastName = passangerVM.LastName,
                CreatedAt = passangerVM.CreatedAt,
                UpdatedAt = passangerVM.UpdatedAt,
                CountryOfCitizenship = passangerVM.CountryOfCitizenship,
                CountryOfResidence =passangerVM.CountryOfResidence,
                PassportNumber = passangerVM.PassportNumber,
                DateOfBirth = passangerVM.DateOfBirth,
            };
            await _context.Passangers.AddAsync(passanger);
            await _context.SaveChangesAsync();
            return passanger;
        }

        /// <summary>
        /// Delete Passanger By Id "Commented as passanger shouldn't be deleted at any cost"
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //public async Task<Passangers> DeletePassangerById(int id)
        //{
        //    var isPassangerExist = await _context.Passangers.FirstOrDefaultAsync(p => p.Id == id);
        //    if(isPassangerExist != null)
        //    {
        //        _context.Passangers.Remove(isPassangerExist);
        //        await _context.SaveChangesAsync();
        //    }
        //    return isPassangerExist!;
        //}

        //public async Task<AirlineForFlightsVM> GetAirlineWithFlightsById(int id)
        //{
        //    var airline = await _context.Airlines.Where(al => al.Id == id).Select(a => new AirlineForFlightsVM()
        //    {
        //        AirlineCode = a.AirlineCode,
        //        AirlineCountry = a.AirlineCountry,
        //        AirlineName = a.AirlineName,
        //        CreatedAt = a.CreatedAt,
        //        UpdatedAt = a.UpdatedAt,
        //        Flights = _context.Flights.Where(i => i.Id == a.Id).Select(fl => new FlightsForAirlineVM()
        //        {
        //            ArrivingGate = fl.ArrivingGate,
        //            CreatedAt = fl.CreatedAt,
        //            DepartingGate = fl.DepartingGate,
        //            UpdatedAt = fl.UpdatedAt,
        //            ArrivingAirport = _context.Airports.Where(ap => ap.Id == fl.Id).FirstOrDefault(),
        //            DepartureAirport = _context.Airports.Where(ap => ap.Id == fl.Id).FirstOrDefault(),
        //            FlightManifests = _context.FlightManifests.Where(i => i.Id == fl.Id).Select(fm => new FlightManifestForFlightsVM()
        //            {
        //                CreatedAt = fm.CreatedAt,
        //                UpdatedAt = fm.UpdatedAt
        //            }).ToList()
        //        }).ToList(), 
        //    }).FirstOrDefaultAsync();
        //    return airline!;
        //}

        public async Task<Passangers> GetPassangerById(int id)
        {
            return await _context.Passangers.FirstOrDefaultAsync(p=> p.Id == id);
        }

        public async Task<List<Passangers>> GetAllPassangers() => await _context.Passangers.ToListAsync();

        public async Task<Passangers> UpdatePassangerById(int id, PassangersVM passangerVM)
        {
            var isPassangerExist = await _context.Passangers.FirstOrDefaultAsync(p => p.Id == id);
            if (isPassangerExist != null)
            {
                isPassangerExist.FirstName = passangerVM.FirstName;
                isPassangerExist.LastName = passangerVM.LastName;
                isPassangerExist.CountryOfCitizenship = passangerVM.CountryOfCitizenship;
                isPassangerExist.CountryOfResidence = passangerVM.CountryOfResidence;
                await _context.SaveChangesAsync();
            }
            return isPassangerExist!;
        }
    }
}

