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
        public async Task<ResultViewModel<List<AddressViewModel>>> GetAll()
        {
            var addresses = await _repository.GetAll();
            var models = addresses.Select(AddressViewModel.FromEntity).ToList();
            return ResultViewModel<List<AddressViewModel>>.Success(models);
        }
        [HttpGet("GetById")]
        public async Task<ResultViewModel<AddressViewModel>> GetById(int id)
        {
            var address = await _repository.GetById(id: id);
            if (address == null)
            {
                return ResultViewModel<AddressViewModel>.Error("Address not found.");
            }
            var model = AddressViewModel.FromEntity(entity: address);
            return ResultViewModel<AddressViewModel>.Success(model);
        }

        [HttpPost]
        public async Task<ResultViewModel<int>> Create(AddressInputModel model)
        {
            if (model.DonorId.Equals(0))
            {
                return ResultViewModel<int>.Error("Donor Id Missing");
            }
            var address = model.ToEntity();
            var result = await _repository.Create(address: address);
            return ResultViewModel<int>.Success(data: result);
        }
        [HttpPut]
        public async Task<ResultViewModel> Update(int id, AddressInputModel model)
        {
            var address = await _repository.GetById(id: id);
            if (address == null)
            {
                return ResultViewModel.Error("Address not found.");
            }
            address.Update(street: model.Street, city: model.City, state: model.State, postalCode: model.PostalCode);
            await _repository.Update(address: address);
            return ResultViewModel.Success();
        }
        [HttpDelete]
        public async Task<ResultViewModel> Delete(int id)
        {
            var address = await _repository.GetById(id: id);
            if (address == null)
            {
                return ResultViewModel.Error("Address not found.");
            }
            address.SetAsDeleted();
            await _repository.Update(address: address);
            return ResultViewModel.Success();
        }
    }
}