using BloodBank.Application.Models;
using BloodBank.Core.Repositories;
using MediatR;

namespace BloodBank.Application.Queries.GetAllAddresses
{
    public class GetAllAddressesQuery : IRequest<ResultViewModel<List<AddressViewModel>>>
    {
        public GetAllAddressesQuery()
        {

        }
    }
    public class GetAllAddressesHandler : IRequestHandler<GetAllAddressesQuery, ResultViewModel<List<AddressViewModel>>>
    {
        private readonly IAddressRepository _repository;
        public GetAllAddressesHandler(IAddressRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel<List<AddressViewModel>>> Handle(GetAllAddressesQuery request, CancellationToken cancellationToken)
        {
            var addresses = await _repository.GetAll();
            var models = addresses.Select(AddressViewModel.FromEntity).ToList();
            return ResultViewModel<List<AddressViewModel>>.Success(models);
        }
    }
}