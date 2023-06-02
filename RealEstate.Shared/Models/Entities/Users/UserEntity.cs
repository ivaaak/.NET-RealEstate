#nullable disable
using RealEstate.Shared.Models.Entities.BaseEntityModel;

namespace RealEstate.Shared.Models.Entities.Users
{
    public class UserEntity : IDeletableEntity
    {
        public UserEntity()
        {
            UserAttributes = new HashSet<UserAttribute>();
            UserGroupMemberships = new HashSet<UserGroupMembership>();
            UserRoleMappings = new HashSet<UserRoleMapping>();
        }

        public string Id { get; set; }
        public string Email { get; set; }
        public string EmailConstraint { get; set; }
        public bool EmailVerified { get; set; }
        public bool Enabled { get; set; }
        public string FederationLink { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string RealmId { get; set; }
        public string Username { get; set; }
        public long? CreatedTimestamp { get; set; }
        public string ServiceAccountClientLink { get; set; }
        public int NotBefore { get; set; }


        //public virtual ICollection<Credential> Credentials { get; set; }
        //public virtual ICollection<FederatedIdentity> FederatedIdentities { get; set; }
        public virtual ICollection<UserAttribute> UserAttributes { get; set; }
        public virtual ICollection<UserGroupMembership> UserGroupMemberships { get; set; }
        public virtual ICollection<UserRoleMapping> UserRoleMappings { get; set; }


        // IDeletableEntity
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}
