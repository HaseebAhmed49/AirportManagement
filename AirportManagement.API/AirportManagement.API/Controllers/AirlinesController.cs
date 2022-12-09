using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirportManagement.API.Data.Services;
using AirportManagement.API.Models;
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
            try
            {
                if (id < 0) return BadRequest("Airline Id can't be negative");
                var airline = await _airlineRepository.GetAirLineById(id);
                if (airline != null)
                    return Ok(airline);
                return NotFound($"No Airline Exist with Respective Id {id}");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Get-Airline-with-Flights-By-Id/{id}")]
        public async Task<IActionResult> GetAirlineWithFlightsById(int id)
        {
            try
            {
                if (id < 0) return BadRequest("Airline Id can't be negative");
                var airlines = await _airlineRepository.GetAirlineWithFlightsById(id);
                if (airlines != null)
                    return Ok(airlines);
                return NotFound($"No Airline Exist with Respective Id {id}");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("add-new-airline")]
        public async Task<IActionResult> AddAirline([FromBody]AirlineVM airlineVM)
        {
            try
            {
                var newAirline = await _airlineRepository.AddAirline(airlineVM);
                return Created($"api/airlines/Get-Airline-By-Id/{newAirline.Id}", newAirline);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete-airline-by-id/{id}")]
        public async Task<IActionResult> DeleteAirlineById(int id)
        {
            try
            {
                if (id < 0) return BadRequest("Airline Id can't be negative");
                var isFound = await _airlineRepository.DeleteAirlineById(id);
                return (isFound != null) ? Ok(isFound): NotFound($"No Airline Exist with Respective Id {id}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update-airline-by-id/{id}")]
        public async Task<IActionResult> UpdateAirlineById(int id,[FromBody] AirlineVM airlineVM)
        {
            try
            {
                if (id < 0) return BadRequest($"Airline Id cant be -ve or 0");
                var updatedAirline = await _airlineRepository.UpdateAirlineById(id, airlineVM);
                return Ok(updatedAirline);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

