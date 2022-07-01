using MediatR;
using RealEstate.Core.Models;

namespace RealEstate.CQRS.Queries
{
    public class GetPersonByIdQuery : IRequest<UserViewModel> 
    //returns UserViewModel
    {
        public Guid Id { get; set; }
        public GetPersonByIdQuery(Guid Id)
        {
            this.Id = Id;
        }
    }
}
