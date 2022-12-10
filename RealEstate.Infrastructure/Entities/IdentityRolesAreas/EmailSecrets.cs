using Newtonsoft.Json;

namespace RealEstate.Infrastructure.Entities.IdentityRolesAreas
{
    /// <summary>
    /// Email Secrets
    /// </summary>
    public class EmailSecrets
    {
        [JsonProperty(PropertyName = "fromAddress", Required = Required.Always)]
        public string FromAddress { get; set; }

        [JsonProperty(PropertyName = "fromPassword", Required = Required.Always)]
        public string FromPassword { get; set; }

        [JsonProperty(PropertyName = "toAddress", Required = Required.Always)]
        public string ToAddress { get; set; }

        [JsonProperty(PropertyName = "toName", Required = Required.Always)]
        public string ToName { get; set; }
    }
}
