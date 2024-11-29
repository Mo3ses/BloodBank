using BloodBank.Application.Models;
using MediatR;

namespace BloodBank.Application.Queries.GetAddressById
{
    public class GetAddressByIdQuery : IRequest<ResultViewModel<AddressViewModel>>
    {
        public GetAddressByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; private set; }
    }
}