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
        public async Task<ResultViewModel<List<DonorViewModel>>> GetAll()
        {
            var donors = await _repository.GetAll();
            var models = donors.Select(DonorViewModel.FromEntity).ToList();
            return ResultViewModel<List<DonorViewModel>>.Success(models);
        }
        [HttpGet("GetById")]
        public async Task<ResultViewModel<DonorViewModel>> GetById(int id)
        {
            var donor = await _repository.GetById(id: id);
            if (donor == null)
            {
                return ResultViewModel<DonorViewModel>.Error("Donor not found.");
            }
            var model = DonorViewModel.FromEntity(entity: donor);
            return ResultViewModel<DonorViewModel>.Success(model);
        }

        [HttpPost]
        public async Task<ResultViewModel<int>> Create(DonorInputModel model)
        {
            var donor = model.ToEntity();
            var result = await _repository.Create(donor: donor);
            return ResultViewModel<int>.Success(result);
        }
        [HttpPut]
        public async Task<ResultViewModel> Update(int id, DonorInputModel model)
        {
            var donor = await _repository.GetById(id: id);
            if (donor == null)
            {
                return ResultViewModel.Error("Donor not found.");
            }
            donor.Update(fullName: model.FullName, email: model.Email, birthDate: model.BirthDate, gender: model.Gender, weight: model.Weight, bloodType: model.BloodType, rhFactor: model.RhFactor);
            await _repository.Update(donor: donor);
            return ResultViewModel.Success();

        }
        [HttpDelete]
        public async Task<ResultViewModel> Delete(int id)
        {
            var donor = await _repository.GetById(id: id);
            if (donor == null)
            {
                return ResultViewModel.Error("Donor not found.");
            }
            donor.SetAsDeleted();
            await _repository.Update(donor: donor);
            return ResultViewModel.Success();
        }
    }
}