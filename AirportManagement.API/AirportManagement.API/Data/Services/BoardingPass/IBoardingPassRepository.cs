using System;
using AirportManagement.API.Models;

namespace AirportManagement.API.Data.Services
{
	public interface IBoardingPassRepository
	{
        public Task<List<BoardingPass>> GetAllBoardingPass();

        public Task<BoardingPass> GetBoardingPassById(int id);

        public Task<BoardingPass> AddBoardingPass(BoardingPassVM BoardingPassVM);

        public Task<BoardingPass> UpdateBoardingPassById(int id, BoardingPassVM BoardingPassVM);

        public Task<BoardingPass> DeleteBoardingPassById(int id);

        public Task<BoardingPassWithBookingVM> GetBoardingPassWithBooking(int id);
    }
}

