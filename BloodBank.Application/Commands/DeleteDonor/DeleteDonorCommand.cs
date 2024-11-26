using BloodBank.Application.Models;
using MediatR;

namespace BloodBank.Application.Commands.DeleteDonor
{
    public class DeleteDonorCommand : IRequest<ResultViewModel>
    {
        public DeleteDonorCommand(int id)
        {
            Id = id;
        }
        public int Id { get; private set; }
    }
}