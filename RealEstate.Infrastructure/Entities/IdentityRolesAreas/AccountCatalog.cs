using Newtonsoft.Json;

namespace RealEstate.Infrastructure.Entities.IdentityRolesAreas
{
    /// <summary>
    /// Account Catalog
    /// </summary>
    public class AccountCatalog : AzureDocumentBase
    {
        public AccountCatalog() { }

        public AccountCatalog(string etag) : base(etag) { }

        [JsonConstructor]
        public AccountCatalog(string etag, long timestamp) : base(etag, timestamp) { }

        //[JsonProperty(PropertyName = "id")]
        //public GuidDate AccountCatalogId { get; set; }

        [JsonProperty(PropertyName = "tenantId")]
        public Guid TenantId { get; set; }

        [JsonProperty(PropertyName = "value")]
        public decimal Value { get; set; }
    }
}
