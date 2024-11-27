using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloodBank.Application.Models;
using BloodBank.Core.Repositories;
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
    public class UpdateDonationHandler : IRequestHandler<UpdateDonationCommand, ResultViewModel>
    {
        private readonly IDonationRepository _repository;
        public UpdateDonationHandler(IDonationRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel> Handle(UpdateDonationCommand request, CancellationToken cancellationToken)
        {
            var donation = await _repository.GetById(id: request.Id);
            if (donation == null)
            {
                return ResultViewModel.Error("Donation not found");
            }
            donation.Update(donorId: request.DonorId, donationDate: request.DonationDate, quantityML: request.QuantityML);
            await _repository.Update(donation);
            return ResultViewModel.Success();
        }
    }
}