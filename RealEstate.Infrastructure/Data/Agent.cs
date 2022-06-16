using System.ComponentModel.DataAnnotations;

namespace RealEstate.Infrastructure.Data
{
    public class Agent 
    // The agent can list properties for sale.
    {
        [Key]
        public int Id { get; init; }
        
        public string UserId { get; set; }

        [Required]
        [StringLength(200)]
        public string? FirstName { get; set; }

        [Required]
        [StringLength(200)]
        public string? LastName { get; set; }

        [StringLength(200)]
        public string? Email { get; set; }

        [StringLength(200)]
        public string? Address { get; set; }

        [Required]
        [MaxLength(12)]
        public string PhoneNumber { get; set; }


        public IEnumerable<Deal> Deals { get; set; } = new List<Deal>();

        public IEnumerable<Property> Properties { get; init; } = new List<Property>();
    }
}
