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
        public async Task<ResultViewModel<List<DonationViewModel>>> GetAll()
        {
            var donors = await _repository.GetAll();
            var models = donors.Select(DonationViewModel.FromEntity).ToList();
            return ResultViewModel<List<DonationViewModel>>.Success(models);
        }
        [HttpGet("GetById")]
        public async Task<ResultViewModel<DonationViewModel>> GetById(int id)
        {
            var donation = await _repository.GetById(id: id);
            if (donation == null)
            {
                return ResultViewModel<DonationViewModel>.Error("Donation not found.");
            }
            var model = DonationViewModel.FromEntity(entity: donation);
            return ResultViewModel<DonationViewModel>.Success(model);
        }

        [HttpPost]
        public async Task<ResultViewModel<int>> Create(DonationInputModel model)
        {
            var donation = model.ToEntity();
            var result = await _repository.Create(donation: donation);
            donation = await _repository.GetById(id: result);
            await _repository.AddStock(new(
                    bloodType: donation.Donor.BloodType,
                    rhFactor: donation.Donor.RhFactor,
                    quantityML: donation.QuantityML));
            return ResultViewModel<int>.Success(data: donation.Id);
        }
        [HttpPut]
        public async Task<ResultViewModel> Update(int id, DonationViewModel model)
        {
            var donation = await _repository.GetById(id: id);
            if (donation == null)
            {
                return ResultViewModel.Error("Donation not found.");
            }
            donation.Update(donorId: model.DonorId, donationDate: model.DonationDate, quantityML: model.QuantityML);
            await _repository.Update(donation: donation);
            return ResultViewModel.Success();
        }
        [HttpDelete]
        public async Task<ResultViewModel> Delete(int id)
        {
            var donation = await _repository.GetById(id: id);
            if (donation == null)
            {
                return ResultViewModel.Error("Donation not found.");
            }
            donation.SetAsDeleted();
            await _repository.Update(donation: donation);
            return ResultViewModel.Success();
        }
    }
}