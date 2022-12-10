using System;
using AirportManagement.API.Models;

namespace AirportManagement.API.Data.Services
{
	public interface IPassangerRepository
    {
        public Task<List<Passangers>> GetAllPassangers();

        public Task<Passangers> GetPassangerById(int id);

        //public Task<AirlineForFlightsVM> GetAirlineWithFlightsById(int id);

        public Task<Passangers> AddPassanger(PassangersVM passangerVM);

        public Task<Passangers> UpdatePassangerById(int id, PassangersVM passangerVM);

        //public Task<Passangers> DeletePassangerById(int id);
    }
}

