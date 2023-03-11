using MediatR;
using RealEstate.Shared.MediatR.BehaviorModels.ResponseModels;
using RealEstate.Shared.Models.Entities.Estates;

namespace RealEstate.Shared.MediatR.Commands.Create
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
