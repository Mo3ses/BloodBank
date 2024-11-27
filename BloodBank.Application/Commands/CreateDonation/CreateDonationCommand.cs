using BloodBank.Application.Models;
using MediatR;

namespace BloodBank.Application.Commands.CreateDonation
{
    public class CreateDonationCommand : IRequest<ResultViewModel<int>>
    {
        public CreateDonationCommand(int donorId, int quantityML)
        {
            DonorId = donorId;
            DonationDate = DateTime.Today;
            QuantityML = quantityML;

        }
        public int DonorId { get; private set; }
        public DateTime DonationDate { get; private set; }
        public int QuantityML { get; private set; }
        public Donation ToEntity() => new(donorId: DonorId, donationDate: DonationDate, quantityML: QuantityML);
    }
}