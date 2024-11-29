using BloodBank.Application.Models;
using MediatR;

namespace BloodBank.Application.Commands.CreateAddress
{
    public class CreateAddressCommand : IRequest<ResultViewModel<int>>
    {
        public CreateAddressCommand(string street, string city, string state, string postalCode, int donorId)
        {
            Street = street;
            City = city;
            State = state;
            PostalCode = postalCode;
            DonorId = donorId;
        }
        public string Street { get; private set; }
        public string City { get; private set; }
        public string State { get; set; }
        public string PostalCode { get; private set; }
        public int DonorId { get; private set; }

        public Address ToEntity() => new(street: Street, city: City, state: State, postalCode: PostalCode, donorId: DonorId);

    }
}