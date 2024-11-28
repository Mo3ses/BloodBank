using BloodBank.Application.Commands.CreateDonor;
using BloodBank.Application.Commands.DeleteDonor;
using BloodBank.Application.Commands.UpdateDonor;
using BloodBank.Application.Models;
using BloodBank.Application.Queries.GetAllDonors;
using BloodBank.Application.Queries.GetDonorById;
using BloodBank.Core.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BloodBank.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DonorsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DonorsController(IMediator mediator)
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
            var result = await _mediator.Send(request: new GetDonorByIdQuery(id: id));
            if (result == null)
            {
                return NotFound(result.Message);
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateDonorCommand command)
        {
            var result = await _mediator.Send(request: command);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return CreatedAtAction(nameof(GetById), new { id = result.Data }, command);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateDonorCommand command)
        {
            var result = await _mediator.Send(request: command);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            };
            return NoContent();

        }
        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteDonorCommand command)
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