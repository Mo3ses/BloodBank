using BloodBank.Core.Entities;

public class BloodStock : BaseEntity
{
    public BloodStock(string bloodType, string rhFactor, int quantityML) : base()
    {
        BloodType = bloodType;
        RhFactor = rhFactor;
        QuantityML = quantityML;
    }
    public string BloodType { get; private set; }
    public string RhFactor { get; private set; }
    public int QuantityML { get; private set; }
}