using BloodBank.Application.Models;
using BloodBank.Core.Repositories;
using MediatR;

namespace BloodBank.Application.Queries.GetDonorById
{
    public class GetDonorByIdHandler : IRequestHandler<GetDonorByIdQuery, ResultViewModel<DonorViewModel>>
    {
        private readonly IDonorRepository _repository;
        public GetDonorByIdHandler(IDonorRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel<DonorViewModel>> Handle(GetDonorByIdQuery request, CancellationToken cancellationToken)
        {
            var donor = await _repository.GetById(id: request.Id);
            if (donor == null)
            {
                return ResultViewModel<DonorViewModel>.Error("Donor not found.");
            }
            var model = DonorViewModel.FromEntity(donor);
            return ResultViewModel<DonorViewModel>.Success(model);
        }
    }
}