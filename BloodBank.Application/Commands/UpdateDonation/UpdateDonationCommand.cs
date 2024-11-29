using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloodBank.Application.Models;
using MediatR;

namespace BloodBank.Application.Commands.UpdateDonation
{
    public class UpdateDonationCommand : IRequest<ResultViewModel>
    {
        public UpdateDonationCommand(int id, int donorId, DateTime donationDate, int quantityML)
        {
            Id = id;
            DonorId = donorId;
            DonationDate = donationDate;
            QuantityML = quantityML;

        }
        public int Id { get; private set; }
        public int DonorId { get; private set; }
        public DateTime DonationDate { get; private set; }
        public int QuantityML { get; private set; }
        public static UpdateDonationCommand FromEntity(Donation entity)
        => new(id: entity.Id, donorId: entity.DonorId, donationDate: entity.DonationDate, quantityML: entity.QuantityML);

    }
}