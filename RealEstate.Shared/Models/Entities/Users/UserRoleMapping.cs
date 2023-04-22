#nullable disable
namespace RealEstate.Shared.Models.Entities.Users
{
    public partial class UserRoleMapping
    {
        public string RoleId { get; set; }
        public string UserId { get; set; }

        public virtual UserEntity User { get; set; }
    }
}
