using BloodBank.Application.Models;
using BloodBank.Core.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BloodBank.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DonationsController : ControllerBase
    {
        private readonly IDonationRepository _repository;
        public DonationsController(IDonationRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var donors = await _repository.GetAll();
            var models = donors.Select((DonationViewModel.FromEntity)).ToList();
            return Ok(models);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var donation = await _repository.GetById(id: id);
            var model = DonationViewModel.FromEntity(entity: donation);
            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(DonationInputModel model)
        {
            var donation = model.ToEntity();
            var result = await _repository.Create(donation: donation);
            donation = await _repository.GetById(id: result);
            await _repository.AddStock(new(
                    bloodType: donation.Donor.BloodType,
                    rhFactor: donation.Donor.RhFactor,
                    quantityML: donation.QuantityML));
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update(DonationViewModel model)
        {
            var donation = await _repository.GetById(id: model.DonorId);
            donation.Update(donorId: model.DonorId, donationDate: model.DonationDate, quantityML: model.QuantityML);
            await _repository.Update(donation: donation);
            return NoContent();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var donation = await _repository.GetById(id: id);
            donation.SetAsDeleted();
            await _repository.Update(donation: donation);
            return NoContent();
        }
    }
}