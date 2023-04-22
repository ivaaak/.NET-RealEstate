#nullable disable
namespace RealEstate.Shared.Models.DTOs.Users
{
    public class UserDto
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IsActive { get; set; }
    }
}
