using BloodBank.Core.Entities;

namespace BloodBank.Application.Models
{
    public class AddressViewModel
    {
        public AddressViewModel(string street, string city, string state, string postalCode)
        {
            Street = street;
            City = city;
            State = state;
            PostalCode = postalCode;
        }

        public string Street { get; private set; }
        public string City { get; private set; }
        public string State { get; set; }
        public string PostalCode { get; private set; }
        public static AddressViewModel FromEntity(Address entity)
        => new AddressViewModel(street: entity.Street, city: entity.City, state: entity.State, postalCode: entity.PostalCode);
    }
}