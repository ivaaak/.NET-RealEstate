using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RealEstate.Infrastructure.Entities.IdentityRolesAreas
{
    /// <summary>
    /// Asset Types
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum AssetType
    {
        Cash,

        Investment,

        Retirement,
    }
}
