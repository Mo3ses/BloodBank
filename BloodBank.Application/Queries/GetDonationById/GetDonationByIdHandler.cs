using BloodBank.Application.Models;
using BloodBank.Core.Repositories;
using MediatR;

namespace BloodBank.Application.Queries.GetDonationById
{
    public class GetDonationByIdHandler : IRequestHandler<GetDonationByIdQuery, ResultViewModel<DonationViewModel>>
    {
        private readonly IDonationRepository _repository;
        public GetDonationByIdHandler(IDonationRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel<DonationViewModel>> Handle(GetDonationByIdQuery request, CancellationToken cancellationToken)
        {
            var donation = await _repository.GetById(id: request.Id);
            if (donation == null)
            {
                return ResultViewModel<DonationViewModel>.Error("Donor not found.");
            }
            var model = DonationViewModel.FromEntity(donation);
            return ResultViewModel<DonationViewModel>.Success(model);
        }
    }
}