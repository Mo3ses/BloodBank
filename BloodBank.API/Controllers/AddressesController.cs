using BloodBank.Application.Models;
using BloodBank.Core.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BloodBank.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddressesController : ControllerBase
    {
        private readonly IAddressRepository _repository;
        public AddressesController(IAddressRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var addresses = await _repository.GetAll();
            var models = addresses.Select((AddressViewModel.FromEntity)).ToList();
            return Ok(models);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var address = await _repository.GetById(id: id);
            var model = AddressViewModel.FromEntity(entity: address);
            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddressInputModel model)
        {
            var address = model.ToEntity();
            await _repository.Create(address: address);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update(AddressInputModel model)
        {
            var address = model.ToEntity();
            await _repository.Update(address: address);
            return NoContent();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var address = await _repository.GetById(id: id);
            address.SetAsDeleted();
            await _repository.Update(address: address);
            return NoContent();
        }
    }
}