using System.ComponentModel.DataAnnotations;

namespace RealEstate.Models.Entities.Misc
{
    public class DocumentModel
    {
        public int Id { get; set; }

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
            Id = 0;
            UserId = 0;
            FileName = "";
            ContentType = "";
            FileSize = 0;
            FileContent = null;
        }
    }
}
