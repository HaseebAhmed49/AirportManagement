using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirportManagement.API.Data.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AirportManagement.API.Controllers
{
    [Route("api/[controller]")]
    public class AirlinesController : Controller
    {
        private readonly IAirLineRepository _airlineRepository;

        public AirlinesController(IAirLineRepository airLineRepository)
        {
            _airlineRepository = airLineRepository;
        }

        [HttpGet("Get-All-Airlines")]
        public async Task<IActionResult> GetAllAirlines()
        {
            var airlines = await _airlineRepository.GetAllAirlines();
            if (airlines != null)
                return Ok(airlines);
            return NotFound();
        }

        [HttpGet("Get-Airline-By-Id/{id}")]
        public async Task<IActionResult> GetAirlineById(int id)
        {
            var airline = await _airlineRepository.GetAirLineById(id);
            if (airline != null)
                return Ok(airline);
            return NotFound();
        }


        [HttpGet("Get-Airline-with-Flights-By-Id/{id}")]
        public async Task<IActionResult> GetAirlineWithFlightsById(int id)
        {
            var airlines = await _airlineRepository.GetAirlineWithFlightsById(id);
            if (airlines != null)
                return Ok(airlines);
            return NotFound();
        }
    }
}

