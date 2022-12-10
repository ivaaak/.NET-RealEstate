using Newtonsoft.Json;

namespace RealEstate.Infrastructure.Entities.IdentityRolesAreas
{
    /// <summary>
    /// Queue schema for SyncTransaction Function
    /// </summary>
    public class SyncTransactionQueue
    {
        [JsonProperty(PropertyName = "tenantId")]
        public Guid TenantId { get; set; }

        [JsonProperty(PropertyName = "itemId")]
        public string ItemId { get; set; }
    }
}
