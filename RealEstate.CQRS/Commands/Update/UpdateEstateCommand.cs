using MediatR;
using RealEstate.CQRS.BehaviorModels.ResponseModels;
using RealEstate.Models.Entities.Estates;

namespace RealEstate.CQRS.Commands.Update
{
    public class UpdateEstateCommand : IRequest<Response>
    {
        public Estate Estate { get; set; }

        public UpdateEstateCommand(Estate Estate)
        {
            this.Estate = Estate;
        }
    }
}
