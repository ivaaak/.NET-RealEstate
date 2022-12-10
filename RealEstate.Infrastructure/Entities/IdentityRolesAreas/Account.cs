using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RealEstate.Infrastructure.Entities.IdentityRolesAreas
{
    /// <summary>
    /// Account
    /// </summary>
    public class Account : AzureDocumentBase
    {
        public Account(string etag, long timestamp) : base(etag, timestamp) { }

        [JsonProperty(PropertyName = "id")]
        public Guid AccountId { get; set; }

        [JsonProperty(PropertyName = "symbol")]
        public string Symbol { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "tenantId")]
        public Guid TenantId { get; set; }

        [JsonProperty(PropertyName = "userId")]
        public Guid UserId { get; set; }

        [JsonProperty(PropertyName = "accessToken")]
        public string AccessToken { get; set; }

        [JsonProperty(PropertyName = "state")]
        public AccountState State { get; set; }

        [JsonProperty(PropertyName = "assetType")]
        public AssetType? AssetType { get; set; }
        /*
        [JsonProperty(PropertyName = "expenseType")]
        public ExpenseType? ExpenseType { get; set; }

        [JsonProperty(PropertyName = "trackingType")]
        public TrackingType? TrackingType { get; set; }
        */
        [JsonProperty(PropertyName = "aliasId")]
        public string AliasId { get; set; }

        [JsonIgnore]
        public bool shouldSerializeAccessToken = false;

        public bool ShouldSerializeAccessToken()
        {
            // don't serialize AccessToken if the flag is set to false
            return shouldSerializeAccessToken;
        }
    }

    /// <summary>
    /// Account State
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum AccountState
    {
        None,

        Active,

        Inactive,
    }
}
