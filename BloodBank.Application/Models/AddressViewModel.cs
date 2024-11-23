namespace BloodBank.Application.Models
{
    public class AddressViewModel
    {
        public AddressViewModel(int addressId, int donorId, string street, string city, string state, string postalCode)
        {
            AddressId = addressId;
            DonorId = donorId;
            Street = street;
            City = city;
            State = state;
            PostalCode = postalCode;
        }
        public int AddressId { get; set; }
        public int DonorId { get; private set; }
        public string Street { get; private set; }
        public string City { get; private set; }
        public string State { get; set; }
        public string PostalCode { get; private set; }
        public static AddressViewModel FromEntity(Address entity)
        => new AddressViewModel(addressId: entity.Id, street: entity.Street, city: entity.City, state: entity.State, postalCode: entity.PostalCode);
    }
}