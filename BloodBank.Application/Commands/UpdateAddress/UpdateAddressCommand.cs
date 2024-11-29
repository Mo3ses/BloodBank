using BloodBank.Application.Models;
using MediatR;

namespace BloodBank.Application.Commands.UpdateAddress
{
    public class UpdateAddressCommand : IRequest<ResultViewModel>
    {
        public UpdateAddressCommand(int id, string street, string city, string state, string postalCode, int donorId)
        {
            Id = id;
            Street = street;
            City = city;
            State = state;
            PostalCode = postalCode;
            DonorId = donorId;
        }
        public int Id { get; private set; }
        public string Street { get; private set; }
        public string City { get; private set; }
        public string State { get; set; }
        public string PostalCode { get; private set; }
        public int DonorId { get; private set; }
    }
}