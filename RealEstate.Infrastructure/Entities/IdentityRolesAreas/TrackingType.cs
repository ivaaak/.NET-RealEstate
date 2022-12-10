using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RealEstate.Infrastructure.Entities.IdentityRolesAreas
{
    /// <summary>
    /// Account Tracking Type
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TrackingType
    {
        Job,

        Plaid,
    }
}
