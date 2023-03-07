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
    public class PassangersController : Controller
    {
        private readonly IPassangerRepository _passangerRepository;

        public PassangersController(IPassangerRepository passangerRepository)
        {
            _passangerRepository = passangerRepository;
        }

        [HttpGet("Get-Passanger-With-Details-By-Id/{id}")]
        public async Task<IActionResult> GetPassangerWithDetailsById(int id)
        {
            try
            {
                if (id < 0) return BadRequest("Passanger Id can't be negative");
                var passanger = await _passangerRepository.GetPassangerWithDetailsById(id);
                if (passanger != null)
                    return Ok(passanger);
                return NotFound($"No Passanger Exist with Respective Id {id}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Get-All-Passangers")]
        public async Task<IActionResult> GetAllPassangers([FromQuery]UserParams userParams)
        {
            try
            {
                var passangers = await _passangerRepository.GetAllPassangers(userParams);

                Response.AddPagination(passangers.CurrentPage, passangers.PageSize,
                    passangers.TotalCount, passangers.TotalPages);

                if (passangers != null)
                    return Ok(passangers);
                return NotFound("No Passangers Data Found");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Get-Passanger-By-Id/{id}")]
        public async Task<IActionResult> GetPassangerById(int id)
        {
            try
            {
                if (id < 0) return BadRequest("Passanger Id can't be negative");
                var passanger = await _passangerRepository.GetPassangerById(id);
                if (passanger != null)
                    return Ok(passanger);
                return NotFound($"No Passanger Exist with Respective Id {id}");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("add-new-passanger")]
        public async Task<IActionResult> AddPassanger([FromBody]PassangersVM passangerVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newPassanger = await _passangerRepository.AddPassanger(passangerVM);
                    return Created($"api/passangers/Get-passanger-By-Id/{newPassanger.Id}", newPassanger);
                }
                else
                    return BadRequest("Passanger Data is not valid");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update-passanger-by-id/{id}")]
        public async Task<IActionResult> UpdatePassangerById(int id,[FromBody] PassangersVM passangerVM)
        {
            try
            {
                if (id < 0) return BadRequest($"Passanger Id cant be -ve or 0");
                var updatedPassanger = await _passangerRepository.UpdatePassangerById(id, passangerVM);
                return Ok(updatedPassanger);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

