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
    public class BaggageCheckController : Controller
    {
        private readonly IBaggageCheckRepository _baggageCheckRepository;

        public BaggageCheckController(IBaggageCheckRepository baggageCheckRepository)
        {
            _baggageCheckRepository = baggageCheckRepository;
        }

        [HttpGet("Get-Baggage-Check-With-Details-By-Id/{id}")]
        public async Task<IActionResult> GetBaggageCheckWithDetailsById(int id)
        {
            try
            {
                if (id < 0) return BadRequest("Baggage Check Id can't be negative");
                var baggageCheck = await _baggageCheckRepository.GetBaggageChecksWithDetailsById(id);
                if (baggageCheck != null)
                    return Ok(baggageCheck);
                return NotFound($"No Baggage Check Exist with Respective Id {id}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Get-All-Baggages-Check")]
        public async Task<IActionResult> GetAllBaggagesCheck()
        {
            var baggagesCheck = await _baggageCheckRepository.GetAllBaggageChecks();
            if (baggagesCheck != null)
                return Ok(baggagesCheck);
            return NotFound("No Baggages Check Data Found");
        }

        [HttpGet("Get-Baggage-Check-By-Id/{id}")]
        public async Task<IActionResult> GetBaggageCheckById(int id)
        {
            try
            {
                if (id < 0) return BadRequest("Baggage Check Id can't be negative");
                var baggageCheck = await _baggageCheckRepository.GetBaggageCheckById(id);
                if (baggageCheck != null)
                    return Ok(baggageCheck);
                return NotFound($"No Baggage Check Exist with Respective Id {id}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Delete-Baggage-Check-By-Id/{id}")]
        public async Task<IActionResult> DeleteBaggageCheckById(int id)
        {
            try
            {
                if (id < 0) return BadRequest("Baggage Check Id can't be negative");
                var isFound = await _baggageCheckRepository.DeleteBaggageCheckById(id);
                return (isFound != null) ? Ok(isFound) : NotFound($"No Baggage Check Exist with Respective Id {id}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("add-new-baggage-Check")]
        public async Task<IActionResult> AddBaggageCheck([FromBody] BaggageCheckVM baggageCheckVM)
        {
            try
            {
                var newBaggageCheck = await _baggageCheckRepository.AddBaggageCheck(baggageCheckVM);
                return Created($"api/baggageCheck/Get-baggage-By-Id/{newBaggageCheck.Id}", newBaggageCheck);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update-baggage-check-by-id/{id}")]
        public async Task<IActionResult> UpdateBaggageById(int id, [FromBody] BaggageCheckVM baggageCheckVM)
        {
            try
            {
                if (id < 0) return BadRequest($"Baggage Check Id cant be -ve or 0");
                var updatedBaggageCheck = await _baggageCheckRepository.UpdateBaggageCheckById(id, baggageCheckVM);
                return Ok(updatedBaggageCheck);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

