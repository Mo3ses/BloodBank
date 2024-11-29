using BloodBank.Application.Models;
using BloodBank.Core.Repositories;
using MediatR;

namespace BloodBank.Application.Commands.CreateAddress
{
    public class CreateAddressHandler : IRequestHandler<CreateAddressCommand, ResultViewModel<int>>
    {
        private readonly IAddressRepository _repository;
        public CreateAddressHandler(IAddressRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel<int>> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
        {
            if (request.DonorId.Equals(0))
            {
                return ResultViewModel<int>.Error("Donor Id Missing");
            }
            var address = request.ToEntity();
            var result = await _repository.Create(address: address);
            return ResultViewModel<int>.Success(data: result);
        }
    }
}