#nullable disable
using RealEstate.Shared.Models.Entities.BaseEntityModel;
using System.ComponentModel.DataAnnotations;

namespace RealEstate.Shared.Models.Entities.Misc
{
    public class DocumentModel : IDeletableEntity
    {
        public string Id { get; set; }

        public int UserId { get; set; }

        [Required]
        public string FileName { get; set; }

        [Required]
        public string ContentType { get; set; }
        // rentals, purchases, contracts or proof of income.

        public long FileSize { get; set; }

        public byte[] FileContent { get; set; }

        public DocumentModel()
        {
            Id = "0";
            UserId = 0;
            FileName = "";
            ContentType = "";
            FileSize = 0;
            FileContent = null;
        }


        // IDeletableEntity
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}
