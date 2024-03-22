#nullable disable
using RealEstate.Shared.Models.Entities.BaseEntityModel;
using RealEstate.Shared.Models.Entities.Estates;
using RealEstate.Shared.Models.Entities.Clients;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstate.Shared.Models.Entities.Listings
{
    public class Review : IDeletableEntity
    {
        [Key]
        public string Id { get; set; }
        public DateTime At { get; set; }
        public string Txt { get; set; }
        public int Rate { get; set; }
        
        // Foreign Key
        public string ById { get; set; }

        [ForeignKey("ById")]
        public Client By { get; set; }

        // Navigation Property
        public Estate Estate { get; set; }

        // IDeletableEntity
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}
