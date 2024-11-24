using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodBank.Application.Models
{
    public class DonationInputModel
    {
        public DonationInputModel(int donorId, int quantityML)
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