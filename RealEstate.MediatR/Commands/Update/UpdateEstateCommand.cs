using MediatR;
using RealEstate.MediatR.BehaviorModels.ResponseModels;
using RealEstate.Models.Entities.Estates;

namespace RealEstate.MediatR.Commands.Update
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
