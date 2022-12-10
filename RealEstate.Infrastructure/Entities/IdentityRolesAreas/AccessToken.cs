using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RealEstate.Infrastructure.Entities.IdentityRolesAreas
{
    /// <summary>
    /// Access Token
    /// </summary>
    public class AccessToken : AzureDocumentBase
    {
        public AccessToken(string etag, long timestamp) : base(etag, timestamp) { }

        [JsonProperty(PropertyName = "id")]
        public Guid AccessTokenId { get; set; }

        [JsonProperty(PropertyName = "tenantId")]
        public Guid TenantId { get; set; }

        [JsonProperty(PropertyName = "userId")]
        public Guid UserId { get; set; }

        [JsonProperty(PropertyName = "institutionId")]
        public uint InstitutionId { get; set; }

        [JsonProperty(PropertyName = "institutionName")]
        public string InstitutionName { get; set; }

        [JsonProperty(PropertyName = "itemId")]
        public string ItemId { get; set; }

        [JsonProperty(PropertyName = "state")]
        public AccessTokenState State { get; set; }

        //[JsonProperty(PropertyName = "trackingType")]
        //public TrackingType TrackingType { get; set; }
    }

    /// <summary>
    /// Access Token State
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum AccessTokenState
    {
        None,

        Active,

        Inactive,
    }
}
