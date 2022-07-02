using MediatR;
using RealEstate.CQRS.Pipeline;

namespace RealEstate.CQRS.Commands
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
