using BloodBank.Core.Entities;

public class Address : BaseEntity
{
    public Address(string postalCode, Donor donor) : base()
    {
        PostalCode = postalCode;
        Donor = donor;
    }
    public string Street { get; private set; }
    public string City { get; private set; }
    public string State { get; set; }
    public string PostalCode { get; private set; }
    public Donor Donor { get; private set; }
}
