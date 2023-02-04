using MediatR;
using RealEstate.Models.ViewModels.Estates;

namespace RealEstate.MediatR.Queries
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
