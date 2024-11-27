using BloodBank.Application.Models;
using BloodBank.Core.Repositories;
using MediatR;

namespace BloodBank.Application.Commands.DeleteDonation
{
    public class DeleteDonationHandler : IRequestHandler<DeleteDonationCommand, ResultViewModel>
    {
        private readonly IDonationRepository _repository;
        public DeleteDonationHandler(IDonationRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel> Handle(DeleteDonationCommand request, CancellationToken cancellationToken)
        {
            var donation = await _repository.GetById(id: request.Id);
            if (donation == null)
            {
                return ResultViewModel.Error("Donation not found");
            }
            donation.SetAsDeleted();
            await _repository.Update(donation);
            return ResultViewModel.Success();
        }
    }
}