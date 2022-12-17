using System;
using AirportManagement.API.Models;
using Microsoft.EntityFrameworkCore;

namespace AirportManagement.API.Data.Services
{
    public class BoardingPassRepository : IBoardingPassRepository
    {
        private readonly AppDbContext _context;

        public BoardingPassRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<BoardingPass> AddBoardingPass(BoardingPassVM boardingPassVM)
        {
            BoardingPass boardingPass = new BoardingPass
            {
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                QRCode = boardingPassVM.QRCode,
                BookingId = boardingPassVM.BookingId
            };
            await _context.BoardingPasses.AddAsync(boardingPass);
            await _context.SaveChangesAsync();
            return boardingPass;
        }

        public async Task<BoardingPass> DeleteBoardingPassById(int id)
        {
            var isBoardingPassExist = await _context.BoardingPasses.FirstOrDefaultAsync(b => b.Id == id);
            if (isBoardingPassExist != null)
            {
                _context.BoardingPasses.Remove(isBoardingPassExist);
                await _context.SaveChangesAsync();
            }
            return isBoardingPassExist!;
        }

        public async Task<BoardingPass> GetBoardingPassById(int id)
        {
            return await _context.BoardingPasses.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<List<BoardingPass>> GetAllBoardingPass() => await _context.BoardingPasses.ToListAsync();

        public async Task<BoardingPass> UpdateBoardingPassById(int id, BoardingPassVM boardingPassVM)
        {
            var isBoardingPassExist = await _context.BoardingPasses.FirstOrDefaultAsync(a => a.Id == id);
            if (isBoardingPassExist != null)
            {
                isBoardingPassExist.BookingId = boardingPassVM.BookingId;
                isBoardingPassExist.UpdatedAt = DateTime.Now;
                isBoardingPassExist.QRCode = boardingPassVM.QRCode;
                await _context.SaveChangesAsync();
            }
            return isBoardingPassExist!;
        }

        public async Task<BoardingPassWithBookingVM> GetBoardingPassWithBooking(int id)
        {
            var boardingPass = await _context.BoardingPasses.Where(bp => bp.Id == id).Select(bpn => new BoardingPassWithBookingVM()
            {
                CreatedAt = bpn.CreatedAt,
                UpdatedAt = bpn.UpdatedAt,
                QRCode = bpn.QRCode,
                Booking = _context.Bookings.Where(bk => bk.Id == bpn.BookingId).Select(bkn => new BookingForBoardingPassVM()
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
                    BaggageChecks = _context.BaggageChecks.Where(bc => bc.Id == bkn.Id).Select(bcn => new BaggageCheckForBookingVM()
                    {
                        CreatedAt = bcn.CreatedAt,
                        UpdatedAt = bcn.UpdatedAt,
                        CheckResult = bcn.CheckResult,
                        Passangers = _context.Passangers.FirstOrDefault(p => p.Id == bcn.PassangerId)
                    }).ToList(),
                    FlightManifests = _context.FlightManifests.Where(fm => fm.Id == bkn.Id).Select(fmn => new FlightManifestForBoardingPassVM()
                    {
                        CreatedAt = fmn.CreatedAt,
                        UpdatedAt = fmn.UpdatedAt,
                        Flight = _context.Flights.FirstOrDefault(f => f.Id == fmn.FlightId)
                    }).ToList(),
                }).FirstOrDefault(),
            }).FirstOrDefaultAsync();
            return boardingPass!;
        }
    }
}

