using BloodBank.Application.Models;
using MediatR;

namespace BloodBank.Application.Queries.GetDonorById
{
    public class GetDonorByIdQuery : IRequest<ResultViewModel<DonorViewModel>>
    {
        public GetDonorByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; private set; }
    }
}