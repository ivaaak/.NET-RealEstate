#nullable disable
using RealEstate.Shared.Models.Entities.BaseEntityModel;
using System.ComponentModel.DataAnnotations;

namespace RealEstate.Shared.Models.Entities.Listings
{
    public class Comment : IDeletableEntity
    {
        [Key]
        public string Id { get; set; }

        public string Comment_Title { get; set; }

        public string Comment_Content { get; set; }

        public string Comment_Rating { get; set; }

        public DateTime Date_Posted { get; set; }
        public Listing Listing { get; set; }


        // IDeletableEntity
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}
