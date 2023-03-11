using MediatR;
using RealEstate.Shared.Models.DTOs.Estates;

namespace RealEstate.Shared.MediatR.Queries
{
    public class GetEstateByIdQuery : IRequest<EstateDTO>
    {
        public int Id { get; set; }

        public GetEstateByIdQuery(int Id)
        {
            this.Id = Id;
        }
    }
}
