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
    public class BoardingPassController : Controller
    {
        private readonly IBoardingPassRepository _boardingPassRepository;

        public BoardingPassController(IBoardingPassRepository boardingPassRepository)
        {
            _boardingPassRepository = boardingPassRepository;
        }

        [HttpGet("Get-All-BoardingPass")]
        public async Task<IActionResult> GetAllBoardingPass()
        {
            try
            {
                var alLBoardingPass = await _boardingPassRepository.GetAllBoardingPass();
                if (alLBoardingPass != null)
                    return Ok(alLBoardingPass);
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Get-BoardingPass-By-Id/{id}")]
        public async Task<IActionResult> GetBoardingPassById(int id)
        {
            try
            {
                if (id < 0) return BadRequest("Boarding Pass Id can't be negative");
                var boardingPass = await _boardingPassRepository.GetBoardingPassById(id);
                if (boardingPass != null)
                    return Ok(boardingPass);
                return NotFound($"No Boarding Pass Exist with Respective Id {id}");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Get-BoardingPass-with-Booking-By-Id/{id}")]
        public async Task<IActionResult> GetBoardingPassWithBookingById(int id)
        {
            try
            {
                if (id < 0) return BadRequest("Boarding Pass Id can't be negative");
                var boardingPass = await _boardingPassRepository.GetBoardingPassWithBooking(id);
                if (boardingPass != null)
                    return Ok(boardingPass);
                return NotFound($"No Boarding Pass Exist with Respective Id {id}");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("add-new-boardingPass")]
        public async Task<IActionResult> AddBoardingPass([FromBody]BoardingPassVM boardingPassVM)
        {
            try
            {
                var newBoardingPass = await _boardingPassRepository.AddBoardingPass(boardingPassVM);
                return Created($"api/boardingPass/Get-BoardingPass-By-Id/{newBoardingPass.Id}", newBoardingPass);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete-boardingPass-by-id/{id}")]
        public async Task<IActionResult> DeleteBoardingPassById(int id)
        {
            try
            {
                if (id < 0) return BadRequest("Boarding Pass Id can't be negative");
                var isFound = await _boardingPassRepository.DeleteBoardingPassById(id);
                return (isFound != null) ? Ok(isFound): NotFound($"No Boarding Pass Exist with Respective Id {id}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update-BoardingPass-by-id/{id}")]
        public async Task<IActionResult> UpdateBoardingPassById(int id,[FromBody] BoardingPassVM boardingPassVM)
        {
            try
            {
                if (id < 0) return BadRequest($"Airline Id cant be -ve or 0");
                var updatedBoardingPass = await _boardingPassRepository.UpdateBoardingPassById(id, boardingPassVM);
                return Ok(updatedBoardingPass);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

