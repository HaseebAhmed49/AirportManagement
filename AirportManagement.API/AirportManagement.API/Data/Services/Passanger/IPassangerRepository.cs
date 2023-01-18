using System;
using AirportManagement.API.Data.Helpers;
using AirportManagement.API.Models;

namespace AirportManagement.API.Data.Services
{
	public interface IPassangerRepository
    {
        public Task<PagedList<Passangers>> GetAllPassangers(UserParams userParams);

        public Task<Passangers> GetPassangerById(int id);

        public Task<PassangersWithDetailsVM> GetPassangerWithDetailsById(int id);

        public Task<Passangers> AddPassanger(PassangersVM passangerVM);

        public Task<Passangers> UpdatePassangerById(int id, PassangersVM passangerVM);

        //public Task<Passangers> DeletePassangerById(int id);
    }
}

