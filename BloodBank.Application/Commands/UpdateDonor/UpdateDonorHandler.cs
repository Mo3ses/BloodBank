using BloodBank.Application.Models;
using BloodBank.Core.Repositories;
using MediatR;

namespace BloodBank.Application.Commands.UpdateDonor
{
    public class UpdateDonorHandler : IRequestHandler<UpdateDonorCommand, ResultViewModel>
    {
        private readonly IDonorRepository _repository;
        public UpdateDonorHandler(IDonorRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel> Handle(UpdateDonorCommand request, CancellationToken cancellationToken)
        {
            var donor = await _repository.GetById(request.Id);
            if (donor == null)
            {
                return ResultViewModel.Error("Donor not found.");
            }
            donor.Update(fullName: request.FullName, email: request.Email, birthDate: request.BirthDate, gender: request.Gender, weight: request.Weight, bloodType: request.BloodType, rhFactor: request.RhFactor);
            await _repository.Update(donor: donor);
            return ResultViewModel.Success();
        }
    }
}