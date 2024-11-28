using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloodBank.Application.Models;
using MediatR;

namespace BloodBank.Application.Queries.GetAllDonations
{
    public class GetAllDonationQuery : IRequest<ResultViewModel<List<DonationViewModel>>>
    {
        public GetAllDonationQuery()
        {

        }
    }
}