using MediatR;
using RealEstate.CQRS.BehaviorModels.ResponseModels;
using RealEstate.Models.Entities.Estates;

namespace RealEstate.CQRS.Commands.Create
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
