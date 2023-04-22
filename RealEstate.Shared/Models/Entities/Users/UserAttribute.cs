#nullable disable
namespace RealEstate.Shared.Models.Entities.Users
{
    public class UserAttribute
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public string UserId { get; set; }
        public string Id { get; set; }

        public virtual UserEntity User { get; set; }
    }
}
