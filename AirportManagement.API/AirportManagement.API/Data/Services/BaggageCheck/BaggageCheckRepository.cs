using System;
using AirportManagement.API.Models;
using Microsoft.EntityFrameworkCore;

namespace AirportManagement.API.Data.Services
{
    public class BaggageCheckRepository : IBaggageCheckRepository
    {
        private readonly AppDbContext _context;

        public BaggageCheckRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<BaggageCheck> AddBaggageCheck(BaggageCheckVM baggageCheckVM)
        {
            BaggageCheck baggageCheck = new BaggageCheck()
            {
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                CheckResult = baggageCheckVM.CheckResult,
                BookingId = baggageCheckVM.BookingId,
                PassangerId = baggageCheckVM.PassangerId
            };
            await _context.BaggageChecks.AddAsync(baggageCheck);
            await _context.SaveChangesAsync();
            return baggageCheck;
        }

        public async Task<BaggageCheck> DeleteBaggageCheckById(int id)
        {
            var isBaggageCheckExist = await _context.BaggageChecks.FirstOrDefaultAsync(bc => bc.Id == id);
            if (isBaggageCheckExist != null)
            {
                _context.BaggageChecks.Remove(isBaggageCheckExist);
                await _context.SaveChangesAsync();
            }
            return isBaggageCheckExist!;
        }

        public async Task<List<BaggageCheck>> GetAllBaggageChecks() => await _context.BaggageChecks.ToListAsync();

        public async Task<BaggageCheck> GetBaggageCheckById(int id)
        {
            return await _context.BaggageChecks.FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<BaggageCheckWithDetailsVM> GetBaggageChecksWithDetailsById(int id)
        {
            var baggageCheck = await _context.BaggageChecks.Where(b => b.Id == id).Select(bcn => new BaggageCheckWithDetailsVM()
            {
                CheckResult = bcn.CheckResult,
                CreatedAt = bcn.CreatedAt,
                UpdatedAt = bcn.UpdatedAt,
                Booking = _context.Bookings.Where(bk => bk.Id == bcn.BookingId).Select(bkn => new BookingForBaggagesCheckVM()
                {
                    BookingPlatform = bkn.BookingPlatform,
                    CreatedAt = bkn.CreatedAt,
                    UpdatedAt = bkn.UpdatedAt,
                    Status = bkn.Status,
                    Baggages = _context.Baggages.Where(bg => bg.Id == bkn.Id).Select(bgn => new BaggageForPassangerVM()
                    {
                        CreatedDate = bgn.CreatedDate,
                        UpdatedDate = bgn.UpdatedDate,
                        WeightInKG = bgn.WeightInKG
                    }).ToList(),
                    BoardingPasses = _context.BoardingPasses.Where(bp => bp.Id == bkn.Id).Select(bpn => new BoardingPassForPassangerVM()
                    {
                        CreatedAt = bpn.CreatedAt,
                        QRCode = bpn.QRCode,
                        UpdatedAt = bpn.UpdatedAt
                    }).ToList(),
                    FlightManifests = _context.FlightManifests.Where(fm => fm.Id == bkn.Id).Select(fmn => new FlightManifestForPassangersVM()
                    {
                        CreatedAt = fmn.CreatedAt,
                        UpdatedAt = fmn.UpdatedAt,
                    }).ToList(),
                }).FirstOrDefault(),
                Passanger = _context.Passangers.Where(p => p.Id == bcn.PassangerId).Select(pn => new PassangersForBaggageVM()
                {
                    FirstName = pn.FirstName,
                    LastName = pn.LastName,
                    PassportNumber = pn.PassportNumber,
                    CountryOfCitizenship = pn.CountryOfCitizenship,
                    CountryOfResidence = pn.CountryOfResidence,
                    CreatedAt = pn.CreatedAt,
                    DateOfBirth = pn.DateOfBirth,
                    UpdatedAt = pn.UpdatedAt,
                    SecurityChecks = _context.SecurityChecks.Where(sc => sc.Id == pn.Id).Select(scn => new SecurityCheckForPassangersVM()
                    {
                        CreatedAt = scn.CreatedAt,
                        UpdatedAt = scn.UpdatedAt,
                        CheckResult = scn.CheckResult,
                        Comments = scn.Comments
                    }).ToList(),
                    NoFlyLists = _context.NoFlyLists.Where(nfl => nfl.Id == pn.Id).Select(nfln => new NoFlyListForPassangerVM()
                    {
                        CreatedAt = nfln.CreatedAt,
                        UpdatedAt = nfln.UpdatedAt,
                        ActiveFrom = nfln.ActiveFrom,
                        ActiveTo = nfln.ActiveTo,
                        NoFlyReason = nfln.NoFlyReason
                    }).ToList(),
                }).FirstOrDefault()
            }).FirstOrDefaultAsync();
            return baggageCheck!;
        }

        public async Task<BaggageCheck> UpdateBaggageCheckById(int id, BaggageCheckVM baggageCheckVM)
        {
            var isBaggageCheckExist = await _context.BaggageChecks.FirstOrDefaultAsync(b => b.Id == id);
            if (isBaggageCheckExist != null)
            {
                isBaggageCheckExist.CheckResult = baggageCheckVM.CheckResult;
                isBaggageCheckExist.UpdatedAt = DateTime.Now;
                isBaggageCheckExist.PassangerId = baggageCheckVM.PassangerId;
                isBaggageCheckExist.BookingId = baggageCheckVM.BookingId;
                await _context.SaveChangesAsync();
            }
            return isBaggageCheckExist!;
        }
    }
}

