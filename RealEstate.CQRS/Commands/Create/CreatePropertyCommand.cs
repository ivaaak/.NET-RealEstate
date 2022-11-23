using MediatR;
using RealEstate.CQRS.Responses;
using RealEstate.Infrastructure.Entities.Estates;

namespace RealEstate.CQRS.Commands
{
    public class CreatePropertyCommand : IRequest<Response>
    {
        public Estate Property { get; set; }
        public CreatePropertyCommand(Estate Property)
        {
            this.Property = Property;
        }
    }
}
