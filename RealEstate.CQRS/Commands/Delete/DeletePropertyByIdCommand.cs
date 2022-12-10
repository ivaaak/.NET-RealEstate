using MediatR;
using RealEstate.CQRS.BehaviorModels.ResponseModels;

namespace RealEstate.CQRS.Commands.Delete
{
    public class DeletePropertyByIdCommand : IRequest<Response> //is void
    {
        public int Id { get; set; }
        public DeletePropertyByIdCommand(int Id)
        {
            this.Id = Id;
        }
    }
}
