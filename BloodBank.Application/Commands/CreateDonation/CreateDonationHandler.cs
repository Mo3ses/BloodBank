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

            donation = await _repository.GetById(id: donation.Id);
            await _repository.AddStock(new(
                    bloodType: donation.Donor.BloodType,
                    rhFactor: donation.Donor.RhFactor,
                    quantityML: donation.QuantityML));
            return ResultViewModel<int>.Success(result);
        }
    }
}