using BloodBank.Application.Commands.CreateDonation;
using BloodBank.Application.Commands.DeleteDonation;
using BloodBank.Application.Commands.UpdateDonation;
using BloodBank.Application.Models;
using BloodBank.Application.Queries.GetAllDonors;
using BloodBank.Application.Queries.GetDonationById;
using BloodBank.Core.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BloodBank.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DonationsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DonationsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var results = await _mediator.Send(request: new GetAllDonorsQuery());
            return Ok(results);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(request: new GetDonationByIdQuery(id: id));
            if (result == null)
            {
                return NotFound(result.Message);
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateDonationCommand command)
        {
            var result = await _mediator.Send(request: command);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return CreatedAtAction(nameof(GetById), new { id = result.Data }, command);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateDonationCommand command)
        {
            var result = await _mediator.Send(request: command);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            };
            return NoContent();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteDonationCommand command)
        {
            var result = await _mediator.Send(request: command);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            };
            return NoContent();
        }
    }
}