using MediatR;
using RealEstate.CQRS.Responses;
using RealEstate.Infrastructure.Entities.Estates;

namespace RealEstate.CQRS.Commands
{
    public class CreateEstateCommand : IRequest<Response>
    {
        public Estate Estate { get; set; }

        public CreateEstateCommand(Estate Estate)
        {
            this.Estate = Estate;
        }
    }
}
