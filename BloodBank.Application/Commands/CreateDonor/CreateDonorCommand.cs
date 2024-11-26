using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloodBank.Application.Models;
using BloodBank.Core.Entities;
using MediatR;

namespace BloodBank.Application.Commands.CreateDonor
{
    public class CreateDonorCommand : IRequest<ResultViewModel<int>>
    {

        public CreateDonorCommand(string fullName, string email, DateTime birthDate, string gender, double weight, string bloodType, string rhFactor)
        {
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;
            Gender = gender;
            Weight = weight;
            BloodType = bloodType;
            RhFactor = rhFactor;
        }
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string Gender { get; private set; }
        public double Weight { get; private set; }
        public string BloodType { get; private set; }
        public string RhFactor { get; private set; }
        public Donor ToEntity()
            => new(
                fullName: FullName,
                email: Email,
                birthDate: BirthDate,
                gender: Gender,
                weight: Weight,
                bloodType: BloodType,
                rhFactor: RhFactor
                );
    }
}
