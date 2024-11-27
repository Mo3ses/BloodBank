using BloodBank.Application.Models;
using BloodBank.Core.Repositories;
using MediatR;

namespace BloodBank.Application.Commands.CreateDonation
{
    public class CreateDonationHandler : IRequestHandler<CreateDonationCommand, ResultViewModel<int>>
    {
        private readonly IDonationRepository _repository;
        public CreateDonationHandler(IDonationRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel<int>> Handle(CreateDonationCommand request, CancellationToken cancellationToken)
        {
            var donation = request.ToEntity();
            var result = await _repository.Create(donation: donation);
            return ResultViewModel<int>.Success(result);
        }
    }
}