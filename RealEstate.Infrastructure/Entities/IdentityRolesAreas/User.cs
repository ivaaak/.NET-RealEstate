using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RealEstate.Infrastructure.Entities.IdentityRolesAreas
{
    /// <summary>
    /// User
    /// </summary>
    public class User : AzureDocumentBase
    {
        public User(string etag, long timestamp) : base(etag, timestamp) { }

        [JsonProperty(PropertyName = "id")]
        public Guid UserId { get; set; }

        [JsonProperty(PropertyName = "tenantId")]
        public Guid TenantId { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "profileImageUrl")]
        public string ProfileImageUrl { get; set; }

        [JsonProperty(PropertyName = "state")]
        public UserState State { get; set; }

        [JsonProperty(PropertyName = "role")]
        public UserRole Role { get; set; }
    }

    /// <summary>
    /// User State
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum UserState
    {
        Active,

        Inactive,
    }
}
