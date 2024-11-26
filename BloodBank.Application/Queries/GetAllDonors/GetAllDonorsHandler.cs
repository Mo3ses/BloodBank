using BloodBank.Application.Models;
using BloodBank.Core.Repositories;
using MediatR;

namespace BloodBank.Application.Queries.GetAllDonors
{
    public class GetAllDonorsHandler : IRequestHandler<GetAllDonorsQuery, ResultViewModel<List<DonorViewModel>>>
    {
        private readonly IDonorRepository _repository;
        public GetAllDonorsHandler(IDonorRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel<List<DonorViewModel>>> Handle(GetAllDonorsQuery request, CancellationToken cancellationToken)
        {
            var donors = await _repository.GetAll();
            var models = donors.Select(DonorViewModel.FromEntity).ToList();
            return ResultViewModel<List<DonorViewModel>>.Success(models);
        }
    }
}