using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloodBank.Application.Models;
using MediatR;

namespace BloodBank.Application.Commands.DeleteDonation
{
    public class DeleteDonationCommand : IRequest<ResultViewModel>
    {
        public DeleteDonationCommand(int id)
        {
            Id = id;
        }
        public int Id { get; private set; }
    }
}