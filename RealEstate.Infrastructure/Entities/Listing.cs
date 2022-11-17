using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstate.Infrastructure.Data.Entities
{
    public class Listing
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid AgentId { get; set; }

        public Guid PropertyId { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime DateListed { get; set; } = DateTime.Today;

        [StringLength(500)]
        public Currencies Currency { get; set; }

        public int Price { get; set; }

        public double PricePerSquareMeter 
        { 
            set
            {
                if ((value > 0 && Property != null))
                {
                    value = Price / Property.SquareMeters;
                }
            }
        }

        //[ForeignKey(nameof(PropertyId))]
        public Property? Property { get; set; }

        //[ForeignKey(nameof(AgentId))]
        //public Agent? Agent { get; set; }
    }
}
