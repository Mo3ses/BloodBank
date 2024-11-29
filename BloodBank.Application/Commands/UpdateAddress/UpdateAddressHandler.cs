using BloodBank.Application.Models;
using BloodBank.Core.Repositories;
using MediatR;

namespace BloodBank.Application.Commands.UpdateAddress
{
    public class UpdateAddressHandler : IRequestHandler<UpdateAddressCommand, ResultViewModel>
    {
        private readonly IAddressRepository _repository;
        public UpdateAddressHandler(IAddressRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
        {
            var address = await _repository.GetById(id: request.Id);
            if (address == null)
            {
                return ResultViewModel.Error("Address not found");
            }
            address.Update(street: request.Street, city: request.City, state: request.State, postalCode: request.PostalCode, donorId: request.DonorId);
            await _repository.Update(address);
            return ResultViewModel.Success();
        }
    }
}