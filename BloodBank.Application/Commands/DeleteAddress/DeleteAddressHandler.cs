using BloodBank.Application.Models;
using BloodBank.Core.Repositories;
using MediatR;

namespace BloodBank.Application.Commands.DeleteAddress
{
    public class DeleteAddressHandler : IRequestHandler<DeleteAddressCommand, ResultViewModel>
    {
        private readonly IAddressRepository _repository;
        public DeleteAddressHandler(IAddressRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel> Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
        {
            var address = await _repository.GetById(id: request.Id);
            if (address == null)
            {
                return ResultViewModel.Error("Address not found");
            }
            address.SetAsDeleted();
            await _repository.Update(address);
            return ResultViewModel.Success();
        }
    }
}