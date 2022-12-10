using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RealEstate.Infrastructure.Entities.IdentityRolesAreas
{
    /// <summary>
    /// User Role
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum UserRole
    {
        User,

        Admin,
    }
}
