using System;
using AirportManagement.API.Data.Helpers;
using AirportManagement.API.Models;

namespace AirportManagement.API.Data.Services
{
	public interface IBoardingPassRepository
	{
        public Task<PagedList<BoardingPass>> GetAllBoardingPass(UserParams userParams);

        public Task<BoardingPass> GetBoardingPassById(int id);

        public Task<BoardingPass> AddBoardingPass(BoardingPassVM BoardingPassVM);

        public Task<BoardingPass> UpdateBoardingPassById(int id, BoardingPassVM BoardingPassVM);

        public Task<BoardingPass> DeleteBoardingPassById(int id);

        public Task<BoardingPassWithBookingVM> GetBoardingPassWithBooking(int id);
    }
}

