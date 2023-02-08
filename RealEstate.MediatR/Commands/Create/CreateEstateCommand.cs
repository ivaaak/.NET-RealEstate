using MediatR;
using RealEstate.MediatR.BehaviorModels.ResponseModels;
using RealEstate.Models.Entities.Estates;

namespace RealEstate.MediatR.Commands.Create
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
