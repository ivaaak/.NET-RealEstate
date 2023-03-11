using MediatR;
using RealEstate.Shared.MediatR.BehaviorModels.ResponseModels;

namespace RealEstate.Shared.MediatR.Commands.Delete
{
    public class DeleteEstateByIdCommand : IRequest<Response> //is void
    {
        public int Id { get; set; }
        public DeleteEstateByIdCommand(int Id)
        {
            this.Id = Id;
        }
    }
}
