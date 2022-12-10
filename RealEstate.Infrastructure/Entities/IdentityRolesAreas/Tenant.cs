using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RealEstate.Infrastructure.Entities.IdentityRolesAreas
{
    /// <summary>
    /// Tenant
    /// </summary>
    public class Tenant : AzureDocumentBase
    {
        public Tenant(string etag, long timestamp) : base(etag, timestamp) { }

        [JsonProperty(PropertyName = "id")]
        public Guid TenantId { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "timeZoneId")]
        public string TimeZoneId { get; set; }

        [JsonProperty(PropertyName = "state")]
        public TenantState State { get; set; }

        [JsonIgnore]
        public DateTime LocalNow =>
            TimeZoneInfo.ConvertTimeFromUtc(
                DateTime.UtcNow,
                TimeZoneInfo.FindSystemTimeZoneById(TimeZoneId));
    }

    /// <summary>
    /// Tenant State
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TenantState
    {
        Active,

        Inactive,
    }
}
