using BloodBank.Application.Models;
using BloodBank.Core.Repositories;
using MediatR;

namespace BloodBank.Application.Queries.GetAllDonations
{
    public class GetAllDonationHandler : IRequestHandler<GetAllDonationQuery, ResultViewModel<List<DonationViewModel>>>
    {
        private readonly IDonationRepository _repository;
        public GetAllDonationHandler(IDonationRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel<List<DonationViewModel>>> Handle(GetAllDonationQuery request, CancellationToken cancellationToken)
        {
            var donations = await _repository.GetAll();
            var models = donations.Select(DonationViewModel.FromEntity).ToList();
            return ResultViewModel<List<DonationViewModel>>.Success(models);
        }
    }
}