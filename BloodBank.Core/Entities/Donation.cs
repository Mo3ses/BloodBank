using BloodBank.Core.Entities;

public class Donation : BaseEntity
{
    public Donation(int donorId, DateTime donationDate, int quantityML) : base()
    {
        DonorId = donorId;
        DonationDate = donationDate;
        QuantityML = quantityML;
    }
    public int DonorId { get; private set; }
    public DateTime DonationDate { get; private set; }
    public int QuantityML { get; private set; }
    public Donor Donor { get; private set; }
    public void Update(int donorId, DateTime donationDate, int quantityML)
    {
        DonorId = donorId;
        DonationDate = donationDate;
        QuantityML = quantityML;
    }
}
