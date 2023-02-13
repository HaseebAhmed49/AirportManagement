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
    public class FlightsController : Controller
    {
        private readonly IFlightsRepository _flightRepository;

        public FlightsController(IFlightsRepository flightRepository)
        {
            _flightRepository = flightRepository;
        }

        [HttpGet("Get-flight-With-Details-By-Id/{id}")]
        public async Task<IActionResult> GetFlightWithDetailsById(int id)
        {
            try
            {
                if (id < 0) return BadRequest("Flight Id can't be negative");
                var flightWithDetails = await _flightRepository.GetFlightsWithDetailsById(id);
                if (flightWithDetails != null)
                    return Ok(flightWithDetails);
                return NotFound($"No Flight Exist with Respective Id {id}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Get-All-Flights")]
        public async Task<IActionResult> GetAllFlights([FromQuery] UserParams userParams)
        {
            try
            {
                var flights = await _flightRepository.GetAllFlights(userParams);

                Response.AddPagination(flights.CurrentPage, flights.PageSize,
                    flights.TotalCount, flights.TotalPages);

                if (flights != null)
                    return Ok(flights);
                return NotFound("No Baggages Check Data Found");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Get-Flight-By-Id/{id}")]
        public async Task<IActionResult> GetflightById(int id)
        {
            try
            {
                if (id < 0) return BadRequest("Flight Id can't be negative");
                var flight = await _flightRepository.GetFlightById(id);
                if (flight != null)
                    return Ok(flight);
                return NotFound($"No Flight Exist with Respective Id {id}");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("add-new-flight")]
        public async Task<IActionResult> AddFlight([FromBody]FlightsVM flightVM)
        {
            try
            {
                var newFlight = await _flightRepository.AddFlight(flightVM);
                return Created($"api/flights/Get-flight-By-Id/{newFlight.Id}", newFlight);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update-flight-by-id/{id}")]
        public async Task<IActionResult> UpdateFlightById(int id, [FromBody] FlightsVM flightVM)
        {
            try
            {
                if (id < 0) return BadRequest($"Flight Id cant be -ve or 0");
                var updatedFlight = await _flightRepository.UpdateFlightById(id, flightVM);
                return Ok(updatedFlight);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

