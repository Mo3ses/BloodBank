using BloodBank.Application.Models;
using BloodBank.Core.Repositories;
using MediatR;

namespace BloodBank.Application.Queries.GetAddressById
{
    public class GetAddressByIdHandler : IRequestHandler<GetAddressByIdQuery, ResultViewModel<AddressViewModel>>
    {
        private readonly IAddressRepository _repository;
        public GetAddressByIdHandler(IAddressRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel<AddressViewModel>> Handle(GetAddressByIdQuery request, CancellationToken cancellationToken)
        {
            var address = await _repository.GetById(id: request.Id);
            if (address == null)
            {
                return ResultViewModel<AddressViewModel>.Error("Address not found.");
            }
            var model = AddressViewModel.FromEntity(entity: address);
            return ResultViewModel<AddressViewModel>.Success(model);
        }
    }
}