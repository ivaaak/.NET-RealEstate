using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstate.Infrastructure.Data
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
