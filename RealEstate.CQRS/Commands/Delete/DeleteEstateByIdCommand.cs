using MediatR;
using RealEstate.CQRS.BehaviorModels.ResponseModels;

namespace RealEstate.CQRS.Commands.Delete
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
