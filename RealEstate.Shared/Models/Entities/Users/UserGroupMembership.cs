#nullable disable
namespace RealEstate.Shared.Models.Entities.Users
{
    public class UserGroupMembership
    {
        public string GroupId { get; set; }
        public string UserId { get; set; }

        public virtual UserEntity User { get; set; }
    }
}
