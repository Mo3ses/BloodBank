using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloodBank.Core.Entities;

namespace BloodBank.Application.Models
{
    public class DonationViewModel
    {
        public DonationViewModel(int donorId, DateTime donationDate, int quantityML)
        {
            DonorId = donorId;
            DonationDate = donationDate;
            QuantityML = quantityML;

        }
        public int DonorId { get; private set; }
        public DateTime DonationDate { get; private set; }
        public int QuantityML { get; private set; }
        public static DonationViewModel FromEntity(Donation entity)
        => new(donorId: entity.DonorId, donationDate: entity.DonationDate, quantityML: entity.QuantityML);
    }
}