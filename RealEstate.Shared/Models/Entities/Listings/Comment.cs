#nullable disable
using RealEstate.Shared.Models.Entities.BaseEntityModel;
using System.ComponentModel.DataAnnotations;

namespace RealEstate.Shared.Models.Entities.Listings
{
    public class Comment : IDeletableEntity
    {
        [Key]
        public string Comment_Id { get; init; }

        public string Comment_Title { get; set; }

        public string Comment_Content { get; set; }

        public string Comment_Rating { get; set; }

        public DateTime Date_Posted { get; set; }
        public Listing Listing { get; set; }


        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}
