using System;
using AirportManagement.API.Data.Helpers;
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

        public async Task<Passangers> GetPassangerById(int id)
        {
            return await _context.Passangers.FirstOrDefaultAsync(p=> p.Id == id);
        }

        public async Task<PagedList<Passangers>> GetAllPassangers(UserParams userParams)
        {
            var passangers = _context.Passangers.AsQueryable();
            var data = passangers.Where(x => x.FirstName.Contains(userParams.searchCriteria)).AsQueryable();
            return await PagedList<Passangers>.CreateAsync(data, userParams.PageNumber, userParams.pageSize);
        }

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

        public async Task<PassangersWithDetailsVM> GetPassangerWithDetailsById(int id)
        {
            var passanger = await _context.Passangers.Where(p => p.Id == id).Select(pn => new PassangersWithDetailsVM()
            {
                FirstName = pn.FirstName,
                LastName = pn.LastName,
                DateOfBirth = pn.DateOfBirth,
                PassportNumber = pn.PassportNumber,
                CountryOfCitizenship = pn.CountryOfCitizenship,
                CountryOfResidence = pn.CountryOfResidence,
                CreatedAt = pn.CreatedAt,
                UpdatedAt = pn.UpdatedAt,
                Bookings = _context.Bookings.Where(b => b.PassangerId == pn.Id).Select(bn => new BookingForPassangerVM()
                {
                    BookingPlatform = bn.BookingPlatform,
                    CreatedAt = bn.CreatedAt.Date,
                    UpdatedAt = bn.UpdatedAt,
                    Status = bn.Status,
                    BaggageChecks = _context.BaggageChecks.Where(bgc => bgc.BookingId == bn.Id).Select(bgcn => new BaggageCheckForPassangerVM()
                    {
                        CheckResult = bgcn.CheckResult,
                        CreatedAt = bgcn.CreatedAt,
                        UpdatedAt = bgcn.UpdatedAt
                    }).ToList(),
                    Baggages = _context.Baggages.Where(bg => bg.BookingId == bn.Id).Select(bgn => new BaggageForPassangerVM()
                    {
                        CreatedDate = bgn.CreatedDate,
                        UpdatedDate = bgn.UpdatedDate,
                        WeightInKG = bgn.WeightInKG
                    }).ToList(),
                    BoardingPasses = _context.BoardingPasses.Where(bp => bp.BookingId == bn.Id).Select(bpn => new BoardingPassForPassangerVM()
                    {
                        CreatedAt = bpn.CreatedAt,
                        QRCode = bpn.QRCode,
                        UpdatedAt = bpn.UpdatedAt
                    }).ToList(),
                    FlightManifests = _context.FlightManifests.Where(fm => fm.BookingId == bn.Id).Select(fmn => new FlightManifestForPassangersVM()
                    {
                        CreatedAt = fmn.CreatedAt,
                        UpdatedAt = fmn.UpdatedAt,
                    }).ToList(),
                }).ToList(),
                SecurityChecks = _context.SecurityChecks.Where(sc => sc.PassangerId == pn.Id).Select(scn => new SecurityCheckForPassangersVM()
                {
                    CreatedAt = scn.CreatedAt,
                    UpdatedAt = scn.UpdatedAt,
                    CheckResult = scn.CheckResult,
                    Comments = scn.Comments
                }).ToList(),
                NoFlyLists = _context.NoFlyLists.Where(nfl => nfl.PassangerId == pn.Id).Select(nfln => new NoFlyListForPassangerVM()
                {
                    CreatedAt = nfln.CreatedAt,
                    UpdatedAt = nfln.UpdatedAt,
                    ActiveFrom = nfln.ActiveFrom,
                    ActiveTo = nfln.ActiveTo,
                    NoFlyReason = nfln.NoFlyReason
                }).ToList(),
            }).FirstOrDefaultAsync();
            return passanger!;
        }
    }
}