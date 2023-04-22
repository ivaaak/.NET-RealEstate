#nullable disable
namespace RealEstate.Shared.Models.DTOs.Users
{
    public class UserDeactivateDto
    {
        public Guid SubjectId { get; set; }
        public string Username { get; set; }
        public string IsActive { get; set; }
    }
}
