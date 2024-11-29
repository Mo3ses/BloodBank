using BloodBank.Application.Models;
using BloodBank.Core.Repositories;
using MediatR;

namespace BloodBank.Application.Commands.UpdateDonation
{
    public class UpdateDonationHandler : IRequestHandler<UpdateDonationCommand, ResultViewModel>
    {
        private readonly IDonationRepository _repository;
        public UpdateDonationHandler(IDonationRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel> Handle(UpdateDonationCommand request, CancellationToken cancellationToken)
        {
            var donation = await _repository.GetById(id: request.Id);
            if (donation == null)
            {
                return ResultViewModel.Error("Donation not found");
            }
            donation.Update(donorId: request.DonorId, donationDate: request.DonationDate, quantityML: request.QuantityML);
            await _repository.Update(donation);
            return ResultViewModel.Success();
        }
    }
}