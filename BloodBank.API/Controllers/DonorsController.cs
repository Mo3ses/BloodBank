using BloodBank.Application.Models;
using BloodBank.Core.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BloodBank.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DonorsController : ControllerBase
    {
        private readonly IDonorRepository _repository;
        public DonorsController(IDonorRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var donors = await _repository.GetAll();
            var models = donors.Select((DonorViewModel.FromEntity)).ToList();
            return Ok(models);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var donor = await _repository.GetById(id: id);
            var model = DonorViewModel.FromEntity(entity: donor);
            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(DonorInputModel model)
        {
            var donor = model.ToEntity();
            await _repository.Create(donor: donor);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update(DonorViewModel model)
        {
            var donor = await _repository.GetById(id: model.DonorId);
            donor.Update(email: model.Email, weight: model.Weight);
            await _repository.Update(donor: donor);
            return NoContent();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var donor = await _repository.GetById(id: id);
            donor.SetAsDeleted();
            await _repository.Update(donor: donor);
            return NoContent();
        }
    }
}