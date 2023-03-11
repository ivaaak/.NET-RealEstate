using MediatR;
using RealEstate.Shared.MediatR.BehaviorModels.ResponseModels;
using RealEstate.Shared.Models.Entities.Estates;

namespace RealEstate.Shared.MediatR.Commands.Update
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
