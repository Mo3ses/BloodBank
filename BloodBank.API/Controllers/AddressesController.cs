using BloodBank.Application.Commands.CreateAddress;
using BloodBank.Application.Commands.DeleteAddress;
using BloodBank.Application.Commands.UpdateAddress;
using BloodBank.Application.Models;
using BloodBank.Application.Queries.GetAddressById;
using BloodBank.Application.Queries.GetAllAddresses;
using BloodBank.Core.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BloodBank.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddressesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AddressesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var results = await _mediator.Send(request: new GetAllAddressesQuery());
            return Ok(results);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(request: new GetAddressByIdQuery(id: id));
            if (result == null)
            {
                return NotFound(result.Message);
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAddressCommand command)
        {
            var result = await _mediator.Send(request: command);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return CreatedAtAction(nameof(GetById), new { id = result.Data }, command);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateAddressCommand command)
        {
            var result = await _mediator.Send(request: command);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return NoContent();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteAddressCommand command)
        {
            var result = await _mediator.Send(request: command);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return NoContent();
        }
    }
}