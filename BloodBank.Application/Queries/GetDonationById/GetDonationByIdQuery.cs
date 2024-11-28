using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloodBank.Application.Models;
using MediatR;

namespace BloodBank.Application.Queries.GetDonationById
{
    public class GetDonationByIdQuery : IRequest<ResultViewModel<DonationViewModel>>
    {
        public GetDonationByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; private set; }
    }
}