using BloodBank.Application.Models;
using BloodBank.Core.Repositories;
using MediatR;

namespace BloodBank.Application.Commands.DeleteDonor
{
    public class DeleteDonorHandler : IRequestHandler<DeleteDonorCommand, ResultViewModel>
    {
        private readonly IDonorRepository _repository;
        public DeleteDonorHandler(IDonorRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel> Handle(DeleteDonorCommand request, CancellationToken cancellationToken)
        {
            var donor = await _repository.GetById(request.Id);
            if (donor == null)
            {
                return ResultViewModel.Error("Donor not found.");
            }
            donor.SetAsDeleted();
            await _repository.Update(donor: donor);
            return ResultViewModel.Success();
        }
    }
}