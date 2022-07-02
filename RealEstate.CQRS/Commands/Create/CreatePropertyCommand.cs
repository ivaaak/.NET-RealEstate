using MediatR;
using RealEstate.CQRS.Pipeline;
using RealEstate.Infrastructure.Data;

namespace RealEstate.CQRS.Commands
{
    public class CreatePropertyCommand : IRequest<Response>
    {
        public Property Property { get; set; }
        public CreatePropertyCommand(Property Property)
        {
            this.Property = Property;
        }
    }
}
