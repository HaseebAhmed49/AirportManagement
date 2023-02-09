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
    public class BaggageController : Controller
    {
        private readonly IBaggageRepository _baggageRepository;

        public BaggageController(IBaggageRepository baggageRepository)
        {
            _baggageRepository = baggageRepository;
        }

        [HttpGet("Get-Baggage-With-Details-By-Id/{id}")]
        public async Task<IActionResult> GetBaggageWithDetailsById(int id)
        {
            try
            {
                if (id < 0) return BadRequest("Baggage Id can't be negative");
                var baggage = await _baggageRepository.GetBaggageWithBookingDetailsById(id);
                if (baggage != null)
                    return Ok(baggage);
                return NotFound($"No Baggage Exist with Respective Id {id}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Get-All-Baggages")]
        public async Task<IActionResult> GetAllBaggages([FromQuery] UserParams userParams)
        {
            try
            {
                var baggages = await _baggageRepository.GetAllBaggages(userParams);

                Response.AddPagination(baggages.CurrentPage, baggages.PageSize,
    baggages.TotalCount, baggages.TotalPages);

                if (baggages != null)
                    return Ok(baggages);
                return NotFound("No Baggages Data Found");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Get-Baggage-By-Id/{id}")]
        public async Task<IActionResult> GetBaggageById(int id)
        {
            try
            {
                if (id < 0) return BadRequest("Baggage Id can't be negative");
                var baggage = await _baggageRepository.GetBaggageById(id);
                if (baggage != null)
                    return Ok(baggage);
                return NotFound($"No Baggage Exist with Respective Id {id}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Delete-Baggage-By-Id/{id}")]
        public async Task<IActionResult> DeleteBaggageById(int id)
        {
            try
            {
                if (id < 0) return BadRequest("Baggage Id can't be negative");
                var isFound = await _baggageRepository.DeleteBaggageById(id);
                return (isFound != null) ? Ok(isFound) : NotFound($"No Baggage Exist with Respective Id {id}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("add-new-baggage")]
        public async Task<IActionResult> AddBaggage([FromBody] BaggageVM baggageVM)
        {
            try
            {
                var newBaggage = await _baggageRepository.AddBaggage(baggageVM);
                return Created($"api/baggage/Get-baggage-By-Id/{newBaggage.Id}", newBaggage);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update-baggage-by-id/{id}")]
        public async Task<IActionResult> UpdateBaggageById(int id, [FromBody] BaggageVM baggageVM)
        {
            try
            {
                if (id < 0) return BadRequest($"Baggage Id cant be -ve or 0");
                var updatedBaggage = await _baggageRepository.UpdateBaggageById(id, baggageVM);
                return Ok(updatedBaggage);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

