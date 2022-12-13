using System;
using AirportManagement.API.Models;
using Microsoft.EntityFrameworkCore;

namespace AirportManagement.API.Data.Services
{
	public class BaggageRepository: IBaggageRepository
	{
        private readonly AppDbContext _context;

		public BaggageRepository(AppDbContext context)
		{
            _context = context;
		}

        public async Task<Baggage> AddBaggage(BaggageVM baggageVM)
        {
            Baggage baggage = new Baggage()
            {
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                WeightInKG = baggageVM.WeightInKG,
                BookingId = baggageVM.Booking!.Id
            };
            await _context.Baggages.AddAsync(baggage);
            await _context.SaveChangesAsync();
            return baggage;
        }

        public async Task<Baggage> DeleteBaggageById(int id)
        {
            var isBaggageExist = await _context.Baggages.FirstOrDefaultAsync(b => b.Id == id);
            if (isBaggageExist != null)
            {
                _context.Baggages.Remove(isBaggageExist);
                await _context.SaveChangesAsync();
            }
            return isBaggageExist!;
        }

        public async Task<List<Baggage>> GetAllBaggages() => await _context.Baggages.ToListAsync();

        public async Task<Baggage> GetBaggageById(int id)
        {
            return await _context.Baggages.FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<BaggageWithDetailsVM> GetBaggageWithBookingDetailsById(int id)
        {
            var baggage = await _context.Baggages.Where(b => b.Id == id).Select(bn => new BaggageWithDetailsVM()
            {
                CreatedDate = bn.CreatedDate,
                UpdatedDate = bn.UpdatedDate,
                WeightInKG = bn.WeightInKG,
                Booking = _context.Bookings.Where(bk => bk.Id == bn.Id).Select(bkn => new BookingForBaggagesVM()
                {
                    BookingPlatform = bkn.BookingPlatform,
                    CreatedAt = bkn.CreatedAt,
                    UpdatedAt = bkn.UpdatedAt,
                    Status = bkn.Status,                    
                    BaggageChecks = _context.BaggageChecks.Where(bgc => bgc.Id == bkn.Id).Select(bgcn => new BaggageCheckForPassangerVM()
                    {
                        CheckResult = bgcn.CheckResult,
                        CreatedAt = bgcn.CreatedAt,
                        UpdatedAt = bgcn.UpdatedAt
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
                    Passangers = _context.Passangers.Where(p => p.Id == bkn.PassangerId).Select(pn => new PassangersForBaggageVM()
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
                }).FirstOrDefault(),
            }).FirstOrDefaultAsync();
            return baggage!;
        }

        public async Task<Baggage> UpdateBaggageById(int id, BaggageVM baggageVM)
        {
            var isBaggageExist = await _context.Baggages.FirstOrDefaultAsync(b => b.Id == id);
            if (isBaggageExist != null)
            {
                isBaggageExist.UpdatedDate = baggageVM.UpdatedDate;
                isBaggageExist.BookingId = baggageVM.Booking!.Id;
                isBaggageExist.WeightInKG = baggageVM.WeightInKG;
                await _context.SaveChangesAsync();
            }
            return isBaggageExist!;
        }
    }
}

