using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirportManagement.API.Data.Helpers;
using AirportManagement.API.Data.Services;
using AirportManagement.API.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AirportManagement.API.Controllers
{
    [Route("api/[controller]")]
    public class AirportsController : Controller
    {
        private readonly IAirportRepository _airportRepository;

        public AirportsController(IAirportRepository airportRepository)
        {
            _airportRepository = airportRepository;
        }

        [HttpGet("Get-All-Airports")]
        public async Task<IActionResult> GetAllAirports([FromQuery]UserParams userParams)
        {
            try
            {
                var airports = await _airportRepository.GetAllAirports(userParams);

                Response.AddPagination(airports.CurrentPage, airports.PageSize,
                    airports.TotalCount, airports.TotalPages);
                if (airports != null)
                    return Ok(airports);
                return NotFound("No Airports Data Found");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Get-Airport-By-Id/{id}")]
        public async Task<IActionResult> GetAirportById(int id)
        {
            try
            {
                if (id < 0) return BadRequest("Airport Id can't be negative");
                var airport = await _airportRepository.GetAirportById(id);
                if (airport != null)
                    return Ok(airport);
                return NotFound($"No Airport Exist with Respective Id {id}");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Get-Airport-With-Flights-By-Id/{id}")]
        public async Task<IActionResult> GetAirportWithFlightsById(int id)
        {
            try
            {
                if (id < 0) return BadRequest("Airport Id can't be negative");
                var airport = await _airportRepository.GetAirportWithFlightsById(id);
                if (airport != null)
                    return Ok(airport);
                return NotFound($"No Airport Exist with Respective Id {id}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("add-new-airport")]
        public async Task<IActionResult> AddAirline([FromBody]AirportVM airportVM)
        {
            try
            {
                var newAirport = await _airportRepository.AddAirport(airportVM);
                return Created($"api/airports/Get-Airport-By-Id/{newAirport.Id}", newAirport);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete-airport-by-id/{id}")]
        public async Task<IActionResult> DeleteAirportById(int id)
        {
            try
            {
                if (id < 0) return BadRequest("Airport Id can't be negative");
                var isFound = await _airportRepository.DeleteAirportById(id);
                return (isFound != null) ? Ok(isFound): NotFound($"No Airport Exist with Respective Id {id}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update-airport-by-id/{id}")]
        public async Task<IActionResult> UpdateAirportById(int id,[FromBody] AirportVM airportVM)
        {
            try
            {
                if (id < 0) return BadRequest($"Airport Id cant be -ve or 0");
                var updatedAirport = await _airportRepository.UpdateAirportById(id, airportVM);
                return Ok(updatedAirport);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

