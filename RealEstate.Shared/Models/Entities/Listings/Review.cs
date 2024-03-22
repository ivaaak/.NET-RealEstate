#nullable disable
using RealEstate.Shared.Models.Entities.BaseEntityModel;
using System.ComponentModel.DataAnnotations;

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
    }
}
