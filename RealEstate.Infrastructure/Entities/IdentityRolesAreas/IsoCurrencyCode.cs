using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RealEstate.Infrastructure.Entities.IdentityRolesAreas
{
    /// <summary>
    /// ISO Currency Codes
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum IsoCurrencyCode
    {
        None,

        EUR,

        JPY,

        KRW,

        MXN,

        USD,
    }
}
