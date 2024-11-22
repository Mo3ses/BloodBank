using BloodBank.Core.Entities;

namespace BloodBank.Application.Models
{
    public class DonorViewModel
    {
        public DonorViewModel(int donorId, string fullName, string email, DateTime birthDate, string gender, double weight, string bloodType, string rhFactor, Address address, List<Donation> donations)
        {
            DonorId = donorId;
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;
            Gender = gender;
            Weight = weight;
            BloodType = bloodType;
            RhFactor = rhFactor;
            Address = AddressViewModel.FromEntity(entity: address);
            Donations = donations.Select(d => DonationViewModel.FromEntity(d)).ToList();
        }
        public int DonorId { get; private set; }
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string Gender { get; private set; }
        public double Weight { get; private set; }
        public string BloodType { get; private set; }
        public string RhFactor { get; private set; }
        public AddressViewModel Address { get; private set; }
        public List<DonationViewModel> Donations { get; private set; }
        public static DonorViewModel FromEntity(Donor entity)
        => new(
            donorId: entity.Id,
            fullName: entity.FullName,
            email: entity.Email,
            birthDate: entity.BirthDate,
            gender: entity.Gender,
            weight: entity.Weight,
            bloodType: entity.BloodType,
            rhFactor: entity.RhFactor,
            address: entity.Address,
            donations: entity.Donations
            );
    }
}
