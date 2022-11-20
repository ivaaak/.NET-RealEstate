using System.ComponentModel.DataAnnotations;

namespace RealEstate.Infrastructure.Entities
{
    public class Deal
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid ContragentId { get; set; }


        //[ForeignKey(nameof(ContragentId))]
        //public Agent? Contragent { get; set; }

        public IList<Listing>? DealSubjects { get; set; }
    }
}
